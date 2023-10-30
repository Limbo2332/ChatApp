using ChatApp.BLL.Interfaces.Auth;
using ChatApp.BLL.Services.Auth;
using ChatApp.UnitTests.Abstract;
using ChatApp.UnitTests.TestData;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Moq;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ChatApp.UnitTests
{
    public class JwtServiceTests : BaseServiceTests
    {
        private readonly IJwtService _sut;

        public JwtServiceTests() 
            : base()
        {
            _sut = new JwtService(_config.Object);
        }

        [Fact]
        public void GenerateRefreshToken_ShouldReturn_RefreshToken()
        {
            // Arrange & Act
            var token = _sut.GenerateRefreshToken();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(token);
                Assert.True(Convert.FromBase64String(token).Length == 32);
            });
        }

        [Theory]
        [ClassData(typeof(JwtServiceTestData))]
        public void GenerateAccessToken_ShouldReturn_AccessToken(int userId, string userName, string email)
        {
            // Arrange
            var signingKey = _config.Object.GetSection(_signingKeyConfigName).Value!;

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey))
            };

            // Arrange & Act
            var accessToken = _sut.GenerateAccessToken(userId, userName, email);

            var claimsPrincipal = new JwtSecurityTokenHandler()
                .ValidateToken(accessToken, tokenValidationParameters, out var securityToken);

            var subClaim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type.Contains("name"));
            var emailClaim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type.Contains("email"));
            var jtiClaim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti);
            var idClaim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "id");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(accessToken);
                Assert.NotNull(claimsPrincipal);
                Assert.NotNull(subClaim);
                Assert.NotNull(emailClaim);
                Assert.NotNull(jtiClaim);
                Assert.NotNull(idClaim);

                Assert.Equal(subClaim.Value, userName);
                Assert.Equal(emailClaim.Value, email);
                Assert.Equal(idClaim.Value, userId.ToString());
                Assert.True(Guid.TryParse(jtiClaim.Value, out Guid guidResult));
            });
        }

        [Theory]
        [ClassData(typeof(JwtServiceTestData))]
        public void GetUserIdFromToken_ShouldReturn_UserId(int userId, string userName, string email)
        {
            // Arrange
            var signingKey = _config.Object.GetSection(_signingKeyConfigName).Value!;
            var accessToken = _sut.GenerateAccessToken(userId, userName, email);

            // Act
            var userIdResult = _sut.GetUserIdFromToken(accessToken, signingKey);

            // Assert
            Assert.Equal(userId, userIdResult);
        }
    }
}
