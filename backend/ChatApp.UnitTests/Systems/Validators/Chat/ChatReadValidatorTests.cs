using ChatApp.Common.Constants;
using ChatApp.Common.DTO.Auth;
using ChatApp.Common.DTO.Chat;
using ChatApp.UnitTests.TestData.Validators.Auth;
using ChatApp.UnitTests.TestData.Validators.Chat;
using ChatApp.WebAPI.Validators.Chat;

namespace ChatApp.UnitTests.Systems.Validators.Chat
{
    public class ChatReadValidatorTests
    {
        private readonly ChatReadValidator _sut = new ChatReadValidator();

        [Fact]
        public async Task ValidateChatRead_Should_Fail_WhenWrongData()
        {
            // Arrange
            var chatRead = new ChatReadDto()
            {
                Id = -5,
                UserId = default
            };

            // Act
            var result = await _sut.TestValidateAsync(chatRead);

            // Assert
            result
                .ShouldHaveValidationErrorFor(x => x.Id)
                .WithErrorMessage(ValidationMessages.ID_IS_EMPTY_MESSAGE);
            result
                .ShouldHaveValidationErrorFor(x => x.UserId)
                .WithErrorMessage(ValidationMessages.USERID_IS_EMPTY_MESSAGE);
        }

        [Theory]
        [ClassData(typeof(ChatReadValidatorCorrectData))]
        public async Task ValidateChatRead_Should_Success_WhenCorrectData(ChatReadDto chatRead)
        {
            // Act
            var result = await _sut.TestValidateAsync(chatRead);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Id);
            result.ShouldNotHaveValidationErrorFor(x => x.UserId);
        }
    }
}
