using ChatApp.Common.Constants;
using ChatApp.DAL.Context.SeedSettings;
using ChatApp.WebAPI.Extensions;

namespace ChatApp.UnitTests.Systems.Validators.Common
{
    public class СustomUserNameRuleBuilderTests
    {
        private readonly InlineValidator<string> _sut;

        public СustomUserNameRuleBuilderTests()
        {
            _sut = new InlineValidator<string>();
            _sut.RuleFor(x => x)
                .CustomUserName();
        }

        [Fact]
        public async Task CustomUserName_Should_Fail_WhenUserNameIsEmpty()
        {
            // Arrange
            var emptyUserName = string.Empty;

            // Act
            var result = await _sut.ValidateAsync(emptyUserName);

            // Assert
            using (new AssertionScope())
            {
                result.IsValid.Should().BeFalse();
                result.Errors.Should().Contain(x => x.ErrorMessage == ValidationMessages.UserNameIsEmptyMessage);
            }
        }

        [Fact]
        public async Task CustomUserName_Should_Fail_WhenUserNameLessThanMinLength()
        {
            // Arrange
            var userName = new string('s', EntityConfigurationSettings.UserNameMinLength - 1);

            // Act
            var result = await _sut.ValidateAsync(userName);

            // Assert
            using (new AssertionScope())
            {
                result.IsValid.Should().BeFalse();
                result.Errors.Should().Contain(
                    x => x.ErrorMessage == ValidationMessages
                        .UserNameWithWrongMinimumLengthMessage(EntityConfigurationSettings.UserNameMinLength));
            }
        }

        [Fact]
        public async Task CustomUserName_Should_Fail_WhenUserNameMoreThanMaxLength()
        {
            // Arrange
            var userName = new string('s', EntityConfigurationSettings.UserNameMaxLength + 1);

            // Act
            var result = await _sut.ValidateAsync(userName);

            // Assert
            using (new AssertionScope())
            {
                result.IsValid.Should().BeFalse();
                result.Errors.Should().Contain(
                    x => x.ErrorMessage == ValidationMessages
                        .UserNameWithWrongMaximumLengthMessage(EntityConfigurationSettings.UserNameMaxLength));
            }
        }

        [Theory]
        [InlineData("   fdfsaf")]
        [InlineData("fsafsa    ")]
        public async Task CustomUserName_Should_Fail_WhenUserNameNotInCorrectFormat(string userName)
        {
            // Act
            var result = await _sut.ValidateAsync(userName);

            // Assert
            using (new AssertionScope())
            {
                result.IsValid.Should().BeFalse();
                result.Errors.Should().Contain(
                    x => x.ErrorMessage == ValidationMessages.UsernameWithWrongFormatMessage);
            }
        }

        [Theory]
        [InlineData("myUserName")]
        [InlineData("customUserName")]
        [InlineData("Easy UserName")]
        public async Task CustomUserName_Should_Success_WhenCorrectUserName(string email)
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
