using ChatApp.Common.Constants;
using ChatApp.Common.DTO.Chat;
using FluentValidation;

namespace ChatApp.WebAPI.Validators.Chat
{
    public class ChatReadValidator : AbstractValidator<ChatReadDto>
    {
        public ChatReadValidator()
        {
            RuleFor(cr => cr.Id)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.ID_IS_EMPTY_MESSAGE)
                .NotEmpty()
                    .WithMessage(ValidationMessages.ID_IS_EMPTY_MESSAGE);

            RuleFor(cr => cr.UserId)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.USERID_IS_EMPTY_MESSAGE)
                .NotEmpty()
                    .WithMessage(ValidationMessages.USERID_IS_EMPTY_MESSAGE);
        }
    }
}
