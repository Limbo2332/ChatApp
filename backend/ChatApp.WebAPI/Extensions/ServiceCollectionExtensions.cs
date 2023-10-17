using ChatApp.DAL.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace ChatApp.WebAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http
                });
            });
        }

        public static void AddJWTAuthentication(this IServiceCollection services, IConfiguration config)
        {
            var validAudience = config.GetRequiredSection("JWT:ProjectName").Value ?? "";
            var validIssuer = config.GetRequiredSection("JWT:Issuer").Value ?? "";
            var signingKey = config.GetRequiredSection("JWT:SigningKey").Value ?? "";

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme =
                opt.DefaultChallengeScheme =
                    JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = validIssuer,
                    ValidAudience = validAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey))
                };
            });
        }

        public static void ConnectToDatabase(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ChatAppContext>(options => 
                options.UseSqlServer(
                    config.GetConnectionString("ChatAppConnection"),
                    options => options.MigrationsAssembly(typeof(ChatAppContext).Assembly.GetName().Name)
                )
            );
        }
    }
}
