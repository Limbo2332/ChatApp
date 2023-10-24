namespace ChatApp.Common.Constants
{
    public static class Regexes
    {
        public const string EmailRegex = @"^(([^<>()[\]\\.,;:\s@']+(\.[^<>()[\]\\.,;:\s@']+)*)|('.+'))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$";
        public const string NoSpacesRegex = @"^(?!\s)(.*\S)?(?<!\s)$";
        public const string PasswordRegex = @"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*\W)(?!.* ).{1,}$";
    }
}
