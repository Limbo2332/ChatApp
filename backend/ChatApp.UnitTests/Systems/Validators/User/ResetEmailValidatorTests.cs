using ChatApp.Common.Constants;
using ChatApp.Common.DTO.Mail;
using ChatApp.Common.DTO.Message;
using ChatApp.UnitTests.TestData.Validators.Chat;
using ChatApp.WebAPI.Validators.User;

namespace ChatApp.UnitTests.Systems.Validators.User
{
    public class ResetEmailValidatorTests
    {
        private readonly ResetEmailValidator _sut = new ResetEmailValidator();

        [Fact]
        public async Task ValidateResetEmail_Should_Fail_WhenWrongData()
        {
            // Arrange
            var resetEmail = new ResetEmailDto
            {
                Email = string.Empty,
            };

            // Act
            var result = await _sut.TestValidateAsync(resetEmail);

            // Assert
            result
                .ShouldHaveValidationErrorFor(x => x.Email)
                .WithErrorMessage(ValidationMessages.EMAIL_IS_EMPTY_MESSAGE);
        }

        [Theory]
        [InlineData("example@gmail.com")]
        [InlineData("somehow@gmail.com")]
        [InlineData("tomorrowbebetter@ukr.com")]
        public async Task ValidateResetEmail_Should_Success_WhenCorrectData(string email)
        {
            // Arrange
            var resetEmail = new ResetEmailDto
            {
                Email = email
            };

            // Act
            var result = await _sut.TestValidateAsync(resetEmail);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Email);
        }
    }
}
