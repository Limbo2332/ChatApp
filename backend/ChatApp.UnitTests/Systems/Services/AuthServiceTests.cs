using AutoMapper;
using ChatApp.BLL.Interfaces.Auth;
using ChatApp.BLL.Services.Auth;
using ChatApp.Common.DTO.Auth;
using ChatApp.Common.DTO.User;
using ChatApp.Common.Exceptions;
using ChatApp.DAL.Entities;
using ChatApp.DAL.Repositories.Abstract;
using ChatApp.UnitTests.Systems.Services.Abstract;
using ChatApp.UnitTests.TestData;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace ChatApp.UnitTests.Systems.Services
{
    public class AuthServiceTests : BaseServiceTests
    {
        private IAuthService _sut;
        private readonly IJwtService _jwtService;
        private readonly Mock<IUserRepository> _userRepositoryMock = new Mock<IUserRepository>();
        private readonly Mock<IRefreshTokenRepository> _refreshTokenRepositoryMock = new Mock<IRefreshTokenRepository>();

        public AuthServiceTests()
            : base()
        {
            _jwtService = new JwtService(_configMock.Object);

            _sut = new AuthService(
                _mapper,
                _userIdGetterMock.Object,
                _jwtService,
                _configMock.Object,
                _userRepositoryMock.Object,
                _refreshTokenRepositoryMock.Object);
        }

        [Fact]
        public async Task LoginAsync_Should_ThrowException_WhenNoUser()
        {
            // Arrange
            var userDto = new UserLoginDto
            {
                EmailOrUserName = "Test",
                Password = "Test"
            };

            // Act
            var result = async () => await _sut.LoginAsync(userDto);

            // Assert
            await result.Should().ThrowAsync<NotFoundException>();
        }

        [Fact]
        public async Task LoginAsync_Should_ThrowException_WhenWrongPassword()
        {
            // Arrange
            var userDto = new UserLoginDto
            {
                EmailOrUserName = "TestUserName",
                Password = "Test"
            };

            var user = DbContextTestData.Users.First();

            _userRepositoryMock
                .Setup(ur => ur.GetByExpressionAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(user);

            // Act
            var result = async () => await _sut.LoginAsync(userDto);

            // Assert
            await result.Should().ThrowAsync<InvalidEmailUsernameOrPasswordException>();
        }

        [Fact]
        public async Task LoginAsync_Should_ReturnAuthUser()
        {
            // Arrange
            var userDto = new UserLoginDto
            {
                EmailOrUserName = "TestUserName",
                Password = "Test123!$"
            };

            var user = DbContextTestData.Users.First(u => u.UserName == userDto.EmailOrUserName);

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

                result.User.UserName.Should().BeEquivalentTo(userDto.EmailOrUserName);

                Convert.FromBase64String(result.Token.RefreshToken).Length.Should().Be(32);
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
            var fakeUser = new User
            {
                Id = 999,
                UserName = "FakeUserName",
                Email = "FakeEmail"
            };

            var accessToken = new AccessTokenDto
            {
                RefreshToken = _jwtService.GenerateRefreshToken(),
                AccessToken = _jwtService.GenerateAccessToken(fakeUser.Id, fakeUser.UserName, fakeUser.Email)
            };

            // Act
            var result = async () => await _sut.RefreshTokenAsync(accessToken);

            // Assert
            await result.Should().ThrowAsync<NotFoundException>();
        }

        [Fact]
        public async Task RefreshTokenAsync_Should_ThrowException_WhenNoSuchRefreshTokens()
        {
            // Arrange
            var user = DbContextTestData.Users.First();
            var accessToken = new AccessTokenDto
            {
                RefreshToken = _jwtService.GenerateRefreshToken(),
                AccessToken = _jwtService.GenerateAccessToken(user.Id, user.UserName, user.Email)
            };

            _userRepositoryMock
                .Setup(ur => ur.GetByExpressionAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(user);

            _refreshTokenRepositoryMock
                .Setup(rtr => rtr.GetByExpressionAsync(It.IsAny<Expression<Func<RefreshToken, bool>>>()))
                .ReturnsAsync(It.IsAny<RefreshToken>());

            // Act
            var result = async () => await _sut.RefreshTokenAsync(accessToken);

            // Assert
            await result.Should().ThrowAsync<InvalidTokenException>();
        }

        [Fact]
        public async Task RefreshTokenAsync_Should_ThrowException_WhenRefreshTokenIsNotActive()
        {
            // Arrange
            var refreshToken = DbContextTestData.RefreshTokens.First();
            refreshToken.Expires = DateTime.UtcNow.AddDays(-5);

            var user = DbContextTestData.Users.First();
            var accessToken = new AccessTokenDto
            {
                RefreshToken = _jwtService.GenerateRefreshToken(),
                AccessToken = _jwtService.GenerateAccessToken(user.Id, user.UserName, user.Email)
            };

            _userRepositoryMock
                .Setup(ur => ur.GetByExpressionAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(user);

            _refreshTokenRepositoryMock
                .Setup(rtr => rtr.GetByExpressionAsync(It.IsAny<Expression<Func<RefreshToken, bool>>>()))
                .ReturnsAsync(refreshToken);

            // Act
            var result = async () => await _sut.RefreshTokenAsync(accessToken);

            // Assert
            await result.Should().ThrowAsync<ExpiredRefreshTokenException>();
        }

        [Fact]
        public async Task RefreshTokenAsync_Should_ReturnToken()
        {
            // Arrange
            var refreshTokens = DbContextTestData.RefreshTokens;
            var refreshToken = refreshTokens.First();

            var user = DbContextTestData.Users.First();
            var accessToken = new AccessTokenDto
            {
                RefreshToken = _jwtService.GenerateRefreshToken(),
                AccessToken = _jwtService.GenerateAccessToken(user.Id, user.UserName, user.Email)
            };

            var newRefreshToken = new RefreshToken
            {
                Id = 999,
                Token = _jwtService.GenerateRefreshToken(),
                UserId = user.Id,
            };

            _userRepositoryMock
                .Setup(ur => ur.GetByExpressionAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(user);

            _refreshTokenRepositoryMock
                .Setup(rtr => rtr.GetByExpressionAsync(It.IsAny<Expression<Func<RefreshToken, bool>>>()))
                .ReturnsAsync(refreshToken);

            _refreshTokenRepositoryMock
                .Setup(rtr => rtr.DeleteAsync(It.IsAny<int>()))
                .Callback(() => refreshTokens.Remove(refreshToken))
                .Returns(Task.CompletedTask);

            _refreshTokenRepositoryMock
                .Setup(rtr => rtr.AddAsync(It.IsAny<RefreshToken>()))
                .Callback<RefreshToken>(refreshToken =>
                {
                    refreshToken.Id = newRefreshToken.Id;
                    refreshTokens.Add(refreshToken);
                })
                .ReturnsAsync(newRefreshToken);

            // Act
            var result = await _sut.RefreshTokenAsync(accessToken);

            // Assert
            using (new AssertionScope())
            {
                result.Should().NotBeNull();
                result.AccessToken.Should().NotBeNull();
                result.RefreshToken.Should().NotBeNull();

                accessToken.AccessToken.Should().NotBeEquivalentTo(result.AccessToken);
                accessToken.RefreshToken.Should().NotBeEquivalentTo(result.RefreshToken);

                refreshTokens.Should().Contain(rt => rt.Id == newRefreshToken.Id);
            }
        }

        [Fact]
        public async Task RemoveRefreshTokenAsync_Should_ThrowException_WhenNoTokenInDatabase()
        {
            // Arrange
            var refreshToken = _jwtService.GenerateRefreshToken();

            // Act
            var result = async () => await _sut.RemoveRefreshTokenAsync(refreshToken);

            // Assert
            await result.Should().ThrowAsync<InvalidTokenException>();
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
    }
}
