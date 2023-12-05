using ChatApp.Common.Constants;
using ChatApp.Common.DTO.Mail;
using ChatApp.Common.DTO.User;
using ChatApp.UnitTests.TestData.Validators.User;
using ChatApp.WebAPI.Validators.User;

namespace ChatApp.UnitTests.Systems.Validators.User
{
    public class ResetPasswordValidatorTests
    {
        private readonly ResetPasswordValidator _sut = new ResetPasswordValidator();

        [Fact]
        public async Task ValidateResetPassword_Should_Fail_WhenWrongData()
        {
            // Arrange
            var resetPassword = new ResetPasswordDto
            {
                Email = string.Empty,
                NewPassword = string.Empty,
                ConfirmPassword = string.Empty,
                EmailToken = string.Empty
            };

            // Act
            var result = await _sut.TestValidateAsync(resetPassword);

            // Assert
            result
                .ShouldHaveValidationErrorFor(x => x.Email)
                .WithErrorMessage(ValidationMessages.EMAIL_IS_EMPTY_MESSAGE);
            result
                .ShouldHaveValidationErrorFor(x => x.NewPassword)
                .WithErrorMessage(ValidationMessages.PasswordIsEmptyMessage);
            result
                .ShouldHaveValidationErrorFor(x => x.ConfirmPassword)
                .WithErrorMessage(ValidationMessages.PasswordIsEmptyMessage);
            result
                .ShouldHaveValidationErrorFor(x => x.EmailToken)
                .WithErrorMessage(ValidationMessages.EMAIL_TOKEN_IS_EMPTY);
        }

        [Fact]
        public async Task ValidateResetPassword_Should_Fail_WhenNotEqualPasswords()
        {
            // Arrange
            var resetPassword = new ResetPasswordDto
            {
                Email = "example@gmail.com",
                NewPassword = "newPassword",
                ConfirmPassword = "confirmPassword",
                EmailToken = "emailToken"
            };

            // Act
            var result = await _sut.TestValidateAsync(resetPassword);

            // Assert
            result
                .ShouldHaveValidationErrorFor(x => x.ConfirmPassword)
                .WithErrorMessage(ValidationMessages.PasswordAreNotTheSame);
        }

        [Theory]
        [ClassData(typeof(ResetPasswordValidatorCorrectData))]
        public async Task ValidateResetPassword_Should_Success_WhenCorrectData(ResetPasswordDto resetPassword)
        {
            // Act
            var result = await _sut.TestValidateAsync(resetPassword);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Email);
            result.ShouldNotHaveValidationErrorFor(x => x.NewPassword);
            result.ShouldNotHaveValidationErrorFor(x => x.ConfirmPassword);
            result.ShouldNotHaveValidationErrorFor(x => x.EmailToken);
        }
    }
}
