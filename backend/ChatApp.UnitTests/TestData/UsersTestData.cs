using ChatApp.DAL.Entities;

namespace ChatApp.UnitTests.TestData
{
    public class UsersTestData : TheoryData<User>
    {
        public UsersTestData()
        {
            foreach (var user in DbContextTestData.Users)
            {
                Add(user);
            }
        }
    }
}
