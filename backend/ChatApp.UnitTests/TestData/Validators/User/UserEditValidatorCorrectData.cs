using ChatApp.Common.DTO.User;

namespace ChatApp.UnitTests.TestData.Validators.User
{
    public class UserEditValidatorCorrectData : TheoryData<UserEditDto>
    {
        public UserEditValidatorCorrectData()
        {
            Add(new UserEditDto
            {
                UserName = "My UserName",
                Email = "Example@gmail.com"
            });
            Add(new UserEditDto
            {
                UserName = "My UserName Is Unique",
                Email = "Example123@gmail.com"
            });
        }
    }
}
