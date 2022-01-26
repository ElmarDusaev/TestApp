using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.DataAccess;
using TestApp.DataAccess.Repositories;
using TestApp.Domain.Repositories;
using TestApp.Domain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using TestApp.WebApi.Profiles;

namespace TestApp.WebApi
{
    public class Startup
    {

        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = _configuration.GetConnectionString("Default");

            services.AddDbContext<Context>(x=>x.UseSqlServer(connectionString, b => b.MigrationsAssembly("TestApp.WebApi")));

            services.AddAutoMapper(typeof(AppProfile));
            services.AddOpenApiDocument();

            services.AddTransient<IUnitOfWorks, UnitOfWorks>();

            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IOrderService, OrderService>();


            services.AddControllers().AddXmlSerializerFormatters();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseOpenApi(); // serve OpenAPI/Swagger documents
            app.UseSwaggerUi3(); // serve Swagger UI
            app.UseReDoc(x=>x.Path = "/redoc"); // serve ReDoc UI

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
