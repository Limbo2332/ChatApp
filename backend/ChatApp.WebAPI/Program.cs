using ChatApp.Common.Filters;
using ChatApp.Common.Middlewares;
using ChatApp.WebAPI.Extensions;
using FluentValidation.AspNetCore;

namespace ChatApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors();

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add(typeof(ValidateFilterAttribute));
                options.Filters.Add(typeof(CustomExceptionFilterAttribute));
            });

            builder.Services.ConnectToDatabase(builder.Configuration);
            builder.Services.AddJWTAuthentication(builder.Configuration);

            builder.Services.RegisterAutoMapper();
            builder.Services.RegisterCustomServices();

            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.RegisterValidators();

            builder.Services.ConfigureSwagger();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(opt => opt
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin());

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.UseChatAppContext();

            app.UseMiddleware<UserIdMiddleware>();

            app.Run();
        }
    }
}