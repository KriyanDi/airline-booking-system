using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Serilog;
using System.Text;
using WebAbsApi.Models;

namespace WebAbsApi
{
    public static class ServiceExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<CoreDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AbsConnection")));
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy("AllowAll", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            //var builder = services.AddIdentityCore<ApiUser>(q => q.User.RequireUniqueEmail = true);

            //builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);
            //builder.AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();
        }

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration Configuration)
        {
            var jwtSettings = Configuration.GetSection("Jwt");
            //var key = Environment.GetEnvironmentVariable("KEY");
            var key = "1236476123t423hgqwkjgfkjshdgkjgfhjg2yu3t46t2386t4twghjgkjwqgekhjgru23t481t2384t123ighjgqjwer";

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.GetSection("Issuer").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                };
            });
        }

        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error => {
                error.Run(async context => {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        Log.Error($"Something Went Wrong in the {contextFeature.Error}");

                        await context.Response.WriteAsync(new Error
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error. Please Try Again Later."
                        }.ToString());
                    }
                });
            });
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAbsApi", Version = "v1" });
            });
        }

        public static void ConfigureControllers(this IServiceCollection services)
        {
            services.AddControllers()
               .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
               .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
        }
    }
}
