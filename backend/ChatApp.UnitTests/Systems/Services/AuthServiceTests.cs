using ChatApp.BLL.Interfaces.Auth;
using ChatApp.BLL.Services.Auth;
using ChatApp.Common.DTO.Auth;
using ChatApp.Common.DTO.User;
using ChatApp.Common.Exceptions;
using ChatApp.Common.Security;
using ChatApp.DAL.Entities;
using ChatApp.DAL.Repositories.Abstract;
using ChatApp.UnitTests.Systems.Services.Abstract;
using ChatApp.UnitTests.TestData;
using System.Linq.Expressions;

namespace ChatApp.UnitTests.Systems.Services
{
    public class AuthServiceTests : BaseServiceTests
    {
        private readonly IAuthService _sut;
        private readonly Mock<IJwtService> _jwtServiceMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IRefreshTokenRepository> _refreshTokenRepositoryMock;
        private readonly string _generatedRefreshToken;

        public AuthServiceTests()
        {
            _jwtServiceMock = new Mock<IJwtService>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _refreshTokenRepositoryMock = new Mock<IRefreshTokenRepository>();

            _generatedRefreshToken = Convert.ToBase64String(SecurityHelper.GetRandomBytes());

            _sut = new AuthService(
                _mapper,
                _userIdGetterMock.Object,
                _jwtServiceMock.Object,
                _configMock.Object,
                _userRepositoryMock.Object,
                _refreshTokenRepositoryMock.Object);

            SetupJwtServiceMock();
        }

        [Fact]
        public async Task LoginAsync_Should_ThrowException_WhenNoUser()
        {
            // Arrange
            var userDto = new Mock<UserLoginDto>();

            // Act
            var result = async () => await _sut.LoginAsync(userDto.Object);

            // Assert
            await result
                .Should()
                .ThrowAsync<NotFoundException>()
                .WithMessage("User was not found");
        }

