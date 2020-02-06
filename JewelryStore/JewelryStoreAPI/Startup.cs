using Autofac;
using AutoMapper;
using FluentValidation.AspNetCore;
using JewelryStoreAPI.Common;
using JewelryStoreAPI.Core;
using JewelryStoreAPI.Core.Repositories;
using JewelryStoreAPI.Infrastructure.DTO.Bijouterie;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Presentations.Bijouterie;
using JewelryStoreAPI.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

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
                    options.UseNpgsql(Configuration.GetConnectionString("JewelryStoreDatabase"), b => b.MigrationsAssembly("JewelryStoreAPI.Core"));
                }
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JewelryStore API", Version = "v1" });
            });

            services.AddAutoMapper(typeof(BijouterieDto), typeof(BijouterieModel));
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<BijouterieRepository>().As<IBijouterieRepository>();
            builder.RegisterType<BijouterieService>().As<IBijouterieService>();
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
