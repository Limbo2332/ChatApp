using Azure.Communication.Email;
using ChatApp.BLL.Interfaces;
using ChatApp.BLL.Services;
using ChatApp.Common.Constants;
using ChatApp.Common.DTO.Mail;
using ChatApp.Common.DTO.User;
using ChatApp.Common.Exceptions;
using ChatApp.Common.Helpers;
using ChatApp.Common.Security;
using ChatApp.DAL.Entities;
using ChatApp.DAL.Repositories.Abstract;
using ChatApp.UnitTests.Systems.Services.Abstract;
using ChatApp.UnitTests.TestData;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace ChatApp.UnitTests.Systems.Services
{
    public class UserServiceTests : BaseServiceTests
    {
        private readonly IUserService _sut;
        private readonly Mock<IBlobStorageService> _blobStorageServiceMock = new Mock<IBlobStorageService>();
        private readonly Mock<IEmailService> _emailServiceMock = new Mock<IEmailService>();
        private readonly Mock<IUserRepository> _userRepository = new Mock<IUserRepository>();
        private readonly Mock<IImageRepository> _imageRepository = new Mock<IImageRepository>();

        public UserServiceTests()
            : base()
        {
            _sut = new UserService(
                _mapper,
                _userIdGetterMock.Object,
                _blobStorageServiceMock.Object,
                _emailServiceMock.Object,
                _userRepository.Object,
                _imageRepository.Object);

            _userRepository
                .Setup(ur => ur.GetAll())
                .Returns(DbContextTestData.Users);
        }

        [Fact]
        public void IsEmailUnique_ShouldReturn_True_WhenNoEmail()
        {
            // Arrange
            var uniqueEmail = "uniqueEmail@hgf.net";

            // Act
            var result = _sut.IsEmailUnique(uniqueEmail);

            // Assert
            result.Should().BeTrue();
        }

        [Theory]
        [ClassData(typeof(UsersTestData))]
        public void IsEmailUnique_Should_ReturnFalse_WhenEmailAlreadyExists(User user)
        {
            // Arrange
            var notUniqueEmail = user.Email;

            // Act
            var result = _sut.IsEmailUnique(notUniqueEmail);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void IsUserNameUnique_Should_ReturnTrue_WhenNoUserName()
        {
            // Arrange
            var uniqueUserName = "uniqueUSerName";

            // Act
            var result = _sut.IsUserNameUnique(uniqueUserName);

            // Assert
            result.Should().BeTrue();
        }

        [Theory]
        [ClassData(typeof(UsersTestData))]
        public void IsUserNamelUnique_Should_ReturnFalse_WhenUserName(User user)
        {
            // Arrange
            var notUniqueUserName = user.UserName;

            // Act
            var result = _sut.IsUserNameUnique(notUniqueUserName);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public async Task FindUserByUsernameAsync_Should_ThrowException_WhenNoUser()
        {
            // Arrange
            var uniqueUserName = "uniqueUserName";

            // Act
            var action = async () => await _sut.FindUserByUsernameAsync(uniqueUserName);

            // Assert
            await action
                .Should()
                .ThrowAsync<BadRequestException>()
                .WithMessage($"User with username {uniqueUserName} doesn't exist");
        }

        [Theory]
        [ClassData(typeof(UsersTestData))]
        public async Task FindUserByUsernameAsync_Should_ReturnUser_WhenUserExists(User user)
        {
            // Arrange
            var notUniqueUserName = user.UserName;

            _userRepository
                .Setup(ur => ur.GetByExpressionAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(user);

            // Act
            var result = await _sut.FindUserByUsernameAsync(notUniqueUserName);

            // Assert
            using (new AssertionScope())
            {
                result.Should().NotBeNull();
                result.UserName.Should().BeEquivalentTo(notUniqueUserName);
            }
        }

        [Fact]
        public async Task UpdateUserAvatarAsync_Should_ThrowException_WhenWrongImageFormat()
        {
            // Arrange
            var fileMock = new Mock<IFormFile>();
            fileMock.Setup(_ => _.ContentType).Returns("notImage");

            // Act
            var action = async () => await _sut.UpdateUserAvatarAsync(fileMock.Object);

            // Assert
            await action
                .Should()
                .ThrowAsync<BadRequestException>()
                .WithMessage("Image type is wrong.");
        }

        [Theory]
        [ClassData(typeof(UsersTestData))]
        public async Task UpdateUserAvatarAsync_Should_ReturnImagePath_WhenNoImage(User user)
        {
            // Arrange
            var fileMock = new Mock<IFormFile>();

            fileMock
                .Setup(file => file.OpenReadStream())
                .Returns(It.IsAny<MemoryStream>());

            fileMock
                .Setup(file => file.FileName)
                .Returns("user-profile");

            fileMock
                .Setup(file => file.ContentType)
                .Returns("image/png");

            var uniqueFileName = FileNameGeneratorHelper
                .GenerateUniqueFileName(fileMock.Object.FileName);

            _blobStorageServiceMock
                .Setup(m => m.UploadNewFileAsync(fileMock.Object))
                .ReturnsAsync(uniqueFileName);

            _blobStorageServiceMock
                .Setup(m => m.GetFullAvatarPath(uniqueFileName))
                .Returns($"aaa{uniqueFileName}");

/*            _userRepository
                .Setup(ur => ur.UpdateAsync(It.IsAny<User>()))
                .Callback(() => user.Image.ImagePath = $"aaa{uniqueFileName}")
                .ReturnsAsync(user);*/

            _userRepository
                .Setup(ur => ur.GetByExpressionAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(user);

            // Act
            var result = await _sut.UpdateUserAvatarAsync(fileMock.Object);

            // Assert
            using (new AssertionScope())
            {
                result.Should().NotBeNull();
                result.ImagePath.Should().NotBeNull();
/*
                user.Image.Should().NotBeNull();
                user.Image!.ImagePath.Should().BeEquivalentTo(result.ImagePath);*/
            }
        }

        [Theory]
        [ClassData(typeof(UsersTestData))]
        public async Task UpdateUserAvatarAsync_Should_ReturnNewImagePath_WhenImageExists(User user)
        {
            // Arrange
            var fileMock = new Mock<IFormFile>();

            fileMock
                .Setup(file => file.OpenReadStream())
                .Returns(It.IsAny<MemoryStream>());

            fileMock
                .Setup(file => file.FileName)
                .Returns("user-profile");

            fileMock
                .Setup(file => file.ContentType)
                .Returns("image/jpg");

            var uniqueFileName = FileNameGeneratorHelper
                .GenerateUniqueFileName(fileMock.Object.FileName);

            _blobStorageServiceMock
                .Setup(m => m.UploadNewFileAsync(fileMock.Object))
                .ReturnsAsync(uniqueFileName);

            _blobStorageServiceMock
                .Setup(m => m.DeleteProfileAvatarAsync(uniqueFileName))
                .Returns(Task.CompletedTask);

            _blobStorageServiceMock
                .Setup(m => m.GetFullAvatarPath(uniqueFileName))
                .Returns($"aaa{uniqueFileName}");

            _userRepository
                .Setup(ur => ur.GetByExpressionAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(user);

            // Act
            var result = await _sut.UpdateUserAvatarAsync(fileMock.Object);

            // Assert
            using (new AssertionScope())
            {
                result.Should().NotBeNull();
                result.ImagePath.Should().NotBeNull();
/*                result.ImagePath.Should().NotBeEquivalentTo(user.Image.ImagePath);*/
            }
        }

        [Theory]
        [ClassData(typeof(UsersTestData))]
        public async Task UpdateUserAsync_Should_ThrowException_IfEmailNotUnique(User user)
        {
            // Arrange
            var notSameUser = DbContextTestData.Users.First(u => u.Id != user.Id);
            var notUniqueEmail = notSameUser.Email;

            var userDto = new UserEditDto
            {
                Email = notUniqueEmail
            };

            _userRepository
                .Setup(ur => ur.GetByExpressionAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(user);

            // Act
            var action = async () => await _sut.UpdateUserAsync(userDto);

            // Assert
            await action
                .Should()
                .ThrowAsync<BadRequestException>(ValidationMessages.EMAIL_IS_NOT_UNIQUE_MESSAGE);
        }

        [Theory]
        [ClassData(typeof(UsersTestData))]
        public async Task UpdateUserAsync_Should_ThrowException_IfUserNameNotUnique(User user)
        {
            // Arrange
            var notSameUser = DbContextTestData.Users.First(u => u.Id != user.Id);
            var notUniqueUserName = notSameUser.UserName;

            var userDto = new UserEditDto
            {
                UserName = notUniqueUserName
            };

            _userRepository
                .Setup(ur => ur.GetByExpressionAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(user);

            // Act
            var action = async () => await _sut.UpdateUserAsync(userDto);

            // Assert
            await action
                .Should()
                .ThrowAsync<BadRequestException>()
                .WithMessage(ValidationMessages.UsernameIsNotUniqueMessage);
        }

        [Fact]
        public async Task UpdateUserAsync_Should_UpdateUser()
        {
            // Arrange
            var userDto = new UserEditDto
            {
                Email = "newEmail@gmail.com",
                UserName = "newUserName"
            };

            var user = DbContextTestData.Users.First();

            _userRepository
                .Setup(ur => ur.GetByExpressionAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(user);

            // Act
            var result = await _sut.UpdateUserAsync(userDto);

            // Assert
            using (new AssertionScope())
            {
                result.Should().NotBeNull();

                result.Email.Should().BeEquivalentTo(userDto.Email);
                result.UserName.Should().BeEquivalentTo(userDto.UserName);
            }
        }

        [Fact]
        public void GenerateEmailToken_Should_ReturnToken()
        {
            // Act
            var emailToken = _sut.GenerateEmailToken();

            // Assert
            using (new AssertionScope())
            {
                emailToken.Should().NotBeNull();
                Convert.FromBase64String(emailToken).Length.Should().Be(32);
            }
        }

        [Fact]
        public async Task SendResetEmailAsync_Should_ReturnNull_WhenNotExistingEmail()
        {
            // Arrange
            var operation = new Mock<EmailSendOperation>();
            operation
                .Setup(o => o.HasCompleted)
                .Returns(false);

            _emailServiceMock
                .Setup(es => es.SendEmailAsync(It.IsAny<MailDto>()))
                .ReturnsAsync(operation.Object);

            // Act
            var result = await _sut.SendResetEmailAsync(It.IsAny<string>());

            // Assert
            result.Should().BeNull();
        }

        [Theory]
        [ClassData(typeof(UsersTestData))]
        public async Task SendResetEmailAsync_Should_Complete(User user)
        {
            // Arrange
            var email = user.Email;
            var subject = "Reset password";

            var operation = new Mock<EmailSendOperation>();
            operation
                .Setup(o => o.HasCompleted)
                .Returns(true);

            _emailServiceMock
                .Setup(es => es.SendEmailAsync(It.IsAny<MailDto>()))
                .ReturnsAsync(operation.Object);

            // Act
            var result = await _sut.SendResetEmailAsync(email);

            // Assert
            using (new AssertionScope())
            {
                result.Should().NotBeNull();

                result!.Subject.Should().BeEquivalentTo(subject);
                result!.To.Should().BeEquivalentTo(email);
                result!.Content.Should().BeOfType<string>();
            }
        }

        [Fact]
        public async Task ResetPasswordAsync_Should_ThrowException_WhenNoUser()
        {
            // Arrange
            var resetPasswordDto = new ResetPasswordDto
            {
                Email = "uniqueEmail",
            };

            _userRepository
                .Setup(ur => ur.GetByExpressionAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(It.IsAny<User>());

            // Act
            var action = async () => await _sut.ResetPasswordAsync(resetPasswordDto);

            // Assert
            await action
                .Should()
                .ThrowAsync<BadRequestException>()
                .WithMessage($"User with email {resetPasswordDto.Email} doesn't exist");
        }

        [Theory]
        [ClassData(typeof(UsersTestData))]
        public async Task ResetPasswordAsync_Should_UpdatePassword(User user)
        {
            // Arrange
            var emailToken = _sut.GenerateEmailToken();

            var resetPasswordDto = new ResetPasswordDto
            {
                EmailToken = emailToken,
                Email = user.Email,
                NewPassword = "ResetPassword",
                ConfirmPassword = "ResetPassword"
            };

            var hashedPassword = SecurityHelper.HashPassword(
                resetPasswordDto.NewPassword,
                Convert.FromBase64String(user.Salt));

            _userRepository
                .Setup(ur => ur.GetByExpressionAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(user);

            // Act
            await _sut.ResetPasswordAsync(resetPasswordDto);

            // Assert
            user.Password.Should().BeEquivalentTo(hashedPassword);
        }

        [Fact]
        public async Task GetCurrentUserAsync_Should_ThrowException_WhenNoUser()
        {
            // Arrange
            _userRepository
                .Setup(ur => ur.GetByExpressionAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(It.IsAny<User>);

            // Act
            var action = _sut.GetCurrentUserAsync;

            // Assert
            await action
                .Should()
                .ThrowAsync<NotFoundException>($"User with id {_userIdGetterMock.Object.CurrentUserId} was not found");
        }
    }
}
