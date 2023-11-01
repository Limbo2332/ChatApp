using ChatApp.BLL.Hubs;
using ChatApp.BLL.Hubs.Clients;
using ChatApp.BLL.Interfaces;
using ChatApp.BLL.Services;
using ChatApp.Common.DTO.User;
using ChatApp.Common.Exceptions;
using ChatApp.Common.Helpers;
using ChatApp.Common.Security;
using ChatApp.UnitTests.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Moq;
using System.Linq.Dynamic.Core.Tokenizer;

namespace ChatApp.UnitTests
{
    public class UserServiceTests : BaseServiceTests
    {
        private readonly IUserService _sut;
        private readonly Mock<IBlobStorageService> _blobStorageServiceMock = new Mock<IBlobStorageService>();
        private readonly Mock<IEmailService> _emailServiceMock = new Mock<IEmailService>();

        public UserServiceTests()
            : base()
        {
            _sut = new UserService(_context, _mapper, _userIdGetterMock.Object, _blobStorageServiceMock.Object, _emailServiceMock.Object);
        }

        [Fact]
        public void IsEmailUnique_ShouldReturn_True_WhenNoEmail()
        {
            // Arrange
            var uniqueEmail = "uniqueEmail@hgf.net";

            // Act
            var result = _sut.IsEmailUnique(uniqueEmail);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsEmailUnique_ShouldReturn_False_WhenEmail()
        {
            // Arrange
            var notUniqueEmail = _context.Users.First().Email;

            // Act
            var result = _sut.IsEmailUnique(notUniqueEmail);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsUserNameUnique_ShouldReturn_True_WhenNoUserName()
        {
            // Arrange
            var uniqueUserName = "uniqueUSerName";

            // Act
            var result = _sut.IsUserNameUnique(uniqueUserName);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsUserNamelUnique_ShouldReturn_False_WhenUserName()
        {
            // Arrange
            var notUniqueUserName = _context.Users.First().UserName;

            // Act
            var result = _sut.IsUserNameUnique(notUniqueUserName);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task FindUserByUsernameAsync_ShouldThrowException_WhenNoUser()
        {
            // Arrange
            var uniqueUserName = "uniqueUSerName";

            // Act
            var action = async () => await _sut.FindUserByUsernameAsync(uniqueUserName);

            // Assert
            await Assert.ThrowsAsync<BadRequestException>(action);
        }

        [Fact]
        public async Task FindUserByUsernameAsync_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var notUniqueUserName = _context.Users.First().UserName;

            // Act
            var result = await _sut.FindUserByUsernameAsync(notUniqueUserName);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(result);
                Assert.Equal(result.UserName, notUniqueUserName);
            });
        }

        [Fact]
        public async Task UpdateUserAvatarAsync_ShouldThrowException_WhenWrongImageFormat()
        {
            // Arrange
            var fileMock = new Mock<IFormFile>();
            fileMock.Setup(_ => _.ContentType).Returns("notImage");

            // Act
            var action = async () => await _sut.UpdateUserAvatarAsync(fileMock.Object);

            // Assert
            await Assert.ThrowsAsync<BadRequestException>(action);
        }

        [Fact]
        public async Task UpdateUserAvatarAsync_ShouldReturnImagePath_WhenNoImage()
        {
            // Arrange
            var fileMock = new Mock<IFormFile>();
            var ms = new MemoryStream();
            ms.Position = 0;

            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns("user-profile");
            fileMock.Setup(_ => _.ContentType).Returns("image/png");

            var uniqueFileName = FileNameGeneratorHelper.GenerateUniqueFileName(fileMock.Object.FileName);

            _blobStorageServiceMock.Setup(m => m.UploadNewFileAsync(fileMock.Object))
                .Returns(Task.FromResult(uniqueFileName));

            _blobStorageServiceMock.Setup(m => m.GetFullAvatarPath(uniqueFileName))
                .Returns($"aaa{uniqueFileName}");

            // Act
            var result = await _sut.UpdateUserAvatarAsync(fileMock.Object);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(result);
                Assert.NotNull(result.ImagePath);

                Assert.NotNull(_context.Users.First(u => u.Id == _userIdGetterMock.Object.CurrentUserId).ImagePath);
            });
        }

