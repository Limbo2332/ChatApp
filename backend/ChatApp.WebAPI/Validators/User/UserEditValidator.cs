using ChatApp.Common.DTO.User;
using ChatApp.WebAPI.Extensions;
using FluentValidation;

namespace ChatApp.WebAPI.Validators.User
{
    public class UserEditValidator : AbstractValidator<UserEditDto>
    {
        public UserEditValidator()
        {
            RuleFor(ur => ur.Email)
                .CustomEmail();

            RuleFor(ur => ur.UserName)
                .CustomUserName();
        }
    }
}
