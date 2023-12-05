using ChatApp.Common.Constants;
using ChatApp.Common.DTO.Mail;
using ChatApp.Common.DTO.User;
using ChatApp.UnitTests.TestData.Validators.User;
using ChatApp.WebAPI.Validators.User;

namespace ChatApp.UnitTests.Systems.Validators.User
{
    public class UserEditValidatorTests
    {
        private readonly UserEditValidator _sut = new UserEditValidator();

        [Fact]
        public async Task ValidateUserEdit_Should_Fail_WhenWrongData()
        {
            // Arrange
            var userEdit = new UserEditDto()
            {
                Email = string.Empty,
                UserName = string.Empty,
            };

            // Act
            var result = await _sut.TestValidateAsync(userEdit);

            // Assert
            result
                .ShouldHaveValidationErrorFor(x => x.Email)
                .WithErrorMessage(ValidationMessages.EMAIL_IS_EMPTY_MESSAGE);
            result
                .ShouldHaveValidationErrorFor(x => x.UserName)
                .WithErrorMessage(ValidationMessages.UserNameIsEmptyMessage);
        }

        [Theory]
        [ClassData(typeof(UserEditValidatorCorrectData))]
        public async Task ValidateUserEdit_Should_Success_WhenCorrectData(UserEditDto userEdit)
        {
            // Act
            var result = await _sut.TestValidateAsync(userEdit);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Email);
            result.ShouldNotHaveValidationErrorFor(x => x.UserName);
        }
    }
}
