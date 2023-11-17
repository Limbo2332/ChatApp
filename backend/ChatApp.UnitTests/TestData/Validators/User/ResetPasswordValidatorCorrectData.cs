using ChatApp.Common.DTO.User;

namespace ChatApp.UnitTests.TestData.Validators.User
{
    public class ResetPasswordValidatorCorrectData : TheoryData<ResetPasswordDto>
    {
        public ResetPasswordValidatorCorrectData()
        {
            Add(new ResetPasswordDto
            {
                Email = "example@gmail.com",
                NewPassword = "passworD1$",
                ConfirmPassword = "passworD1$",
                EmailToken = "token"
            });
            Add(new ResetPasswordDto
            {
                Email = "example@ukr.com",
                NewPassword = "passwordsAreSame123$!",
                ConfirmPassword = "passwordsAreSame123$!",
                EmailToken = "emailToken"
            });
        }
    }
}
