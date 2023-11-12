using ChatApp.BLL.Interfaces.Auth;
using ChatApp.BLL.Services.Auth;
using ChatApp.UnitTests.Systems.Services.Abstract;
using ChatApp.UnitTests.TestData;
using FluentAssertions.Execution;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Moq;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ChatApp.UnitTests.Systems.Services
{
    public class JwtServiceTests : BaseServiceTests
    {
        private readonly IJwtService _sut;

        public JwtServiceTests()
            : base()
        {
            _sut = new JwtService(_configMock.Object);
        }

        [Fact]
        public void GenerateRefreshToken_ShouldReturn_RefreshToken()
        {
            // Arrange & Act
            var token = _sut.GenerateRefreshToken();

            // Assert
            using (new AssertionScope())
            {
                token.Should().NotBeNull();
                Convert.FromBase64String(token).Length.Should().Be(32);
            }
        }

        [Theory]
        [ClassData(typeof(JwtServiceTestData))]
        public void GenerateAccessToken_ShouldReturn_AccessToken(int userId, string userName, string email)
        {
            // Arrange
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_signingKey))
            };

            // Act
            var accessToken = _sut.GenerateAccessToken(userId, userName, email);

            // Assert
            var claimsPrincipal = new JwtSecurityTokenHandler()
                .ValidateToken(accessToken, tokenValidationParameters, out var securityToken);

            var subClaim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type.Contains("name"));
            var emailClaim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type.Contains("email"));
            var jtiClaim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti);
            var idClaim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "id");

            using (new AssertionScope())
            {
                accessToken.Should().NotBeNull();
                claimsPrincipal.Should().NotBeNull();
                subClaim.Should().NotBeNull();
                emailClaim.Should().NotBeNull();
                jtiClaim.Should().NotBeNull();
                idClaim.Should().NotBeNull();

                subClaim!.Value.Should().BeEquivalentTo(userName);
                emailClaim!.Value.Should().BeEquivalentTo(email);
                idClaim!.Value.Should().BeEquivalentTo(userId.ToString());
                subClaim.Value.Should().BeEquivalentTo(userName);
                Guid.TryParse(jtiClaim!.Value, out Guid guidResult).Should().BeTrue();
            }
        }

        [Theory]
        [ClassData(typeof(JwtServiceTestData))]
        public void GetUserIdFromToken_ShouldReturn_UserId(int userId, string userName, string email)
        {
            // Arrange
            var accessToken = _sut.GenerateAccessToken(userId, userName, email);

            // Act
            var userIdResult = _sut.GetUserIdFromToken(accessToken, _signingKey);

            // Assert
            userId.Should().Be(userIdResult);
        }
    }
}
