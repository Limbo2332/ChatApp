using ChatApp.Common.DTO.User;

namespace ChatApp.UnitTests.TestData.Validators.User
{
    public class UserLoginValidatorCorrectData : TheoryData<UserLoginDto>
    {
        public UserLoginValidatorCorrectData()
        {
            Add(new UserLoginDto
            {
                EmailOrUserName = "My UserName",
                Password = "passworD1!"
            });
            Add(new UserLoginDto
            {
                EmailOrUserName = "example@gmail.com",
                Password = "passworD1!$"
            });
        }
    }
}
