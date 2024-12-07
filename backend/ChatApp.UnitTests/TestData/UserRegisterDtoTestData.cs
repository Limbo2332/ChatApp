using ChatApp.Common.DTO.User;

namespace ChatApp.UnitTests.TestData
{
    public class UserRegisterDtoTestData : TheoryData<UserRegisterDto>
    {
        public UserRegisterDtoTestData()
        {
            Add(new UserRegisterDto());
            Add(new UserRegisterDto()
            {
                Email = "correctEmail@gmail.com"
            });
            Add(new UserRegisterDto()
            {
                Email = "correctEmail@gmail.com",
                Password = "correctPassword1!"
            });
            Add(new UserRegisterDto()
            {
                Email = "correctEmail@gmail.com",
                Password = "wrongPass",
                UserName = "correctUserName"
            });
            Add(new UserRegisterDto()
            {
                Email = "wrongEmail",
                Password = "correctPassword1!",
                UserName = "correctUserName"
            });
            Add(new UserRegisterDto()
            {
                Email = "wrongEmail",
                Password = "wrongPass",
                UserName = "correctUserName"
            });
        }
    }
}
