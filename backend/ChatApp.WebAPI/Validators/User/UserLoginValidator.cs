using ChatApp.Common.Constants;
using ChatApp.Common.DTO.User;
using ChatApp.WebAPI.Extensions;
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
                .Matches(ValidationRegexs.NO_SPACES_REGEX)
                    .WithMessage(ValidationMessages.InvalidUserNameOrEmailMessage);

            RuleFor(ur => ur.Password)
                .CustomPassword();
        }
    }
}
