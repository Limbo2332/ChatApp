namespace ChatApp.Common.Constants
{
    public static class ValidationMessages
    {
        #region Tokens

        public const string AccessTokenIsEmptyMessage = "Access token is required";

        public const string RefreshTokenIsEmptyMessage = "Refresh token is required";

        #endregion

        #region Email

        public const string EMAIL_IS_EMPTY_MESSAGE = "Email is required";
        public const string EMAIL_WITH_WRONG_FORMAT_MESSAGE = "Email is in incorrect format";
        public const string EMAIL_IS_NOT_UNIQUE_MESSAGE = "This email is already registered";
        public const string EMAIL_TOKEN_IS_EMPTY = "Email token is required";

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
        public const string PasswordAreNotTheSame = "Passwords are not the same";

        public static string PasswordWithWrongMinimumLengthMessage(int length)
            => $"Password must have at least {length} symbols";

        public static string PasswordWithWrongMaximumLengthMessage(int length)
            => $"Password must not exceed {length} symbols";

        #endregion

        #region Email or UserName

        public const string InvalidUserNameOrEmailMessage = "Invalid username of password";

        #endregion

        #region NewMessage

        public const string NewMessageIsEmptyMessage = "Message cannot be empty";
        public const string NewMessageMaxLengthMessage = "Message is too long";
        public const string ChatIsNullMessage = "Chat id is required";

        #endregion
    }
}
