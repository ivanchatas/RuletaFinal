using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RuletaFinal.Business;
using RuletaFinal.Business.Implementations;
using RuletaFinal.Business.Interfaces;
using RuletaFinal.DAL.Implementations;
using RuletaFinal.DAL.Interfaces;
using StackExchange.Redis;
using System;

namespace RuletaFinal.API
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
            services.AddControllers();

            //added to use in-memory cache
            services.AddMemoryCache();

            //added to use Redis cache
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = Configuration.GetValue<string>("RedisConnection");
            });

            #region Custom services
            services.AddScoped<IBusinnesRuleta, BusinnesRuleta>();
            services.AddScoped<IBusinnesUsuario, BusinnesUsuario>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IRepositoryRuleta, RepositoryRuleta>();
            services.AddScoped<IRepositoryUsuario, RepositoryUsuario>();
            #endregion

            // Register the Swagger services
            services.AddSwaggerDocument();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Register the Swagger generator and the Swagger UI middlewares
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
