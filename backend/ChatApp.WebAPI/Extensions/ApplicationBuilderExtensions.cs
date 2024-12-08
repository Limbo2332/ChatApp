using ChatApp.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.WebAPI.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseChatAppContext(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();

            using var context = scope?.ServiceProvider.GetRequiredService<ChatAppContext>();

            context?.Database.Migrate();
        }
    }
}
