using ChatApp.Common.Constants;
using ChatApp.Common.DTO.User;
using ChatApp.UnitTests.TestData.Validators.User;
using ChatApp.WebAPI.Validators.User;

namespace ChatApp.UnitTests.Systems.Validators.User
{
    public class UserLoginValidatorTests
    {
        private readonly UserLoginValidator _sut = new UserLoginValidator();

        [Fact]
        public async Task ValidateUserLogin_Should_Fail_WhenWrongData()
        {
            // Arrange
            var userLogin = new UserLoginDto()
            {
                EmailOrUserName = "ffff ",
                Password = string.Empty
            };

            // Act
            var result = await _sut.TestValidateAsync(userLogin);

            // Assert
            result
                .ShouldHaveValidationErrorFor(x => x.EmailOrUserName)
                .WithErrorMessage(ValidationMessages.InvalidUserNameOrEmailMessage);
            result
                .ShouldHaveValidationErrorFor(x => x.Password)
                .WithErrorMessage(ValidationMessages.PasswordIsEmptyMessage);
        }

        [Theory]
        [ClassData(typeof(UserLoginValidatorCorrectData))]
        public async Task ValidateUserLogin_Should_Success_WhenCorrectData(UserLoginDto userLogin)
        {
            // Act
            var result = await _sut.TestValidateAsync(userLogin);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.EmailOrUserName);
            result.ShouldNotHaveValidationErrorFor(x => x.Password);
        }
    }
}
