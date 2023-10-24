using ChatApp.Common.Constants;
using ChatApp.Common.DTO.Chat;
using ChatApp.DAL.Context.SeedSettings;
using FluentValidation;

namespace ChatApp.WebAPI.Validators.Chat
{
    public class NewChatValidator : AbstractValidator<NewChatDto>
    {
        public NewChatValidator()
        {
            RuleFor(nc => nc.UserName)
                .NotEmpty()
                    .WithMessage(ValidationMessages.UserNameIsEmptyMessage)
                .Matches(Regexes.NoSpacesRegex)
                    .WithMessage(ValidationMessages.UsernameWithWrongFormatMessage)
                .MinimumLength(EntityConfigurationSettings.UserNameMinLength)
                    .WithMessage(ValidationMessages.UserNameWithWrongMinimumLengthMessage(EntityConfigurationSettings.UserNameMinLength))
                .MaximumLength(EntityConfigurationSettings.UserNameMaxLength)
                    .WithMessage(ValidationMessages.UserNameWithWrongMaximumLengthMessage(EntityConfigurationSettings.UserNameMaxLength));

            RuleFor(nc => nc.NewMessage)
                .NotEmpty()
                    .WithMessage(ValidationMessages.NewMessageIsEmptyMessage)
                .MaximumLength(EntityConfigurationSettings.MessageMaxLength)
                    .WithMessage(ValidationMessages.NewMessageMaxLengthMessage);
        }
    }
}
