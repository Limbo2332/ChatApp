using ChatApp.Common.Security;
using ChatApp.DAL.Entities;
using System.Collections;

namespace ChatApp.UnitTests.TestData
{
    public static class AuthServiceTestData
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
    }
}
