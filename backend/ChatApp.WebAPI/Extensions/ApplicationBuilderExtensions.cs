using ChatApp.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.WebAPI.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseChatAppContext(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var db = scope.ServiceProvider.GetRequiredService<ChatAppContext>();
            db.Database.Migrate();
        }
    }
}
