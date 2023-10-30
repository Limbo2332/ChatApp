﻿using ChatApp.BLL.Interfaces;
using ChatApp.Common.Constants;
using ChatApp.Common.DTO.User;
using ChatApp.DAL.Context.SeedSettings;
using ChatApp.WebAPI.Extensions;
using FluentValidation;

namespace ChatApp.WebAPI.Validators.User
{
    public class UserRegisterValidator : AbstractValidator<UserRegisterDto>
    {
        private readonly IUserService _userService;

        public UserRegisterValidator(IUserService userService)
        {
            _userService = userService;

            RuleFor(ur => ur.Email)
                .CustomEmail()
                .Must(_userService.IsEmailUnique)
                    .WithMessage(ValidationMessages.EmailIsNotUniqueMessage);

            RuleFor(ur => ur.UserName)
                .CustomUserName()
                .Must(_userService.IsUserNameUnique)
                    .WithMessage(ValidationMessages.UsernameIsNotUniqueMessage);

            RuleFor(ur => ur.Password)
                .CustomPassword();
        }
    }
}
