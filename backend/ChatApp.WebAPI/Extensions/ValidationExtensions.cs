using ChatApp.Common.Constants;
using ChatApp.DAL.Context.SeedSettings;
using FluentValidation;

namespace ChatApp.WebAPI.Extensions
{
    public static class ValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> CustomEmail<T>(this IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty()
                    .WithMessage(ValidationMessages.EmailIsEmptyMessage)
                .EmailAddress()
                    .WithMessage(ValidationMessages.EmailWithWrongFormatMessage)
                .Matches(Regexes.EmailRegex)
                    .WithMessage(ValidationMessages.EmailWithWrongFormatMessage)
                .MinimumLength(EntityConfigurationSettings.EmailMinLength)
                    .WithMessage(ValidationMessages.EmailWithWrongMinimumLengthMessage(EntityConfigurationSettings.EmailMinLength))
                .MaximumLength(EntityConfigurationSettings.EmailMaxLength)
                    .WithMessage(ValidationMessages.EmailWithWrongMaximumLengthMessage(EntityConfigurationSettings.EmailMaxLength));
        }

        public static IRuleBuilderOptions<T, string> CustomPassword<T>(this IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty()
                    .WithMessage(ValidationMessages.PasswordIsEmptyMessage)
                .Matches(Regexes.PasswordRegex)
                    .WithMessage(ValidationMessages.PasswordWithWrongFormatMessage)
                .MinimumLength(EntityConfigurationSettings.PasswordMinLength)
                    .WithMessage(ValidationMessages.PasswordWithWrongMinimumLengthMessage(EntityConfigurationSettings.PasswordMinLength))
                .MaximumLength(EntityConfigurationSettings.PasswordMaxLength)
                    .WithMessage(ValidationMessages.PasswordWithWrongMaximumLengthMessage(EntityConfigurationSettings.PasswordMaxLength));
        }

        public static IRuleBuilderOptions<T, string> CustomUserName<T>(this IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty()
                    .WithMessage(ValidationMessages.UserNameIsEmptyMessage)
                .Matches(Regexes.NoSpacesRegex)
                    .WithMessage(ValidationMessages.UsernameWithWrongFormatMessage)
                .MinimumLength(EntityConfigurationSettings.UserNameMinLength)
                    .WithMessage(ValidationMessages.UserNameWithWrongMinimumLengthMessage(EntityConfigurationSettings.UserNameMinLength))
                .MaximumLength(EntityConfigurationSettings.UserNameMaxLength)
                    .WithMessage(ValidationMessages.UserNameWithWrongMaximumLengthMessage(EntityConfigurationSettings.UserNameMaxLength));
        }

        public static IRuleBuilderOptions<T, string> CustomMessageValue<T>(this IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty()
                    .WithMessage(ValidationMessages.NewMessageIsEmptyMessage)
                .MaximumLength(EntityConfigurationSettings.MessageMaxLength)
                    .WithMessage(ValidationMessages.NewMessageMaxLengthMessage);
        }
    }
}
