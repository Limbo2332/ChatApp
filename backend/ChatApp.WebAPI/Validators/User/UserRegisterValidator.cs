using ChatApp.BLL.Interfaces;
using ChatApp.Common.Constants;
using ChatApp.Common.DTO.User;
using ChatApp.DAL.Context.SeedSettings;
using FluentValidation;

namespace ChatApp.WebAPI.Validators.User
{
    public class UserRegisterValidator : AbstractValidator<UserRegisterDto>
    {
        private readonly IUserService _userService;

        public UserRegisterValidator(IUserService userService)
        {
            _userService = userService;

            RuleFor(ur => ur.Email)
                .NotEmpty()
                    .WithMessage(ValidationMessages.EmailIsEmptyMessage)
                .EmailAddress()
                    .WithMessage(ValidationMessages.EmailWithWrongFormatMessage)
                .Matches(Regexes.EmailRegex)
                    .WithMessage(ValidationMessages.EmailWithWrongFormatMessage)
                .MinimumLength(EntityConfigurationSettings.EmailMinLength)
                    .WithMessage(ValidationMessages.EmailWithWrongMinimumLengthMessage(EntityConfigurationSettings.EmailMinLength))
                .MaximumLength(EntityConfigurationSettings.EmailMaxLength)
                    .WithMessage(ValidationMessages.EmailWithWrongMaximumLengthMessage(EntityConfigurationSettings.EmailMaxLength))
                .Must(_userService.IsEmailUnique)
                    .WithMessage(ValidationMessages.EmailIsNotUniqueMessage);

            RuleFor(ur => ur.UserName)
                .NotEmpty()
                    .WithMessage(ValidationMessages.UserNameIsEmptyMessage)
                .Matches(Regexes.NoSpacesRegex)
                    .WithMessage(ValidationMessages.UsernameWithWrongFormatMessage)
                .MinimumLength(EntityConfigurationSettings.UserNameMinLength)
                    .WithMessage(ValidationMessages.UserNameWithWrongMinimumLengthMessage(EntityConfigurationSettings.UserNameMinLength))
                .MaximumLength(EntityConfigurationSettings.UserNameMaxLength)
                    .WithMessage(ValidationMessages.UserNameWithWrongMaximumLengthMessage(EntityConfigurationSettings.UserNameMaxLength))
                .Must(_userService.IsUserNameUnique)
                    .WithMessage(ValidationMessages.UsernameIsNotUniqueMessage);

            RuleFor(ur => ur.Password)
                .NotEmpty()
                    .WithMessage(ValidationMessages.PasswordIsEmptyMessage)
                .Matches(Regexes.PasswordRegex)
                    .WithMessage(ValidationMessages.PasswordWithWrongFormatMessage)
                .MinimumLength(EntityConfigurationSettings.PasswordMinLength)
                    .WithMessage(ValidationMessages.PasswordWithWrongMinimumLengthMessage(EntityConfigurationSettings.PasswordMinLength))
                .MaximumLength(EntityConfigurationSettings.PasswordMaxLength)
                    .WithMessage(ValidationMessages.PasswordWithWrongMaximumLengthMessage(EntityConfigurationSettings.PasswordMaxLength));
        }
    }
}
