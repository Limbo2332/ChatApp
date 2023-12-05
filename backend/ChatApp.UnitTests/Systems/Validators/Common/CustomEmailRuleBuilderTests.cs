using ChatApp.Common.Constants;
using ChatApp.DAL.Context.SeedSettings;
using ChatApp.WebAPI.Extensions;

namespace ChatApp.UnitTests.Systems.Validators.Common
{
    public class CustomEmailRuleBuilderTests
    {
        private readonly InlineValidator<string> _sut;

        public CustomEmailRuleBuilderTests()
        {
            _sut = new InlineValidator<string>();
            _sut.RuleFor(x => x)
                .CustomEmail();
        }

        [Fact]
        public async Task CustomEmail_Should_Fail_WhenEmailIsEmpty()
        {
            // Arrange
            var emptyEmail = string.Empty;

            // Act
            var result = await _sut.ValidateAsync(emptyEmail);

            // Assert
            using (new AssertionScope())
            {
                result.IsValid.Should().BeFalse();
                result.Errors.Should().Contain(x => x.ErrorMessage == ValidationMessages.EMAIL_IS_EMPTY_MESSAGE);
            }
        }

        [Fact]
        public async Task CustomEmail_Should_Fail_WhenEmailLessThanMinLength()
        {
            // Arrange
            var email = new string('s', EntityConfigurationSettings.EmailMinLength - 1);

            // Act
            var result = await _sut.ValidateAsync(email);

            // Assert
            using (new AssertionScope())
            {
                result.IsValid.Should().BeFalse();
                result.Errors.Should().Contain(
                    x => x.ErrorMessage == ValidationMessages
                        .EmailWithWrongMinimumLengthMessage(EntityConfigurationSettings.EmailMinLength));
            }
        }

        [Fact]
        public async Task CustomEmail_Should_Fail_WhenEmailMoreThanMaxLength()
        {
            // Arrange
            var email = new string('s', EntityConfigurationSettings.EmailMaxLength + 1);

            // Act
            var result = await _sut.ValidateAsync(email);

            // Assert
            using (new AssertionScope())
            {
                result.IsValid.Should().BeFalse();
                result.Errors.Should().Contain(
                    x => x.ErrorMessage == ValidationMessages
                        .EmailWithWrongMaximumLengthMessage(EntityConfigurationSettings.EmailMaxLength));
            }
        }

        [Theory]
        [InlineData("example.gmail.com")]
        [InlineData("example@gmailcom")]
        [InlineData("@gmail.com")]
        [InlineData("example@gmail.c")]
        public async Task CustomEmail_Should_Fail_WhenEmailNotInCorrectFormat(string email)
        {
            // Act
            var result = await _sut.ValidateAsync(email);

            // Assert
            using (new AssertionScope())
            {
                result.IsValid.Should().BeFalse();
                result.Errors.Should().Contain(
                    x => x.ErrorMessage == ValidationMessages.EMAIL_WITH_WRONG_FORMAT_MESSAGE);
            }
        }

        [Theory]
        [InlineData("example@gmail.com")]
        [InlineData("example@hotline.com")]
        [InlineData("babay@ukr.net")]
        [InlineData("example@lll.kpi.ua")]
        public async Task CustomEmail_Should_Success_WhenCorrectEmail(string email)
        {
            // Act
            var result = await _sut.ValidateAsync(email);

            // Assert
            using (new AssertionScope())
            {
                result.IsValid.Should().BeTrue();
                result.Errors.Should().BeEmpty();
            }
        }
    }
}
