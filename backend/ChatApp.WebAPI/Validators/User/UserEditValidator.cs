using ChatApp.BLL.Interfaces;
using ChatApp.Common.Constants;
using ChatApp.Common.DTO.User;
using ChatApp.DAL.Context.SeedSettings;
using FluentValidation;

namespace ChatApp.WebAPI.Validators.User
{
    public class UserEditValidator : AbstractValidator<UserEditDto>
    {
        public UserEditValidator()
        {
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
                    .WithMessage(ValidationMessages.EmailWithWrongMaximumLengthMessage(EntityConfigurationSettings.EmailMaxLength));

            RuleFor(ur => ur.UserName)
                .NotEmpty()
                    .WithMessage(ValidationMessages.UserNameIsEmptyMessage)
                .Matches(Regexes.NoSpacesRegex)
                    .WithMessage(ValidationMessages.UsernameWithWrongFormatMessage)
                .MinimumLength(EntityConfigurationSettings.UserNameMinLength)
                    .WithMessage(ValidationMessages.UserNameWithWrongMinimumLengthMessage(EntityConfigurationSettings.UserNameMinLength))
                .MaximumLength(EntityConfigurationSettings.UserNameMaxLength)
                    .WithMessage(ValidationMessages.UserNameWithWrongMaximumLengthMessage(EntityConfigurationSettings.UserNameMaxLength));
        }
    }
}
