using ChatApp.Common.Constants;
using ChatApp.Common.DTO.Mail;
using ChatApp.DAL.Context.SeedSettings;
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
