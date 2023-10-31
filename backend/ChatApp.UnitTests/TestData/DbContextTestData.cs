using ChatApp.Common.Security;
using ChatApp.DAL.Entities;
using System.Collections;

namespace ChatApp.UnitTests.TestData
{
    public static class DbContextTestData
    {
        public static List<User> GetUsers()
        {
            return new List<User>()
            {
                new User
                {
                    Email = "Test@gmail.com",
                    UserName = "TestUserName",
                    Password = SecurityHelper.HashPassword("Test123!$", Convert.FromBase64String("Test")),
                    Salt = "Test",
                    ImagePath = null,
                },
                new User
                {
                    Email = "Test1@gmail.com",
                    UserName = "TestUserName1",
                    Password = SecurityHelper.HashPassword("Test1231!$", Convert.FromBase64String("Test")),
                    Salt = "Test",
                    ImagePath = "testImagePath",
                },
                new User
                {
                    Email = "Test123@gmail.com",
                    UserName = "TestUserName123",
                    Password = SecurityHelper.HashPassword("Test123123!$", Convert.FromBase64String("Test")),
                    Salt = "Test",
                    ImagePath = null,
                },
                new User
                {
                    Email = "Test1234@gmail.com",
                    UserName = "TestUserName1234",
                    Password = SecurityHelper.HashPassword("Test123123123!$", Convert.FromBase64String("Test")),
                    Salt = "Test",
                    ImagePath = null,
                },
            };
        }

        public static List<RefreshToken> GetRefreshTokens()
        {
            return new List<RefreshToken>()
            {
                new RefreshToken
                {
                    Token = "IRJfqo8zc1/rIjLqiBkAm5Q7+V5tG1YRhsZo5QOxNlc=",
                    UserId = 1,
                },
                new RefreshToken
                {
                    Token = "GCVLM7jOUf6BQSDOniRapArEDTpdkVGAKuxOrgrm+Xc=",
                    UserId = 1,
                    Expires = DateTime.UtcNow.AddDays(-5)
                },
            };
        }

        public static List<Chat> GetChats()
        {
            return new List<Chat>()
            {
                new Chat(),
                new Chat()
            };
        }

        public static List<UserChats> GetUserChats()
        {
            return new List<UserChats>()
            {
                new UserChats
                {
                    ChatId = 1,
                    UserId = 1,
                },
                new UserChats
                {
                    ChatId = 1,
                    UserId = 2
                },
                new UserChats
                {
                    ChatId = 2,
                    UserId = 1
                },
                new UserChats
                {
                    ChatId = 2,
                    UserId = 3
                }
            };
        }

        public static List<Message> GetMessages()
        {
            return new List<Message>()
            {
                new Message
                {
                    ChatId = 1,
                    IsRead = true,
                    UserId = 2,
                    Value = "Hello. I see!",
                    CreatedAt = DateTime.UtcNow.AddDays(-1),
                },
                new Message
                {
                    ChatId = 1,
                    IsRead = true,
                    UserId = 1,
                    Value = "Hello. It's test!",
                    CreatedAt = DateTime.UtcNow.AddDays(-1),
                },
                new Message
                {
                    ChatId = 1,
                    IsRead = false,
                    UserId = 1,
                    Value = "Hello. It's not test!",
                    CreatedAt = DateTime.UtcNow,
                },
                new Message
                {
                    ChatId = 2,
                    IsRead = false,
                    UserId = 1,
                    Value = "Hello. It's my test!",
                    CreatedAt = DateTime.UtcNow,
                },
                new Message
                {
                    ChatId = 2,
                    IsRead = false,
                    UserId = 1,
                    Value = "Hello. It's not my test!",
                    CreatedAt = DateTime.UtcNow,
                },
            };
        }
    }
}
