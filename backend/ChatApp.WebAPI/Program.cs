using ChatApp.BLL.Hubs;
using ChatApp.Common.Filters;
using ChatApp.Common.Middlewares;
using ChatApp.WebAPI.Extensions;
using FluentValidation.AspNetCore;

namespace ChatApp.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options => options.AddPolicy("ChatPolicy", config =>
            {
                config
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins("http://localhost:4200")
                    .AllowCredentials();
            }));

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add(typeof(ValidateFilterAttribute));
                options.Filters.Add(typeof(CustomExceptionFilterAttribute));
            });

            builder.Services.ConnectToDatabase(builder.Configuration);
            builder.Services.AddJwtAuthentication(builder.Configuration);

            builder.Services.RegisterAzureServices(builder.Configuration);

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

            app.UseChatAppContext();

            app.UseMiddleware<UserIdMiddleware>();

            app.MapHub<ChatHub>("/chatHub");

            app.Run();
        }
    }
}