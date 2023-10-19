using ChatApp.Common.Constants;
using ChatApp.Common.DTO.User;
using ChatApp.DAL.Context.SeedSettings;
using FluentValidation;

namespace ChatApp.WebAPI.Validators.User
{
    public class UserLoginValidator : AbstractValidator<UserLoginDto>
    {
        public UserLoginValidator()
        {
            RuleFor(ur => ur.EmailOrUserName)
                .NotEmpty()
                    .WithMessage(ValidationMessages.InvalidUserNameOrEmailMessage)
                .Matches(Regexes.NoSpacesRegex)
                    .WithMessage(ValidationMessages.InvalidUserNameOrEmailMessage);

            RuleFor(ur => ur.Password)
                .NotEmpty()
                    .WithMessage(ValidationMessages.InvalidUserNameOrEmailMessage)
                .Matches(Regexes.PasswordRegex)
                    .WithMessage(ValidationMessages.InvalidUserNameOrEmailMessage)
                .MinimumLength(EntityConfigurationSettings.PasswordMinLength)
                    .WithMessage(ValidationMessages.InvalidUserNameOrEmailMessage)
                .MaximumLength(EntityConfigurationSettings.PasswordMaxLength)
                    .WithMessage(ValidationMessages.InvalidUserNameOrEmailMessage);
        }
    }
}
