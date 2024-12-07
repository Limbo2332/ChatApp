using ChatApp.Common.DTO.Auth;

namespace ChatApp.UnitTests.TestData.Validators.Auth
{
    public class AccessTokenValidatorCorrectTestData : TheoryData<AccessTokenDto>
    {
        public AccessTokenValidatorCorrectTestData()
        {
            Add(new AccessTokenDto
            {
                AccessToken = "accessToken",
                RefreshToken = "refreshToken"
            });
            Add(new AccessTokenDto
            {
                AccessToken = "correctToken",
                RefreshToken = "correctToken"
            });
        }
    }
}
