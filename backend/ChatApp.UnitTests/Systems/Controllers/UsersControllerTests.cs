using ChatApp.BLL.Interfaces;
using ChatApp.Common.DTO.Mail;
using ChatApp.Common.DTO.User;
using ChatApp.WebAPI.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ChatApp.UnitTests.Systems.Controllers
{
    public class UsersControllerTests
    {
        private readonly UsersController _sut;
        private readonly IUserService _userService;

        public UsersControllerTests()
        {
            _userService = Substitute.For<IUserService>();

            _sut = new UsersController(_userService);
        }

        [Fact]
        public async Task SendEmailAsync_Should_BeSuccess()
        {
            // Arrange
            var resetEmail = Substitute.For<ResetEmailDto>();
            var mailDto = Substitute.For<MailDto>();

            _userService
                .SendResetEmailAsync(resetEmail.Email)
                .Returns(mailDto);

            // Act
            var result = await _sut.SendEmailAsync(resetEmail);
            var response = result.Result as OkObjectResult;

            // Assert
            using (new AssertionScope())
            {
                _userService.ReceivedCalls().Count().Should().Be(1);

                response.Should().NotBeNull();
                response!.Value.Should().Be(mailDto);
                response.StatusCode.Should().Be((int)HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task ResetPasswordAsync_Should_BeSuccess()
        {
            // Arrange
            var resetPassword = Substitute.For<ResetPasswordDto>();

            _userService
                .ResetPasswordAsync(resetPassword)
                .Returns(Task.CompletedTask);

            // Act
            var result = await _sut.ResetPasswordAsync(resetPassword);
            var response = result as OkResult;

            // Assert
            using (new AssertionScope())
            {
                _userService.ReceivedCalls().Count().Should().Be(1);

                response.Should().NotBeNull();
                response!.StatusCode.Should().Be((int)HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task UpdateUserAsync_Should_BeSuccess()
        {
            // Arrange
            var userEdit = Substitute.For<UserEditDto>();
            var user = Substitute.For<UserDto>();

            _userService
                .UpdateUserAsync(userEdit)
                .Returns(user);

            // Act
            var result = await _sut.UpdateUserAsync(userEdit);
            var response = result.Result as OkObjectResult;

            // Assert
            using (new AssertionScope())
            {
                _userService.ReceivedCalls().Count().Should().Be(1);

                response.Should().NotBeNull();
                response!.Value.Should().Be(user);
                response.StatusCode.Should().Be((int)HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task UpdateAvatarAsync_Should_BeSuccess()
        {
            // Arrange
            var formFile = Substitute.For<IFormFile>();
            var userAvatar = Substitute.For<UserAvatarDto>();

            _userService
                .UpdateUserAvatarAsync(formFile)
                .Returns(userAvatar);

            // Act
            var result = await _sut.UpdateAvatarAsync(formFile);
            var response = result.Result as OkObjectResult;

            // Assert
            using (new AssertionScope())
            {
                _userService.ReceivedCalls().Count().Should().Be(1);

                response.Should().NotBeNull();
                response!.Value.Should().Be(userAvatar);
                response.StatusCode.Should().Be((int)HttpStatusCode.OK);
            }
        }
    }
}
