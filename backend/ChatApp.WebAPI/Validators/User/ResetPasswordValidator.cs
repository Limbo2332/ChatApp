using ChatApp.Common.Constants;
using ChatApp.Common.DTO.User;
using ChatApp.DAL.Context.SeedSettings;
using FluentValidation;

namespace ChatApp.WebAPI.Validators.User
{
    public class ResetPasswordValidator : AbstractValidator<ResetPasswordDto>
    {
        public ResetPasswordValidator()
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

            RuleFor(ur => ur.EmailToken)
                .NotEmpty()
                    .WithMessage(ValidationMessages.EmailTokenIsEmpty);

            RuleFor(ur => ur.NewPassword)
                .NotEmpty()
                    .WithMessage(ValidationMessages.PasswordIsEmptyMessage)
                .Matches(Regexes.PasswordRegex)
                    .WithMessage(ValidationMessages.PasswordWithWrongFormatMessage)
                .MinimumLength(EntityConfigurationSettings.PasswordMinLength)
                    .WithMessage(ValidationMessages.PasswordWithWrongMinimumLengthMessage(EntityConfigurationSettings.PasswordMinLength))
                .MaximumLength(EntityConfigurationSettings.PasswordMaxLength)
                    .WithMessage(ValidationMessages.PasswordWithWrongMaximumLengthMessage(EntityConfigurationSettings.PasswordMaxLength));

            RuleFor(ur => ur.ConfirmPassword)
                 .NotEmpty()
                    .WithMessage(ValidationMessages.PasswordIsEmptyMessage)
                .Matches(Regexes.PasswordRegex)
                    .WithMessage(ValidationMessages.PasswordWithWrongFormatMessage)
                .MinimumLength(EntityConfigurationSettings.PasswordMinLength)
                    .WithMessage(ValidationMessages.PasswordWithWrongMinimumLengthMessage(EntityConfigurationSettings.PasswordMinLength))
                .MaximumLength(EntityConfigurationSettings.PasswordMaxLength)
                    .WithMessage(ValidationMessages.PasswordWithWrongMaximumLengthMessage(EntityConfigurationSettings.PasswordMaxLength))
                .Equal(ur => ur.NewPassword)
                    .WithMessage(ValidationMessages.PasswordAreNotTheSame);
        }
    }
}
