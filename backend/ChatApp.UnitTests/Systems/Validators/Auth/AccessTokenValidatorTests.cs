using ChatApp.Common.Constants;
using ChatApp.Common.DTO.Auth;
using ChatApp.UnitTests.TestData.Validators.Auth;
using ChatApp.WebAPI.Validators.Auth;

namespace ChatApp.UnitTests.Systems.Validators.Auth
{
    public class AccessTokenValidatorTests
    {
        private readonly AccessTokenValidator _sut = new AccessTokenValidator();

        [Theory]
        [ClassData(typeof(AccessTokenValidatorWrongTestData))]
        public async Task ValidateToken_Should_Fail_WhenWrongAccessToken(AccessTokenDto accessToken)
        {
            // Act
            var result = await _sut.TestValidateAsync(accessToken);

            // Assert
            result
                .ShouldHaveValidationErrorFor(x => x.AccessToken)
                .WithErrorMessage(ValidationMessages.AccessTokenIsEmptyMessage);
            result
                .ShouldHaveValidationErrorFor(x => x.RefreshToken)
                .WithErrorMessage(ValidationMessages.RefreshTokenIsEmptyMessage);
        }

        [Theory]
        [ClassData(typeof(AccessTokenValidatorCorrectTestData))]
        public async Task ValidateToken_Should_Success_WhenAccessToken(AccessTokenDto accessToken)
        {
            // Act
            var result = await _sut.TestValidateAsync(accessToken);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.AccessToken);
            result.ShouldNotHaveValidationErrorFor(x => x.RefreshToken);
        }
    }
}
