using ChatApp.BLL.Interfaces;
using ChatApp.Common.Constants;
using ChatApp.Common.DTO.User;
using ChatApp.UnitTests.TestData.Validators.User;
using ChatApp.WebAPI.Validators.User;
using FluentValidation.TestHelper;

namespace ChatApp.UnitTests.Systems.Validators.User
{
    public class UserRegisterValidatorTests
    {
        private readonly IUserService _userService = Substitute.For<IUserService>();
        private readonly UserRegisterValidator _sut;

        public UserRegisterValidatorTests()
        {
            _sut = new UserRegisterValidator(_userService);
        }

        [Fact]
        public async Task ValidateUserRegister_Should_Fail_WhenWrongData()
        {
            // Arrange
            var userRegister = new UserRegisterDto()
            {
                UserName = string.Empty,
                Email = string.Empty,
                Password = string.Empty,
            };

            _userService
                .IsEmailUnique(userRegister.Email)
                .Returns(false);

            _userService
                .IsUserNameUnique(userRegister.UserName)
                .Returns(false);

            // Act
            var result = await _sut.TestValidateAsync(userRegister);

            // Assert
            result
                .ShouldHaveValidationErrorFor(x => x.Email)
                .WithErrorMessage(ValidationMessages.EMAIL_IS_EMPTY_MESSAGE);
            result
                .ShouldHaveValidationErrorFor(x => x.UserName)
                .WithErrorMessage(ValidationMessages.UserNameIsEmptyMessage);
            result
                .ShouldHaveValidationErrorFor(x => x.Password)
                .WithErrorMessage(ValidationMessages.PasswordIsEmptyMessage);
        }

        [Fact]
        public async Task ValidateUserRegister_Should_Fail_WhenEmailIsNotUnique()
        {
            // Arrange
            var userRegister = new UserRegisterDto
            {
                Email = "email@gmail.com",
                Password = "12345aA!",
                UserName = "My UserName"
            };

            _userService
                .IsEmailUnique(userRegister.Email)
                .Returns(false);

            _userService
                .IsUserNameUnique(userRegister.UserName)
                .Returns(false);

            // Act
            var result = await _sut.TestValidateAsync(userRegister);

            // Assert
            result
                .ShouldHaveValidationErrorFor(x => x.Email)
                .WithErrorMessage(ValidationMessages.EMAIL_IS_NOT_UNIQUE_MESSAGE);
        }

        [Fact]
        public async Task ValidateUserRegister_Should_Fail_WhenUserNameIsNotUnique()
        {
            // Arrange
            var userRegister = new UserRegisterDto
            {
                Email = "email@gmail.com",
                Password = "12345aA!",
                UserName = "userName"
            };

            _userService
                .IsEmailUnique(userRegister.Email)
                .Returns(false);

            _userService
                .IsUserNameUnique(userRegister.UserName)
                .Returns(false);

            // Act
            var result = await _sut.TestValidateAsync(userRegister);

            // Assert
            result
                .ShouldHaveValidationErrorFor(x => x.UserName)
                .WithErrorMessage(ValidationMessages.UsernameIsNotUniqueMessage);
        }

        [Theory]
        [ClassData(typeof(UserRegisterValidatorCorrectData))]
        public async Task ValidateUserRegister_Should_Success_WhenCorrectData(UserRegisterDto userRegisterDto)
        {
            // Arrange
            _userService
                .IsEmailUnique(userRegisterDto.Email)
                .Returns(true);

            _userService
                .IsUserNameUnique(userRegisterDto.UserName)
                .Returns(true);

            // Act
            var result = await _sut.TestValidateAsync(userRegisterDto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Email);
            result.ShouldNotHaveValidationErrorFor(x => x.Password);
            result.ShouldNotHaveValidationErrorFor(x => x.UserName);
        }
    }
}
