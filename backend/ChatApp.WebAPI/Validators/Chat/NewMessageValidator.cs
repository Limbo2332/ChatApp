using ChatApp.Common.Constants;
using ChatApp.Common.DTO.Message;
using ChatApp.DAL.Context.SeedSettings;
using FluentValidation;

namespace ChatApp.WebAPI.Validators.Chat
{
    public class NewMessageValidator : AbstractValidator<NewMessageDto>
    {
        public NewMessageValidator()
        {
            RuleFor(nm => nm.Value)
                .NotEmpty()
                    .WithMessage(ValidationMessages.NewMessageIsEmptyMessage)
                .MaximumLength(EntityConfigurationSettings.MessageMaxLength)
                    .WithMessage(ValidationMessages.NewMessageMaxLengthMessage);

            RuleFor(nm => nm.ChatId)
                .NotNull()
                    .WithMessage(ValidationMessages.ChatIsNullMessage);
        }
    }
}
