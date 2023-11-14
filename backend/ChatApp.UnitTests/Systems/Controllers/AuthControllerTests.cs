using Azure.Core;
using ChatApp.BLL.Interfaces.Auth;
using ChatApp.Common.DTO.Auth;
using ChatApp.Common.DTO.User;
using ChatApp.Common.Exceptions;
using ChatApp.Common.Filters;
using ChatApp.UnitTests.TestData;
using ChatApp.WebAPI.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
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
            var userRegister = new UserRegisterDto
            {
                Email = "correctEmail@gmail.com",
                Password = "correctPassword123!$%",
                UserName = "correctUserName"
            };

            var authUser = new AuthUserDto
            {
                User = new UserDto
                {
                    Email = userRegister.Email,
                    UserName = userRegister.UserName
                }
            };

            _authService
                .RegisterAsync(userRegister)
                .Returns(authUser);

            // Act
            var result = await _sut.RegisterAsync(userRegister);
            var response = result.Result as CreatedResult;

            // Assert
            using (new AssertionScope())
            {
                result.Should().BeOfType<ActionResult<AuthUserDto>>();
                _authService.ReceivedCalls().Count().Should().Be(1);

                response.Should().NotBeNull();
                response!.Value.Should().BeOfType<AuthUserDto>();
                response.Value.Should().Be(authUser);
                response.StatusCode.Should().Be((int)HttpStatusCode.Created);
            }
        }

        [Fact]
        public async Task LoginAsync_Should_BeSuccess()
        {
            // Arrange
            var userLogin = new UserLoginDto
            {
                EmailOrUserName = "correctEmail@gmail.com",
                Password = "correctPassword123!$%"
            };

            var authUser = new AuthUserDto
            {
                User = new UserDto
                {
                    Email = userLogin.EmailOrUserName
                }
            };

            _authService
                .LoginAsync(userLogin)
                .Returns(authUser);

            // Act
            var result = await _sut.LoginAsync(userLogin);
            var response = result.Result as OkObjectResult;

            // Assert
            using (new AssertionScope())
            {
                result.Should().BeOfType<ActionResult<AuthUserDto>>();
                _authService.ReceivedCalls().Count().Should().Be(1);

                _sut.ModelState.IsValid.Should().BeTrue();
                response.Should().NotBeNull();
                response!.Value.Should().BeOfType<AuthUserDto>();
                response.Value.Should().Be(authUser);
                response.StatusCode.Should().Be((int)HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task RefreshAsync_Should_BeSuccess()
        {
            // Arrange
            var accessToken = new AccessTokenDto
            {
                AccessToken = "accessToken",
                RefreshToken = "refreshToken"
            };

            var updatedAccessToken = new AccessTokenDto
            {
                AccessToken = "updatedAccessToken",
                RefreshToken = "updatedRefreshToken"
            };

            _authService
                .RefreshTokenAsync(accessToken)
                .Returns(updatedAccessToken);

            // Act
            var result = await _sut.RefreshAsync(accessToken);
            var response = result.Result as OkObjectResult;

            // Assert
            using (new AssertionScope())
            {
                result.Should().BeOfType<ActionResult<AccessTokenDto>>();
                _authService.ReceivedCalls().Count().Should().Be(1);

                response.Should().NotBeNull();
                response!.Value.Should().BeOfType<AccessTokenDto>();
                response.Value.Should().Be(updatedAccessToken);
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