        [Fact]
        public async Task LoginAsync_Should_ThrowException_WhenWrongPassword()
        {
            // Arrange
            var userDto = new Mock<UserLoginDto>();

            var user = new Mock<User>();

            _userRepositoryMock
                .Setup(ur => ur.GetByExpressionAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(user.Object);

            // Act
            var result = async () => await _sut.LoginAsync(userDto.Object);

            // Assert
            await result
                .Should()
                .ThrowAsync<InvalidEmailUsernameOrPasswordException>()
                .WithMessage("Invalid username/email or password");
        }

        [Fact]
        public async Task LoginAsync_Should_ReturnAuthUser()
        {
            // Arrange
            var user = DbContextTestData.Users.First();

            var userDto = new UserLoginDto
            {
                EmailOrUserName = user.Email,
                Password = user.Password
            };

            user.Password = SecurityHelper.HashPassword(user.Password, Convert.FromBase64String(user.Salt));

            _userRepositoryMock
                .Setup(ur => ur.GetByExpressionAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(user);

            // Act 
            var result = await _sut.LoginAsync(userDto);

            // Assert
            using (new AssertionScope())
            {
                result.Should().NotBeNull();
                result.User.Should().NotBeNull();
                result.Token.Should().NotBeNull();
                result.Token.AccessToken.Should().NotBeNull();
                result.Token.RefreshToken.Should().NotBeNull();

                result.User.Email.Should().BeEquivalentTo(userDto.EmailOrUserName);

                result.Token.RefreshToken.Should().BeEquivalentTo(_generatedRefreshToken);
            }
        }

        [Fact]
        public async Task RegisterAsync_Should_ReturnAuthUser()
        {
            // Arrange
            var userDto = new UserRegisterDto
            {
                Email = "Test123999@gmail.com",
                UserName = "TestUniqueUserName999",
                Password = "Test123!!!!$"
            };

            var users = DbContextTestData.Users;

            var user = new User
            {
                Email = userDto.Email,
                UserName = userDto.UserName,
                ImagePath = null,
            };

            _userRepositoryMock
                .Setup(ur => ur.AddAsync(It.IsAny<User>()))
                .Callback<User>(users.Add)
                .ReturnsAsync(user);

            // Act
            var result = await _sut.RegisterAsync(userDto);

            // Assert
            using (new AssertionScope())
            {
                result.Should().NotBeNull();
                result.User.Should().NotBeNull();
                result.Token.Should().NotBeNull();
                result.Token.AccessToken.Should().NotBeNull();
                result.Token.RefreshToken.Should().NotBeNull();

                result.User.UserName.Should().BeEquivalentTo(userDto.UserName);
                result.User.Email.Should().BeEquivalentTo(userDto.Email);
                result.User.ImagePath.Should().BeNull();

                Convert.FromBase64String(result.Token.RefreshToken).Length.Should().Be(32);

                users.Should().Contain(userInList => userInList.Email == userDto.Email);
            }
        }

        [Fact]
        public async Task RefreshTokenAsync_Should_ThrowException_WhenWrongUser()
        {
            // Arrange
            var accessToken = new Mock<AccessTokenDto>();

            // Act
            var result = async () => await _sut.RefreshTokenAsync(accessToken.Object);

            // Assert
            await result
                .Should()
                .ThrowAsync<NotFoundException>("User was not found");
        }

        [Fact]
        public async Task RefreshTokenAsync_Should_ThrowException_WhenNoSuchRefreshTokens()
        {
            // Arrange
            var user = new Mock<User>();
            var accessToken = new Mock<AccessTokenDto>();

            _userRepositoryMock
                .Setup(ur => ur.GetByExpressionAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(user.Object);

            // Act
            var result = async () => await _sut.RefreshTokenAsync(accessToken.Object);

            // Assert
            await result
                .Should()
                .ThrowAsync<InvalidTokenException>()
                .WithMessage("Invalid RefreshToken.");
        }

        [Fact]
        public async Task RefreshTokenAsync_Should_ThrowException_WhenRefreshTokenIsNotActive()
        {
            // Arrange
            var refreshToken = new Mock<RefreshToken>
            {
                Object =
                {
                    Expires = DateTime.UtcNow.AddDays(-15)
                }
            };

            var user = new Mock<User>();
            var accessToken = new Mock<AccessTokenDto>();

            _userRepositoryMock
                .Setup(ur => ur.GetByExpressionAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(user.Object);

            _refreshTokenRepositoryMock
                .Setup(rtr => rtr.GetByExpressionAsync(It.IsAny<Expression<Func<RefreshToken, bool>>>()))
                .ReturnsAsync(refreshToken.Object);

            // Act
            var result = async () => await _sut.RefreshTokenAsync(accessToken.Object);

            // Assert
            await result
                .Should()
                .ThrowAsync<ExpiredRefreshTokenException>()
                .WithMessage("Refresh token expired.");
        }

        [Fact]
        public async Task RefreshTokenAsync_Should_ReturnToken()
        {
            // Arrange
            var refreshTokens = DbContextTestData.RefreshTokens;
            var refreshToken = refreshTokens.First();

            var user = new Mock<User>();
            var accessToken = new Mock<AccessTokenDto>();

            var newRefreshToken = new RefreshToken
            {
                Id = 999,
                Token = "123Token",
                UserId = 999,
            };

            _userRepositoryMock
                .Setup(ur => ur.GetByExpressionAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(user.Object);

            _refreshTokenRepositoryMock
                .Setup(rtr => rtr.GetByExpressionAsync(It.IsAny<Expression<Func<RefreshToken, bool>>>()))
                .ReturnsAsync(refreshToken);

            _refreshTokenRepositoryMock
                .Setup(rtr => rtr.DeleteAsync(It.IsAny<int>()))
                .Callback(() => refreshTokens.Remove(refreshToken));

            _refreshTokenRepositoryMock
                .Setup(rtr => rtr.AddAsync(It.IsAny<RefreshToken>()))
                .Callback(() =>
                {
                    refreshToken.Id = newRefreshToken.Id;
                    refreshTokens.Add(refreshToken);
                })
                .ReturnsAsync(newRefreshToken);

            // Act
            var result = await _sut.RefreshTokenAsync(accessToken.Object);

            // Assert
            using (new AssertionScope())
            {
                result.Should().NotBeNull();
                result.AccessToken.Should().NotBeNull();
                result.RefreshToken.Should().NotBeNull();

                accessToken.Object.AccessToken.Should().NotBeEquivalentTo(result.AccessToken);
                accessToken.Object.RefreshToken.Should().NotBeEquivalentTo(result.RefreshToken);

                refreshTokens.Should().Contain(rt => rt.Id == newRefreshToken.Id);
            }
        }

        [Fact]
        public async Task RemoveRefreshTokenAsync_Should_ThrowException_WhenNoTokenInDatabase()
        {
            // Arrange
            var refreshToken = It.IsAny<string>();

            // Act
            var result = async () => await _sut.RemoveRefreshTokenAsync(refreshToken);

            // Assert
            await result
                .Should()
                .ThrowAsync<InvalidTokenException>()
                .WithMessage("Invalid RefreshToken.");
        }

        [Fact]
        public async Task RemoveRefreshTokenAsync_ShouldWork()
        {
            // Arrange
            var refreshTokens = DbContextTestData.RefreshTokens;
            var refreshToken = refreshTokens.First();

            _refreshTokenRepositoryMock
                .Setup(rtr => rtr.GetByExpressionAsync(It.IsAny<Expression<Func<RefreshToken, bool>>>()))
                .ReturnsAsync(refreshToken);

            _refreshTokenRepositoryMock
                .Setup(rtr => rtr.DeleteAsync(It.IsAny<int>()))
                .Callback(() => refreshTokens.Remove(refreshToken))
                .Returns(Task.CompletedTask);

            // Act
            await _sut.RemoveRefreshTokenAsync(refreshToken.Token);

            // Assert
            refreshTokens.Should().NotContain(rt => rt.Id == refreshToken.Id);
        }

        private void SetupJwtServiceMock()
        {
            _jwtServiceMock
                .Setup(s => s.GenerateRefreshToken())
                .Returns(_generatedRefreshToken);

            _jwtServiceMock
                .Setup(s => s.GenerateAccessToken(
                    It.IsAny<int>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .Returns(_generatedRefreshToken);
        }
    }
}
