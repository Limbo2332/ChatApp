using ChatApp.Common.Constants;
using ChatApp.Common.DTO.Chat;
using ChatApp.DAL.Context.SeedSettings;
using ChatApp.WebAPI.Extensions;
using FluentValidation;

namespace ChatApp.WebAPI.Validators.Chat
{
    public class NewChatValidator : AbstractValidator<NewChatDto>
    {
        public NewChatValidator()
        {
            RuleFor(nc => nc.UserName)
                .CustomUserName();

            RuleFor(nc => nc.NewMessage)
                .CustomMessageValue();
        }
    }
}
