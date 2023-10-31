using AutoMapper;
using ChatApp.BLL.Interfaces.Auth;
using ChatApp.BLL.MappingProfiles;
using ChatApp.BLL.MappingProfiles.Resolvers;
using ChatApp.BLL.Services.Auth;
using ChatApp.Common.DTO.Auth;
using ChatApp.Common.DTO.User;
using ChatApp.Common.Exceptions;
using ChatApp.Common.Logic.Abstract;
using ChatApp.Common.Security;
using ChatApp.DAL.Context;
using ChatApp.DAL.Entities;
using ChatApp.UnitTests.Abstract;
using ChatApp.UnitTests.TestData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using System.Linq.Dynamic.Core.Tokenizer;

namespace ChatApp.UnitTests
{
    public class AuthServiceTests : BaseServiceTests, IDisposable
    {
        private IAuthService _sut;
        private readonly IJwtService _jwtService;

        public AuthServiceTests()
            : base()
        {
            _jwtService = new JwtService(_config.Object);

            _sut = new AuthService(_context, _mapper, _userIdGetter.Object, _jwtService, _config.Object);
        }

        [Fact]
        public async Task LoginAsync_ShouldThrowException_WhenNoUser()
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
            await Assert.ThrowsAsync<NotFoundException>(result);
        }

        [Fact]
        public async Task LoginAsync_ShouldThrowException_WhenWrongPassword()
        {
            // Arrange
            var userDto = new UserLoginDto
            {
                EmailOrUserName = "TestUserName",
                Password = "Test"
            };

            // Act
            var result = async () => await _sut.LoginAsync(userDto);

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(result);
        }

        [Fact]
        public async Task LoginAsync_ShouldReturnAuthUser()
        {
            // Arrange
            var userDto = new UserLoginDto
            {
                EmailOrUserName = "TestUserName",
                Password = "Test123!$"
            };

            // Act 
            var result = await _sut.LoginAsync(userDto);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(result);
                Assert.NotNull(result.User);
                Assert.NotNull(result.Token);
                Assert.NotNull(result.Token.AccessToken);
                Assert.NotNull(result.Token.RefreshToken);

                Assert.Equal(result.User.UserName, userDto.EmailOrUserName);
                Assert.True(Convert.FromBase64String(result.Token.RefreshToken).Length == 32);
            });
        }

        [Fact]
        public async Task RegisterAsync_ShouldReturnAuthUser()
        {
            // Arrange
            var userDto = new UserRegisterDto
            {
                Email = "Test123@gmail.com",
                UserName = "TestUniqueUserName",
                Password = "Test123!!!!$"
            };

            // Act
            var result = await _sut.RegisterAsync(userDto);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(result);
                Assert.NotNull(result.User);
                Assert.NotNull(result.Token);
                Assert.NotNull(result.Token.AccessToken);
                Assert.NotNull(result.Token.RefreshToken);

                Assert.Equal(result.User.UserName, userDto.UserName);
                Assert.Equal(result.User.Email, userDto.Email);
                Assert.Null(result.User.ImagePath);
                Assert.True(Convert.FromBase64String(result.Token.RefreshToken).Length == 32);

                Assert.NotNull(_context.Users.Find(result.User.Id));
            });
        }

        [Fact]
        public async Task RefreshTokenAsync_ShouldThrowException_WhenWrongUser()
        {
            // Arrange
            var accessToken = new AccessTokenDto
            {
                RefreshToken = _jwtService.GenerateRefreshToken(),
                AccessToken = _jwtService.GenerateAccessToken(999, "WrongUserName", "WrongEmail")
            };

            // Act
            var result = async () => await _sut.RefreshTokenAsync(accessToken);

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(result);
        }

        [Fact]
        public async Task RefreshTokenAsync_ShouldThrowException_WhenNoSuchRefreshTokens()
        {
            // Arrange
            var accessToken = new AccessTokenDto
            {
                RefreshToken = _jwtService.GenerateRefreshToken(),
                AccessToken = _jwtService.GenerateAccessToken(1, "TestUserName", "Test@gmail.com")
            };

            // Act
            var result = async () => await _sut.RefreshTokenAsync(accessToken);

            // Assert
            await Assert.ThrowsAsync<InvalidTokenException>(result);
        }


        [Fact]
        public async Task RefreshTokenAsync_ShouldThrowException_WhenRefreshTokenIsNotActive()
        {
            // Arrange
            var refreshToken = await _context.RefreshTokens.LastAsync();
            refreshToken.Expires = DateTime.UtcNow.AddDays(-5);

            var accessToken = new AccessTokenDto
            {
                RefreshToken = refreshToken.Token,
                AccessToken = _jwtService.GenerateAccessToken(1, "TestUserName", "Test@gmail.com")
            };

            // Act
            var result = async () => await _sut.RefreshTokenAsync(accessToken);

            // Assert
            await Assert.ThrowsAsync<ExpiredRefreshTokenException>(result);
        }

        [Fact]
        public async Task RefreshTokenAsync_ShouldReturnToken()
        {
            // Arrange
            var refreshToken = await _context.RefreshTokens.FirstAsync();

            var accessToken = new AccessTokenDto
            {
                RefreshToken = refreshToken.Token,
                AccessToken = _jwtService.GenerateAccessToken(1, "TestUserName", "Test@gmail.com")
            };

            // Act
            var result = await _sut.RefreshTokenAsync(accessToken);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(result);
                Assert.NotNull(result.AccessToken);
                Assert.NotNull(result.RefreshToken);

                Assert.NotEqual(accessToken.RefreshToken, result.RefreshToken);
                Assert.NotEqual(accessToken.AccessToken, result.AccessToken);

                Assert.NotNull(_context.RefreshTokens.FirstOrDefault(rt => rt.Token == result.RefreshToken));
            });
        }

        [Fact]
        public async Task RemoveRefreshTokenAsync_ShouldThrowException_WhenNoTokenInDatabase()
        {
            // Arrange
            var refreshToken = _jwtService.GenerateRefreshToken();

            // Act
            var result = async () => await _sut.RemoveRefreshTokenAsync(refreshToken);

            // Assert
            await Assert.ThrowsAsync<InvalidTokenException>(result);
        }

        [Fact]
        public async Task RemoveRefreshTokenAsync_ShouldWork()
        {
            // Arrange
            var refreshToken = await _context.RefreshTokens.FirstAsync();

            // Act
            await _sut.RemoveRefreshTokenAsync(refreshToken.Token);

            // Assert
            Assert.Null(_context.RefreshTokens.FirstOrDefault(rt => rt.Id == refreshToken.Id));
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
