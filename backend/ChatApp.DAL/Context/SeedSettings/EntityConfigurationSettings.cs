namespace ChatApp.DAL.Context.SeedSettings
{
    public static class EntityConfigurationSettings
    {
        public static readonly int UserNameMinLength = 2;
        public static readonly int UserNameMaxLength = 50;

        public static readonly int EmailMinLength = 10;
        public static readonly int EmailMaxLength = 60;

        public static readonly int PasswordMinLength = 8;
        public static readonly int PasswordMaxLength = 24;

        public static readonly int MessageMaxLength = 200;
    }
}
