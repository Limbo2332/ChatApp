using Azure.Communication.Email;
using Azure.Storage.Blobs;
using ChatApp.BLL.Interfaces;
using ChatApp.BLL.Interfaces.Auth;
using ChatApp.BLL.MappingProfiles;
using ChatApp.BLL.Services;
using ChatApp.BLL.Services.Auth;
using ChatApp.Common.DTO.Auth;
using ChatApp.Common.DTO.Chat;
using ChatApp.Common.DTO.Message;
using ChatApp.Common.DTO.User;
using ChatApp.Common.Logic;
using ChatApp.Common.Logic.Abstract;
using ChatApp.DAL.Context;
using ChatApp.WebAPI.Validators.Auth;
using ChatApp.WebAPI.Validators.Chat;
using ChatApp.WebAPI.Validators.User;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
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
            var validAudience = config.GetRequiredSection("JWT:Audience").Value ?? "";
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

        public static void RegisterAzureServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton(_ =>
            {
                return new BlobServiceClient(config.GetValue<string>("BlobStorage:ConnectionString"))
                    .GetBlobContainerClient(config.GetValue<string>("BlobStorage:ContainerName"));
            });

            services.AddScoped(_ =>
            {
                return new EmailClient(config.GetValue<string>("EmailService:ConnectionString"));
            });
        }

        public static void RegisterUserStorageServices(this IServiceCollection services)
        {
            services.AddScoped<UserIdStorage>();
            services.AddTransient<IUserIdSetter>(s => s.GetRequiredService<UserIdStorage>());
            services.AddTransient<IUserIdGetter>(s => s.GetRequiredService<UserIdStorage>());
        }

        public static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<ChatsProfile>();
            }, Assembly.GetAssembly(typeof(UserProfile)));
        }

        public static void RegisterCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IBlobStorageService, BlobStorageService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IChatService, ChatService>();
        }

        public static void RegisterValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<UserRegisterDto>, UserRegisterValidator>();
            services.AddScoped<IValidator<UserLoginDto>, UserLoginValidator>();
            services.AddScoped<IValidator<UserEditDto>, UserEditValidator>();
            services.AddScoped<IValidator<AccessTokenDto>, AccessTokenValidator>();
            services.AddScoped<IValidator<NewMessageDto>, NewMessageValidator>();
            services.AddScoped<IValidator<NewChatDto>, NewChatValidator>();
            services.AddScoped<IValidator<ChatReadDto>, ChatReadValidator>();
        }
    }
}
