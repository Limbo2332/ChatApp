using ChatApp.Common.Security;
using ChatApp.DAL.Entities;

namespace ChatApp.UnitTests.TestData
{
    public static class DbContextTestData
    {
        public static List<User> Users => new List<User>()
        {
            new User
            {
                Id = 1,
                CreatedAt = DateTime.Now,
                Email = "Test@gmail.com",
                UserName = "TestUserName",
                Password = SecurityHelper.HashPassword("Test123!$", Convert.FromBase64String("Test")),
                Salt = "Test",
                ImagePath = null,
            },
            new User
            {
                Id = 2,
                CreatedAt = DateTime.Now,
                Email = "Test1@gmail.com",
                UserName = "TestUserName1",
                Password = SecurityHelper.HashPassword("Test1231!$", Convert.FromBase64String("Test")),
                Salt = "Test",
                ImagePath = "testImagePath",
            },
            new User
            {
                Id = 3,
                CreatedAt = DateTime.Now,
                Email = "Test123@gmail.com",
                UserName = "TestUserName123",
                Password = SecurityHelper.HashPassword("Test123123!$", Convert.FromBase64String("Test")),
                Salt = "Test",
                ImagePath = null,
            },
            new User
            {
                Id = 4,
                CreatedAt = DateTime.Now,
                Email = "Test1234@gmail.com",
                UserName = "TestUserName1234",
                Password = SecurityHelper.HashPassword("Test123123123!$", Convert.FromBase64String("Test")),
                Salt = "Test",
                ImagePath = null,
            },
        };

        public static List<RefreshToken> RefreshTokens => new List<RefreshToken>()
        {
            new RefreshToken
            {
                Id = 1,
                Token = "IRJfqo8zc1/rIjLqiBkAm5Q7+V5tG1YRhsZo5QOxNlc=",
                UserId = 1,
            },
            new RefreshToken
            {
                Id = 2,
                Token = "GCVLM7jOUf6BQSDOniRapArEDTpdkVGAKuxOrgrm+Xc=",
                UserId = 1,
                Expires = DateTime.UtcNow.AddDays(-5)
            },
        };

        public static List<Chat> Chats => new List<Chat>()
        {
            new Chat
            {
                Id = 1,
            },
            new Chat
            {
                Id = 2,
            }
        };

        public static List<UserChats> UserChats => new List<UserChats>()
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

        public static List<Message> Messages => new List<Message>()
        {
            new Message
            {
                Id = 1,
                ChatId = 1,
                IsRead = true,
                UserId = 2,
                Value = "Hello. I see!",
                CreatedAt = DateTime.UtcNow.AddDays(-1),
            },
            new Message
            {
                Id = 2,
                ChatId = 1,
                IsRead = true,
                UserId = 1,
                Value = "Hello. It's test!",
                CreatedAt = DateTime.UtcNow.AddDays(-1),
            },
            new Message
            {
                Id = 3,
                ChatId = 1,
                IsRead = false,
                UserId = 1,
                Value = "Hello. It's not test!",
                CreatedAt = DateTime.UtcNow,
            },
            new Message
            {
                Id = 4,
                ChatId = 2,
                IsRead = false,
                UserId = 1,
                Value = "Hello. It's my test!",
                CreatedAt = DateTime.UtcNow,
            },
            new Message
            {
                Id = 5,
                ChatId = 2,
                IsRead = false,
                UserId = 1,
                Value = "Hello. It's not my test!",
                CreatedAt = DateTime.UtcNow,
            },
        };
    }
}
