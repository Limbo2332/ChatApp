using ChatApp.Common.Constants;
using ChatApp.Common.DTO.Mail;
using ChatApp.DAL.Context.SeedSettings;
using FluentValidation;

namespace ChatApp.WebAPI.Validators.User
{
    public class ResetEmailValidator : AbstractValidator<ResetEmailDto>
    {
        public ResetEmailValidator()
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
        }
    }
}
