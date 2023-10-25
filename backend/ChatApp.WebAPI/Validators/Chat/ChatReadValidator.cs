using ChatApp.Common.DTO.Chat;
using FluentValidation;

namespace ChatApp.WebAPI.Validators.Chat
{
    public class ChatReadValidator : AbstractValidator<ChatReadDto>
    {
        public ChatReadValidator()
        {
            RuleFor(cr => cr.Id)
                .NotEmpty();

            RuleFor(cr => cr.UserId)
                .NotEmpty();
        }
    }
}
