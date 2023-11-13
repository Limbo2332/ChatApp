using ChatApp.Common.DTO.Mail;
using ChatApp.WebAPI.Extensions;
using FluentValidation;

namespace ChatApp.WebAPI.Validators.User
{
    public class ResetEmailValidator : AbstractValidator<ResetEmailDto>
    {
        public ResetEmailValidator()
        {
            RuleFor(ur => ur.Email)
                .CustomEmail();
        }
    }
}
