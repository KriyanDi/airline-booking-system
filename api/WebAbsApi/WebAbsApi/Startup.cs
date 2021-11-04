using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebAbsApi.Configurations;
using WebAbsApi.IRepository;
using WebAbsApi.Repository;
using Newtonsoft.Json.Serialization;
using WebAbsApi.Context;
using WebAbsApi.Contracts;

namespace WebAbsApi
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
            // Database context
            services.ConfigureDbContext(Configuration);

            //IdentityUser
            services.AddAuthentication();
            services.ConfigureIdentity();
            services.ConfigureJWT(Configuration);

            // AutoMapper
            services.AddAutoMapper(typeof(MapperInitializer));

            //Dapper
            services.AddSingleton<DapperContext>();

            //Repository
            services.AddScoped<IAbsRepository, AbsRepository>();

            // Transient
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IAuthManager, AuthManager>();

            // CORS
            services.ConfigureCors();

            // Swagger 
            services.ConfigureSwagger();

            // Controllers
            services.ConfigureControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AbsWepApi v1"));

            // Global Exception Handler
            app.ConfigureExceptionHandler();

            app.UseHttpsRedirection();

            // CORS
            app.UseCors("AllowAll");

            app.UseRouting();

            //Auth
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
