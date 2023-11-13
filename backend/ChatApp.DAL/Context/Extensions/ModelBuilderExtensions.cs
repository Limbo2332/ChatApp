using Bogus;
using Bogus.Extensions;
using ChatApp.Common.Security;
using ChatApp.DAL.Context.EntityConfigurations;
using ChatApp.DAL.Context.SeedSettings;
using ChatApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.DAL.Context.Extensions
{
    public static class ModelBuilderExtensions
    {
        private static readonly DateTime _usedDateTime = new DateTime(2023, 10, 15);
        private static readonly int UsersCount = 40;
        private static readonly int ChatsCount = 40;
        private static readonly int MessagesCount = 50;
        private static readonly int UserChatsCount = 100;

        public static void Configure(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfig).Assembly);
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            var chats = GenerateChats();
            modelBuilder.Entity<Chat>().HasData(chats);

            var users = GenerateUsers();
            modelBuilder.Entity<User>().HasData(users);

            var messages = GenerateMessages(users, chats);
            modelBuilder.Entity<Message>().HasData(messages);

            var userChats = GenerateUserChats(users, chats);
            modelBuilder.Entity<UserChats>().HasData(userChats);
        }
        private static IEnumerable<Chat> GenerateChats()
        {
            Faker.GlobalUniqueIndex = 0;

            return new Faker<Chat>()
                .UseSeed(SeedDefaults.ChatSeed)
                .RuleFor(chat => chat.Id, f => f.IndexGlobal)
                .RuleFor(chat => chat.CreatedAt, f => _usedDateTime)
                .Generate(ChatsCount);
        }

        private static IEnumerable<User> GenerateUsers()
        {
            Faker.GlobalUniqueIndex = 0;

            return new Faker<User>()
                .UseSeed(SeedDefaults.UserSeed)
                .RuleFor(user => user.Id, f => f.UniqueIndex)
                .RuleFor(user => user.CreatedAt, f => _usedDateTime)
                .RuleFor(user => user.Email, f => f.Internet.Email()
                    .ClampLength(EntityConfigurationSettings.EmailMinLength, EntityConfigurationSettings.EmailMaxLength))
                .RuleFor(user => user.UserName, f => f.Internet.UserName()
                    .ClampLength(EntityConfigurationSettings.UserNameMinLength, EntityConfigurationSettings.UserNameMaxLength))
                .RuleFor(user => user.Salt, f => Convert.ToBase64String(SecurityHelper.GetSeedingBytes()))
                .RuleFor(user => user.Password, (f, user) => SecurityHelper.HashPassword(f.Internet.Password()
                    .ClampLength(
                        EntityConfigurationSettings.PasswordMinLength,
                        EntityConfigurationSettings.PasswordMaxLength
                     ),
                         Convert.FromBase64String(user.Salt)))
                .Generate(UsersCount);
        }

        private static IEnumerable<Message> GenerateMessages(IEnumerable<User> users, IEnumerable<Chat> chats)
        {
            Faker.GlobalUniqueIndex = 0;

            return new Faker<Message>()
                .UseSeed(SeedDefaults.MessageSeed)
                .RuleFor(message => message.Id, f => f.IndexGlobal)
                .RuleFor(message => message.CreatedAt, f => _usedDateTime)
                .RuleFor(message => message.Value, f => f.Lorem.Sentence())
                .RuleFor(message => message.UserId, f => f.PickRandom(users).Id)
                .RuleFor(message => message.ChatId, f => f.PickRandom(chats).Id)
                .RuleFor(message => message.IsRead, f => true)
                .Generate(MessagesCount);
        }

        private static IEnumerable<UserChats> GenerateUserChats(IEnumerable<User> users, IEnumerable<Chat> chats)
        {
            return new Faker<UserChats>()
                .UseSeed(SeedDefaults.UserChatsSeed)
                .RuleFor(userMessage => userMessage.UserId, f => f.PickRandom(users).Id)
                .RuleFor(userMessage => userMessage.ChatId, f => f.PickRandom(chats).Id)
                .Generate(UserChatsCount)
                .GroupBy(userMessage => userMessage.ChatId)
                .Where(group => group.Count() == 2)
                .SelectMany(group => group);
        }
    }
}
