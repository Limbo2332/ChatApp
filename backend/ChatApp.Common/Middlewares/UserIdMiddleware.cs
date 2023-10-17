using ChatApp.Common.Logic.Abstract;
using Microsoft.AspNetCore.Http;

namespace ChatApp.Common.Middlewares
{
    public class UserIdMiddleware
    {
        private readonly RequestDelegate _next;

        public UserIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IUserIdSetter userIdSetter)
        {
            var claimsUserId = context.User.Claims.FirstOrDefault(x => x.Type == "id")?.Value;

            if (claimsUserId is not null && int.TryParse(claimsUserId, out int userId)) 
            { 
                userIdSetter.SetUserId(userId);
            }

            await _next.Invoke(context);
        }
    }
}
