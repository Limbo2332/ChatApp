using ChatApp.Common.Constants;
using ChatApp.Common.DTO.Chat;
using ChatApp.Common.DTO.Message;
using ChatApp.UnitTests.TestData.Validators.Chat;
using ChatApp.WebAPI.Validators.Chat;

namespace ChatApp.UnitTests.Systems.Validators.Chat
{
    public class NewMessageValidatorTests
    {
        private readonly NewMessageValidator _sut = new NewMessageValidator();

        [Fact]
        public async Task ValidateNewMessage_Should_Fail_WhenWrongData()
        {
            // Arrange
            var newChat = new NewMessageDto()
            {
                ChatId = -1,
                Value = string.Empty
            };

            // Act
            var result = await _sut.TestValidateAsync(newChat);

            // Assert
            result
                .ShouldHaveValidationErrorFor(x => x.ChatId)
                .WithErrorMessage(ValidationMessages.ChatIsNullMessage);
            result
                .ShouldHaveValidationErrorFor(x => x.Value)
                .WithErrorMessage(ValidationMessages.NewMessageIsEmptyMessage);
        }

        [Theory]
        [ClassData(typeof(NewMessageValidatorCorrectData))]
        public async Task ValidateNewMessage_Should_Success_WhenCorrectData(NewMessageDto newMessage)
        {
            // Act
            var result = await _sut.TestValidateAsync(newMessage);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.ChatId);
            result.ShouldNotHaveValidationErrorFor(x => x.Value);
        }
    }
}
