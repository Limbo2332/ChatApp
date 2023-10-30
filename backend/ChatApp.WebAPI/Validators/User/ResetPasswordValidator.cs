using ChatApp.Common.Constants;
using ChatApp.Common.DTO.User;
using ChatApp.DAL.Context.SeedSettings;
using ChatApp.WebAPI.Extensions;
using FluentValidation;

namespace ChatApp.WebAPI.Validators.User
{
    public class ResetPasswordValidator : AbstractValidator<ResetPasswordDto>
    {
        public ResetPasswordValidator()
        {
            RuleFor(ur => ur.Email)
                .CustomEmail();

            RuleFor(ur => ur.EmailToken)
                .NotEmpty()
                    .WithMessage(ValidationMessages.EmailTokenIsEmpty);

            RuleFor(ur => ur.NewPassword)
                .CustomPassword();

            RuleFor(ur => ur.ConfirmPassword)
                .CustomPassword()
                .Equal(ur => ur.NewPassword)
                    .WithMessage(ValidationMessages.PasswordAreNotTheSame);
        }
    }
}
