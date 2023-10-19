namespace ChatApp.Common.Enums
{
    public enum ErrorCode
    {
        General = 1,
        NotFound,
        InvalidUserNameOrPassword,
        InvalidToken,
        ExpiredRefreshToken
    }
}
