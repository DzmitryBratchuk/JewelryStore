using Autofac;
using AutoMapper;
using Confluent.Kafka;
using FluentValidation.AspNetCore;
using JewelryStoreAPI.Common;
using JewelryStoreAPI.Core;
using JewelryStoreAPI.Core.Repositories;
using JewelryStoreAPI.Infrastructure.Common;
using JewelryStoreAPI.Infrastructure.DTO.Bijouterie;
using JewelryStoreAPI.Models.Bijouterie;
using JewelryStoreAPI.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

namespace JewelryStoreAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<BijouterieModel>());

            services.AddDbContext<JewelryStoredbContext>(options =>
            {
                if (!options.IsConfigured)
                {
                    options.UseLazyLoadingProxies()
                        .UseNpgsql(Configuration.GetConnectionString("JewelryStoreDatabase"), b => b.MigrationsAssembly("JewelryStoreAPI.Core"));
                }
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JewelryStore API", Version = "v1" });
            });

            services.AddAutoMapper(typeof(BijouterieDto), typeof(BijouterieModel));

            services.AddCors();

            AddAuthentication(services);
            AddKafka(services);
            AddRedisCache(services);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var repositoryAssembly = Assembly.GetAssembly(typeof(BijouterieRepository));
            builder.RegisterAssemblyTypes(repositoryAssembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            var serviceAssembly = Assembly.GetAssembly(typeof(BijouterieService));
            builder.RegisterAssemblyTypes(serviceAssembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.Register(x => x.Resolve<IHttpContextAccessor>().HttpContext.User)
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<CryptoHash>()
                .AsSelf()
                .SingleInstance();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/JewelryStore_{Date}.txt");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCustomExceptionHandler();

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "JewelryStore API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseCors(
                options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
            );

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddAuthentication(IServiceCollection services)
        {
            var jwtSettingsSection = Configuration.GetSection("JwtSettings");

            services.Configure<JwtSettings>(jwtSettingsSection);

            var jwtSettings = jwtSettingsSection.Get<JwtSettings>();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true
                    };
                });
        }

        private void AddKafka(IServiceCollection services)
        {
            var kafkaConfiguration = Configuration.GetSection("KafkaConfiguration").Get<KafkaConfiguration>();

            services.Configure<KafkaConfiguration>(options =>
            {
                options.ServerUrl = kafkaConfiguration.ServerUrl;
                options.GroupId = kafkaConfiguration.GroupId;
                options.Topics = new Topics { CreateWatch = kafkaConfiguration.Topics.CreateWatch };
            });

            services.AddSingleton(c => new ProducerBuilder<Null, string>(
                new ProducerConfig() { BootstrapServers = kafkaConfiguration.ServerUrl }).Build()
            );

            services.AddSingleton(c => new ConsumerBuilder<Ignore, string>(
                new ConsumerConfig() { BootstrapServers = kafkaConfiguration.ServerUrl, GroupId = kafkaConfiguration.GroupId }).Build()
            );
        }

        private void AddRedisCache(IServiceCollection services)
        {
            var redisConfiguration = Configuration.GetSection("RedisConfiguration").Get<RedisConfiguration>();

            services.Configure<RedisConfiguration>(options =>
            {
                options.ServerUrl = redisConfiguration.ServerUrl;
                options.CacheExpirationInSeconds = redisConfiguration.CacheExpirationInSeconds;
                options.CacheKeys = new CacheKeys { GetAllWatches = redisConfiguration.CacheKeys.GetAllWatches };
            });

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = redisConfiguration.ServerUrl;
            });
        }
    }
}