        [Fact]
        public async Task UpdateUserAvatarAsync_ShouldReturnNewImagePath_WhenImageExists()
        {
            // Arrange
            var fileMock = new Mock<IFormFile>();
            var ms = new MemoryStream();
            ms.Position = 0;

            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns("user-profile");
            fileMock.Setup(_ => _.ContentType).Returns("image/png");

            var uniqueFileName = FileNameGeneratorHelper.GenerateUniqueFileName(fileMock.Object.FileName);

            _blobStorageServiceMock.Setup(m => m.UploadNewFileAsync(fileMock.Object))
                .Returns(Task.FromResult(uniqueFileName));

            _blobStorageServiceMock.Setup(m => m.DeleteProfileAvatarAsync(uniqueFileName))
                .Returns(Task.CompletedTask);

            _blobStorageServiceMock.Setup(m => m.GetFullAvatarPath(uniqueFileName))
                .Returns($"aaa{uniqueFileName}");

            _userIdGetterMock.Reset();
            _userIdGetterMock.Setup(r => r.CurrentUserId).Returns(2);

            var imagePath = _context.Users.First(u => u.ImagePath != null).ImagePath;

            // Act
            var result = await _sut.UpdateUserAvatarAsync(fileMock.Object);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(result);
                Assert.NotNull(result.ImagePath);

                Assert.NotEqual(imagePath, result.ImagePath);
            });
        }

        [Fact]
        public async Task UpdateUserAsync_ShouldThrowException_IfEmailNotUnique()
        {
            // Arrange
            var currentUser = _context.Users.First(u => u.Id == _userIdGetterMock.Object.CurrentUserId);
            var notUniqueEmail = _context.Users.First(u => u.Email != currentUser.Email).Email;
            var userDto = new UserEditDto
            {
                Email = notUniqueEmail,
                UserName = "test"
            };

            // Act
            var action = async () => await _sut.UpdateUserAsync(userDto);

            // Assert
            await Assert.ThrowsAsync<BadRequestException>(action);
        }

        [Fact]
        public async Task UpdateUserAsync_ShouldThrowException_IfUserNameNotUnique()
        {
            // Arrange
            var currentUser = _context.Users.First(u => u.Id == _userIdGetterMock.Object.CurrentUserId);
            var notUniqueUserName = _context.Users.First(u => u.UserName != currentUser.UserName).UserName;
            var userDto = new UserEditDto
            {
                Email = "randomtest@gmail.com",
                UserName = notUniqueUserName
            };

            // Act
            var action = async () => await _sut.UpdateUserAsync(userDto);

            // Assert
            await Assert.ThrowsAsync<BadRequestException>(action);
        }

        [Fact]
        public async Task UpdateUserAsync_ShouldUpdateUser()
        {
            // Arrange
            var userDto = new UserEditDto
            {
                Email = "newEmail@gmail.com",
                UserName = "newUserName"
            };

            // Act
            var result = await _sut.UpdateUserAsync(userDto);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(result);

                Assert.Equal(userDto.Email, result.Email);
                Assert.Equal(userDto.UserName, result.UserName);
            });
        }

        [Fact]
        public void GenerateEmailToken_ShouldReturnToken()
        {
            // Act
            var emailToken = _sut.GenerateEmailToken();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(emailToken);
                Assert.True(Convert.FromBase64String(emailToken).Length == 32);
            });
        }

        [Fact]
        public async Task ResetPasswordAsync_ShouldUpdatePassword()
        {
            // Arrange
            var currentUser = _context.Users.First(u => u.Id == _userIdGetterMock.Object.CurrentUserId);

            var emailToken = _sut.GenerateEmailToken();
            var resetPasswordDto = new ResetPasswordDto
            {
                EmailToken = emailToken,
                Email = currentUser.Email,
                NewPassword = "ResetPassword",
                ConfirmPassword = "ResetPassword"
            };
            var hashedPassword = SecurityHelper.HashPassword(resetPasswordDto.NewPassword, Convert.FromBase64String(currentUser.Salt));

            // Act
            await _sut.ResetPasswordAsync(resetPasswordDto);

            // Assert
            Assert.Equal(currentUser.Password, hashedPassword);
        }
    }
}
