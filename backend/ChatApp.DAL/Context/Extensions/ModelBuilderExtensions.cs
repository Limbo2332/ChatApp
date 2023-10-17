using Bogus;
using Bogus.Extensions;
using ChatApp.Common.Enums;
using ChatApp.Common.Security;
using ChatApp.DAL.Context.EntityConfigurations;
using ChatApp.DAL.Context.SeedSettings;
using ChatApp.DAL.Entities;
using ChatApp.DAL.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;

namespace ChatApp.DAL.Context.Extensions
{
    public static class ModelBuilderExtensions
    {
        private static readonly DateTime _usedDateTime = new DateTime(2023, 10, 15);
        private static readonly int UsersCount = 20;
        private static readonly int ChatsCount = 30;
        private static readonly int MessagesCount = 200;
        private static readonly int UserChatsCount = 100;
        private static readonly int UserMessagesCount = 50;

        public static void Configure(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfig).Assembly);
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            var users = GenerateUsers();
            modelBuilder.Entity<User>().HasData(users);

            var chats = GenerateChats();
            modelBuilder.Entity<Chat>().HasData(chats);

            var messages = GenerateMessages(chats);
            modelBuilder.Entity<Message>().HasData(messages);

            var userChats = GenerateUserChats(users, chats);
            modelBuilder.Entity<UserChats>().HasData(userChats);

            var userMessages = GenerateUserMessages(userChats.Select(uc => uc.UserId), messages);
            modelBuilder.Entity<UserMessages>().HasData(userMessages);
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
                .RuleFor(user => user.Password, f => SecurityHelper.HashPassword(f.Internet.Password()
                    .ClampLength(
                        EntityConfigurationSettings.PasswordMinLength,
                        EntityConfigurationSettings.PasswordMaxLength
                     ),
                        SecurityHelper.GetSeedingBytes()))
                .Generate(UsersCount);
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

        private static IEnumerable<Message> GenerateMessages(IEnumerable<Chat> chats)
        {
            Faker.GlobalUniqueIndex = 0;

            return new Faker<Message>()
                .UseSeed(SeedDefaults.MessageSeed)
                .RuleFor(message => message.Id, f => f.IndexGlobal)
                .RuleFor(message => message.CreatedAt, f => _usedDateTime)
                .RuleFor(message => message.Value, f => f.Lorem.Sentence())
                .RuleFor(message => message.MessageStatus, f => f.PickRandom<MessageStatus>())
                .RuleFor(message => message.ChatId, f => f.PickRandom(chats).Id)
                .Generate(MessagesCount);
        }

        private static IEnumerable<UserChats> GenerateUserChats(IEnumerable<User> users, IEnumerable<Chat> chats)
        {
            Faker.GlobalUniqueIndex = 0;

            return new Faker<UserChats>()
                .UseSeed(SeedDefaults.UserChatsSeed)
                .RuleFor(userChart => userChart.Id, f => f.IndexGlobal)
                .RuleFor(userChart => userChart.CreatedAt, f => _usedDateTime)
                .RuleFor(userChart => userChart.UserId, f => f.PickRandom(users).Id)
                .RuleFor(userChart => userChart.ChatId, f => f.PickRandom(chats).Id)
                .RuleFor(userChart => userChart.IsSender, f => f.Random.Bool())
                .Generate(UserChatsCount)
                .GroupBy(userChart => userChart.ChatId)
                .Where(group => group.Count() == 2 && group.DistinctBy(g => g.IsSender).Count() == 2)
                .SelectMany(group => group);
        }

        private static IEnumerable<UserMessages> GenerateUserMessages(IEnumerable<int> userIds, IEnumerable<Message> messages)
        {
            Faker.GlobalUniqueIndex = 0;

            return new Faker<UserMessages>()
                .UseSeed(SeedDefaults.UserMessagesSeed)
                .RuleFor(userMessages => userMessages.Id, f => f.IndexGlobal)
                .RuleFor(userMessages => userMessages.CreatedAt, f => _usedDateTime)
                .RuleFor(userMessages => userMessages.UserId, f => f.PickRandom(userIds))
                .RuleFor(userMessages => userMessages.MessageId, f => f.PickRandom(messages).Id)
                .RuleFor(userMessages => userMessages.IsSender, f => f.Random.Bool())
                .Generate(UserMessagesCount);
        }
    }
}
