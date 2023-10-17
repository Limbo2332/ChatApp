
using ChatApp.WebAPI.Extensions;

namespace ChatApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.ConfigureSwagger();

            builder.Services.AddJWTAuthentication(builder.Configuration);
            builder.Services.ConnectToDatabase(builder.Configuration);

            builder.Services.RegisterAutoMapper();
            builder.Services.RegisterCustomServices();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.UseChatAppContext();

            app.Run();
        }
    }
}