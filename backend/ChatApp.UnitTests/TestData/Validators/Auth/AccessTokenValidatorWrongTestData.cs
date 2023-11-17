using ChatApp.Common.DTO.Auth;

namespace ChatApp.UnitTests.TestData.Validators.Auth
{
    public class AccessTokenValidatorWrongTestData : TheoryData<AccessTokenDto>
    {
        public AccessTokenValidatorWrongTestData()
        {
            Add(new AccessTokenDto
            {
                AccessToken = null!,
                RefreshToken = null!,
            });
            Add(new AccessTokenDto
            {
                AccessToken = "",
                RefreshToken = "",
            });
            Add(new AccessTokenDto
            {
                AccessToken = string.Empty,
                RefreshToken = string.Empty,
            });
        }
    }
}
