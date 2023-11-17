using ChatApp.Common.Constants;
using ChatApp.Common.DTO.Chat;
using ChatApp.UnitTests.TestData.Validators.Chat;
using ChatApp.WebAPI.Validators.Chat;

namespace ChatApp.UnitTests.Systems.Validators.Chat
{
    public class NewChatValidatorTests
    {
        private readonly NewChatValidator _sut = new NewChatValidator();

        [Fact]
        public async Task ValidateNewChat_Should_Fail_WhenWrongData()
        {
            // Arrange
            var newChat = new NewChatDto()
            {
                NewMessage = string.Empty,
                UserName = string.Empty,
            };

            // Act
            var result = await _sut.TestValidateAsync(newChat);

            // Assert
            result
                .ShouldHaveValidationErrorFor(x => x.UserName)
                .WithErrorMessage(ValidationMessages.UserNameIsEmptyMessage);
            result
                .ShouldHaveValidationErrorFor(x => x.NewMessage)
                .WithErrorMessage(ValidationMessages.NewMessageIsEmptyMessage);
        }

        [Theory]
        [ClassData(typeof(NewChatValidatorCorrectTestData))]
        public async Task ValidateNewChat_Should_Success_WhenCorrectData(NewChatDto newChat)
        {
            // Act
            var result = await _sut.TestValidateAsync(newChat);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.UserName);
            result.ShouldNotHaveValidationErrorFor(x => x.NewMessage);
        }
    }
}
