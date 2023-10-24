namespace ChatApp.Common.Exceptions
{
    public class ExpiredRefreshTokenException : Exception
    {
        public ExpiredRefreshTokenException() : base("Refresh token expired.") { }
    }
}
