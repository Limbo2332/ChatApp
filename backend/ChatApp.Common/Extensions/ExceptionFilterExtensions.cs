using ChatApp.Common.Enums;
using ChatApp.Common.Exceptions;
using System.Net;

namespace ChatApp.Common.Extensions
{
    public static class ExceptionFilterExtensions
    {
        public static (HttpStatusCode statusCode, ErrorCode errorCode) ParseException(this Exception exception)
        {
            return exception switch
            {
                BadRequestException _ => (HttpStatusCode.BadRequest, ErrorCode.BadRequest),
                NotFoundException _ => (HttpStatusCode.NotFound, ErrorCode.NotFound),
                InvalidEmailUsernameOrPasswordException _ => (HttpStatusCode.BadRequest, ErrorCode.InvalidUserNameOrPassword),
                InvalidTokenException _ => (HttpStatusCode.Unauthorized, ErrorCode.InvalidToken),
                ExpiredRefreshTokenException _ => (HttpStatusCode.Unauthorized, ErrorCode.ExpiredRefreshToken),
                _ => (HttpStatusCode.InternalServerError, ErrorCode.General)
            };
        }
    }
}
