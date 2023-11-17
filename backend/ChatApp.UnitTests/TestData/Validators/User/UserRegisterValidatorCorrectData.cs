using ChatApp.Common.DTO.User;

namespace ChatApp.UnitTests.TestData.Validators.User
{
    public class UserRegisterValidatorCorrectData : TheoryData<UserRegisterDto>
    {
        public UserRegisterValidatorCorrectData()
        {
            Add(new UserRegisterDto
            {
                UserName = "My UserName",
                Email = "example@gmail.com",
                Password = "passworD1$"
            });
            Add(new UserRegisterDto
            {
                UserName = "Unique UserName",
                Email = "unique@gmail.com",
                Password = "passworD1$1"
            });
        }
    }
}
