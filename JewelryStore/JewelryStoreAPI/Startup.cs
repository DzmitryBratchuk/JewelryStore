using Autofac;
using AutoMapper;
using FluentValidation.AspNetCore;
using JewelryStoreAPI.Common;
using JewelryStoreAPI.Core;
using JewelryStoreAPI.Core.Repositories;
using JewelryStoreAPI.Infrastructure.Common;
using JewelryStoreAPI.Infrastructure.DTO.Bijouterie;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Presentations.Bijouterie;
using JewelryStoreAPI.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
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
            services.AddHttpContextAccessor();
            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<BijouterieModel>());

            services.AddDbContext<JewelryStoredbContext>(options =>
            {
                if (!options.IsConfigured)
                {
                    options.UseNpgsql(Configuration.GetConnectionString("JewelryStoreDatabase"), b => b.MigrationsAssembly("JewelryStoreAPI.Core"));
                }
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JewelryStore API", Version = "v1" });
            });

            services.AddAutoMapper(typeof(BijouterieDto), typeof(BijouterieModel));

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
                options.SaveToken = true;
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

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<BijouterieRepository>().As<IBijouterieRepository>();
            builder.RegisterType<BijouterieService>().As<IBijouterieService>();

            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<UserService>().As<IUserService>();

            builder.RegisterType<RoleRepository>().As<IRoleRepository>();
            builder.RegisterType<RoleService>().As<IRoleService>();

            builder.RegisterType<CountryRepository>().As<ICountryRepository>();
            builder.RegisterType<CountryService>().As<ICountryService>();

            builder.RegisterType<BrandRepository>().As<IBrandRepository>();
            builder.RegisterType<BrandService>().As<IBrandService>();

            builder.RegisterType<BijouterieTypeRepository>().As<IBijouterieTypeRepository>();
            builder.RegisterType<BijouterieTypeService>().As<IBijouterieTypeService>();

            builder.RegisterType<PreciousItemTypeRepository>().As<IPreciousItemTypeRepository>();
            builder.RegisterType<PreciousItemTypeService>().As<IPreciousItemTypeService>();

            builder.RegisterType<PreciousItemRepository>().As<IPreciousItemRepository>();
            builder.RegisterType<PreciousItemService>().As<IPreciousItemService>();

            builder.RegisterType<WatchRepository>().As<IWatchRepository>();
            builder.RegisterType<WatchService>().As<IWatchService>();

            builder.RegisterType<ProductBasketRepository>().As<IProductBasketRepository>();
            builder.RegisterType<ProductBasketService>().As<IProductBasketService>();

            builder.RegisterType<BasketRepository>().As<IBasketRepository>();

            builder.RegisterType<ProductOrderRepository>().As<IProductOrderRepository>();
            builder.RegisterType<ProductOrderService>().As<IProductOrderService>();

            builder.RegisterType<OrderRepository>().As<IOrderRepository>();

            builder.RegisterType<ReportService>().As<IReportService>();

            builder.RegisterType<CryptoHash>().AsSelf();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/JewelryStore_{Date}.txt");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
