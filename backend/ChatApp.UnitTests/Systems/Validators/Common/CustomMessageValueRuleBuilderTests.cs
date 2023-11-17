using ChatApp.Common.Constants;
using ChatApp.DAL.Context.SeedSettings;
using ChatApp.WebAPI.Extensions;

namespace ChatApp.UnitTests.Systems.Validators.Common
{
    public class CustomMessageValueRuleBuilderTests
    {
        private readonly InlineValidator<string> _sut;

        public CustomMessageValueRuleBuilderTests()
        {
            _sut = new InlineValidator<string>();
            _sut.RuleFor(x => x)
                .CustomMessageValue();
        }

        [Fact]
        public async Task CustomMessageValue_Should_Fail_WhenMessageValueIsEmpty()
        {
            // Arrange
            var emptyMessageValue = string.Empty;

            // Act
            var result = await _sut.ValidateAsync(emptyMessageValue);

            // Assert
            using (new AssertionScope())
            {
                result.IsValid.Should().BeFalse();
                result.Errors.Should().Contain(x => x.ErrorMessage == ValidationMessages.NewMessageIsEmptyMessage);
            }
        }

        [Fact]
        public async Task CustomMessageValue_Should_Fail_WhenMessageValueMoreThanMaxLength()
        {
            // Arrange
            var message = new string('s', EntityConfigurationSettings.MessageMaxLength + 1);

            // Act
            var result = await _sut.ValidateAsync(message);

            // Assert
            using (new AssertionScope())
            {
                result.IsValid.Should().BeFalse();
                result.Errors.Should().Contain(
                    x => x.ErrorMessage == ValidationMessages.NewMessageMaxLengthMessage);
            }
        }

        [Theory]
        [InlineData("Hello, world!")]
        [InlineData("Correct message!")]
        [InlineData("Easy MessageValue")]
        public async Task CustomMessageValue_Should_Success_WhenCorrectMessageValue(string messageValue)
        {
            // Act
            var result = await _sut.ValidateAsync(messageValue);

            // Assert
            using (new AssertionScope())
            {
                result.IsValid.Should().BeTrue();
                result.Errors.Should().BeEmpty();
            }
        }
    }
}
