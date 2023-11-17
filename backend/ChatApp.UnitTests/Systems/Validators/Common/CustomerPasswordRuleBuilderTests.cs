using ChatApp.Common.Constants;
using ChatApp.DAL.Context.SeedSettings;
using ChatApp.WebAPI.Extensions;

namespace ChatApp.UnitTests.Systems.Validators.Common
{
    public class CustomerPasswordRuleBuilderTests
    {
        private readonly InlineValidator<string> _sut;

        public CustomerPasswordRuleBuilderTests()
        {
            _sut = new InlineValidator<string>();
            _sut.RuleFor(x => x)
                .CustomPassword();
        }

        [Fact]
        public async Task CustomPassword_Should_Fail_WhenPasswordIsEmpty()
        {
            // Arrange
            var emptyPassword = string.Empty;

            // Act
            var result = await _sut.ValidateAsync(emptyPassword);

            // Assert
            using (new AssertionScope())
            {
                result.IsValid.Should().BeFalse();
                result.Errors.Should().Contain(x => x.ErrorMessage == ValidationMessages.PasswordIsEmptyMessage);
            }
        }

        [Fact]
        public async Task CustomPassword_Should_Fail_WhenPasswordLessThanMinLength()
        {
            // Arrange
            var password = new string('s', EntityConfigurationSettings.PasswordMinLength - 1);

            // Act
            var result = await _sut.ValidateAsync(password);

            // Assert
            using (new AssertionScope())
            {
                result.IsValid.Should().BeFalse();
                result.Errors.Should().Contain(
                    x => x.ErrorMessage == ValidationMessages
                        .PasswordWithWrongMinimumLengthMessage(EntityConfigurationSettings.PasswordMinLength));
            }
        }

        [Fact]
        public async Task CustomPassword_Should_Fail_WhenPasswordMoreThanMaxLength()
        {
            // Arrange
            var password = new string('s', EntityConfigurationSettings.PasswordMaxLength + 1);

            // Act
            var result = await _sut.ValidateAsync(password);

            // Assert
            using (new AssertionScope())
            {
                result.IsValid.Should().BeFalse();
                result.Errors.Should().Contain(
                    x => x.ErrorMessage == ValidationMessages
                        .PasswordWithWrongMaximumLengthMessage(EntityConfigurationSettings.PasswordMaxLength));
            }
        }

        [Theory]
        [InlineData("12345678")]
        [InlineData("12345678aaa")]
        [InlineData("12345678aaaAAA")]
        [InlineData("12345678AAA")]
        [InlineData("12345678$AFADF")]
        [InlineData("$AFADF")]
        public async Task CustomPassword_Should_Fail_WhenPasswordNotInCorrectFormat(string password)
        {
            // Act
            var result = await _sut.ValidateAsync(password);

            // Assert
            using (new AssertionScope())
            {
                result.IsValid.Should().BeFalse();
                result.Errors.Should().Contain(
                    x => x.ErrorMessage == ValidationMessages.PasswordWithWrongFormatMessage);
            }
        }

        [Theory]
        [InlineData("12345678aA!")]
        [InlineData("12345678Aaaa!!!")]
        [InlineData("12345678blfsaF$")]
        [InlineData("12345AAAf*")]
        public async Task CustomPassword_Should_Success_WhenCorrectPassword(string email)
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
