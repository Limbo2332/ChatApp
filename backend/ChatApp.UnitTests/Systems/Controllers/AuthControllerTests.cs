using ChatApp.BLL.Interfaces.Auth;
using ChatApp.Common.DTO.Auth;
using ChatApp.Common.DTO.User;
using ChatApp.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ChatApp.UnitTests.Systems.Controllers
{
    public class AuthControllerTests
    {
        private readonly IAuthService _authService = Substitute.For<IAuthService>();
        private readonly AuthController _sut;

        public AuthControllerTests()
        {
            _sut = new AuthController(_authService);
        }

        [Fact]
        public async Task RegisterAsync_Should_BeSuccess()
        {
            // Arrange
            var userRegister = Substitute.For<UserRegisterDto>();
            var authUser = Substitute.For<AuthUserDto>();

            _authService
                .RegisterAsync(userRegister)
                .Returns(authUser);

            // Act
            var result = await _sut.RegisterAsync(userRegister);
            var response = result.Result as CreatedResult;

            // Assert
            using (new AssertionScope())
            {
                _authService.ReceivedCalls().Count().Should().Be(1);

                response.Should().NotBeNull();
                response!.Value.Should().Be(authUser);
                response.StatusCode.Should().Be((int)HttpStatusCode.Created);
            }
        }

        [Fact]
        public async Task LoginAsync_Should_BeSuccess()
        {
            // Arrange
            var userLogin = Substitute.For<UserLoginDto>();
            var authUser = Substitute.For<AuthUserDto>();

            _authService
                .LoginAsync(userLogin)
                .Returns(authUser);

            // Act
            var result = await _sut.LoginAsync(userLogin);
            var response = result.Result as OkObjectResult;

            // Assert
            using (new AssertionScope())
            {
                _authService.ReceivedCalls().Count().Should().Be(1);

                response.Should().NotBeNull();
                response!.Value.Should().Be(authUser);
                response.StatusCode.Should().Be((int)HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task RefreshAsync_Should_BeSuccess()
        {
            // Arrange
            var accessToken = Substitute.For<AccessTokenDto>();
            var updatedAccessToken = Substitute.For<AccessTokenDto>();

            _authService
                .RefreshTokenAsync(accessToken)
                .Returns(updatedAccessToken);

            // Act
            var result = await _sut.RefreshAsync(accessToken);
            var response = result.Result as OkObjectResult;

            // Assert
            using (new AssertionScope())
            {
                _authService.ReceivedCalls().Count().Should().Be(1);

                response.Should().NotBeNull();
                response!.Value.Should().Be(updatedAccessToken);
                response.StatusCode.Should().Be((int)HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task RemoveRefreshTokenAsync_Should_BeSuccess()
        {
            // Arrange
            var refreshToken = "refreshToken";

            _authService
                .RemoveRefreshTokenAsync(refreshToken)
                .Returns(Task.CompletedTask);

            // Act
            var result = await _sut.RemoveRefreshTokenAsync(refreshToken);
            var response = result as NoContentResult;

            // Assert
            using (new AssertionScope())
            {
                result.Should().BeOfType<NoContentResult>();
                _authService.ReceivedCalls().Count().Should().Be(1);

                response.Should().NotBeNull();
                response!.StatusCode.Should().Be((int)HttpStatusCode.NoContent);
            }
        }
    }
}
