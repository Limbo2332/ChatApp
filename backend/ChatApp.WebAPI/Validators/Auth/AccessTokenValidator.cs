using ChatApp.Common.Constants;
using ChatApp.Common.DTO.Auth;
using FluentValidation;

namespace ChatApp.WebAPI.Validators.Auth
{
    public class AccessTokenValidator : AbstractValidator<AccessTokenDto>
    {
        public AccessTokenValidator()
        {
            RuleFor(at => at.AccessToken)
                .NotEmpty()
                    .WithMessage(ValidationMessages.AccessTokenIsEmptyMessage);

            RuleFor(at => at.RefreshToken)
                .NotEmpty()
                    .WithMessage(ValidationMessages.RefreshTokenIsEmptyMessage);
        }
    }
}
