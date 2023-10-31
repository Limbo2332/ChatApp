using ChatApp.DAL.Context;
using ChatApp.UnitTests.TestData;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.UnitTests
{
    public class MockContext
    {
        public ChatAppContext GetContext()
        {
            var options = new DbContextOptionsBuilder<ChatAppContext>()
                .UseInMemoryDatabase(databaseName: $"{Guid.NewGuid()}-FakeDatabase")
                .Options;

            var context = new ChatAppContext(options);

            context.Users.AddRange(DbContextTestData.GetUsers());
            context.RefreshTokens.AddRange(DbContextTestData.GetRefreshTokens());
            context.Chats.AddRange(DbContextTestData.GetChats());
            context.UserChats.AddRange(DbContextTestData.GetUserChats());
            context.Messages.AddRange(DbContextTestData.GetMessages());

            context.SaveChanges();

            return context;
        }
    }
}
