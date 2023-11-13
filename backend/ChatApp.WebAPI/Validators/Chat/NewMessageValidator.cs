using ChatApp.Common.Constants;
using ChatApp.Common.DTO.Message;
using ChatApp.WebAPI.Extensions;
using FluentValidation;

namespace ChatApp.WebAPI.Validators.Chat
{
    public class NewMessageValidator : AbstractValidator<NewMessageDto>
    {
        public NewMessageValidator()
        {
            RuleFor(nm => nm.Value)
                .CustomMessageValue();

            RuleFor(nm => nm.ChatId)
                .NotNull()
                    .WithMessage(ValidationMessages.ChatIsNullMessage);
        }
    }
}
