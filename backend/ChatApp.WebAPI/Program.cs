using ChatApp.BLL.Hubs;
using ChatApp.Common.Filters;
using ChatApp.Common.Middlewares;
using ChatApp.WebAPI.Extensions;
using DotNetEnv;
using FluentValidation.AspNetCore;

namespace ChatApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Env.Load();
            Env.TraversePath().Load();

            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options => options.AddPolicy("ChatPolicy", builder =>
            {
                builder.AllowAnyMethod()
                       .AllowAnyHeader()
                       .WithOrigins("http://localhost:4200")
                       .AllowCredentials();
            }));

            var configuration = builder.Configuration
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile($"appsettings.json", optional: false, true)
             .AddJsonFile($"appsettings.{env}.json", optional: true, true)
             .AddEnvironmentVariables()
             .Build();

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add(typeof(ValidateFilterAttribute));
                options.Filters.Add(typeof(CustomExceptionFilterAttribute));
            });

            builder.Services.AddLogging(logging =>
            {
                logging.AddConsole();
                logging.AddDebug();
            });

            builder.Services.ConnectToSqlDatabase(configuration);
            builder.Services.ConnectToMongoDatabase();
            builder.Services.AddJWTAuthentication(configuration);

            builder.Services.RegisterAzureServices(configuration);

            builder.Services.RegisterUserStorageServices();
            builder.Services.RegisterAutoMapper();
            builder.Services.RegisterRepositories();
            builder.Services.RegisterCustomServices();

            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.RegisterValidators();

            builder.Services.AddSignalR();

            builder.Services.ConfigureSwagger();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("ChatPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.UseMiddleware<UserIdMiddleware>();

            app.MapHub<ChatHub>("/chatHub");

            app.UseChatAppContext();

            app.Run();
        }
    }
}