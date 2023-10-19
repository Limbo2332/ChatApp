namespace ChatApp.Common.Constants
{
    public static class ValidationMessages
    {
        #region Tokens

        public const string AccessTokenIsEmptyMessage = "Access token is required";

        public const string RefreshTokenIsEmptyMessage = "Refresh token is required";

        #endregion

        #region Email

        public const string EmailIsEmptyMessage = "Email is required";
        public const string EmailWithWrongFormatMessage = "Email is in incorrect format";
        public const string EmailIsNotUniqueMessage = "This email is already registered";

        public static string EmailWithWrongMinimumLengthMessage(int length) 
            => $"Email must have at least {length} symbols";

        public static string EmailWithWrongMaximumLengthMessage(int length)
            => $"Email must not exceed {length} symbols";

        #endregion

        #region UserName

        public const string UserNameIsEmptyMessage = "Username is required";
        public const string UsernameWithWrongFormatMessage = "Username must not start or end with spaces";
        public const string UsernameIsNotUniqueMessage = "This username is already registered";

        public static string UserNameWithWrongMinimumLengthMessage(int length)
            => $"Username must have at least {length} symbols";

        public static string UserNameWithWrongMaximumLengthMessage(int length)
            => $"Username must not exceed {length} symbols";

        #endregion

        #region Password

        public const string PasswordIsEmptyMessage = "Password is required";
        public const string PasswordWithWrongFormatMessage = "Password must have at least 1 number, 1 lowercase, 1 uppercase and 1 special character";

        public static string PasswordWithWrongMinimumLengthMessage(int length)
            => $"Password must have at least {length} symbols";

        public static string PasswordWithWrongMaximumLengthMessage(int length)
            => $"Password must not exceed {length} symbols";

        #endregion

        #region Email or UserName

        public const string InvalidUserNameOrEmailMessage = "Invalid username of password";

        #endregion
    }
}
