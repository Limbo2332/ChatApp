using AutoMapper;
using ChatApp.BLL.Interfaces;
using ChatApp.BLL.Services.Abstract;
using ChatApp.Common.Constants;
using ChatApp.Common.DTO.Mail;
using ChatApp.Common.DTO.User;
using ChatApp.Common.Exceptions;
using ChatApp.Common.Helpers;
using ChatApp.Common.Logic.Abstract;
using ChatApp.Common.Security;
using ChatApp.DAL.Context;
using ChatApp.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace ChatApp.BLL.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IBlobStorageService _blobStorageService;
        private readonly IEmailService _emailService;

        public UserService(ChatAppContext context, IMapper mapper, IUserIdGetter userIdGetter, IBlobStorageService blobStorageService, IEmailService emailService)
            : base(context, mapper, userIdGetter)
        {
            _blobStorageService = blobStorageService;
            _emailService = emailService;
        }

        public bool IsEmailUnique(string email)
        {
            return !_context.Users.Any(u => u.Email == email);
        }

        public bool IsUserNameUnique(string userName)
        {
            return !_context.Users.Any(u => u.UserName == userName);
        }

        public async Task<User> FindUserByUsernameAsync(string userName)
        {
            return await _context.Users
                .FirstOrDefaultAsync(user => user.UserName.ToLower() == userName.ToLower())
                ?? throw new BadRequestException($"User with username {userName} doesn't exist");
        }

        public async Task<UserAvatarDto> UpdateUserAvatarAsync(IFormFile newAvatar)
        {
            if (!ValidateImageFormat(newAvatar.ContentType))
            {
                throw new BadRequestException("Image type is wrong.");
            }

            var user = await GetCurrentUserAsync();

            var newImagePath = await _blobStorageService.UploadNewFileAsync(newAvatar);

            if (user.ImagePath is not null)
            {
                await _blobStorageService.DeleteProfileAvatarAsync(user.ImagePath);
            }

            user.ImagePath = newImagePath;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return new UserAvatarDto()
            {
                ImagePath = _blobStorageService.GetFullAvatarPath(newImagePath)
            };
        }

        public async Task<UserDto> UpdateUserAsync(UserEditDto user)
        {
            var currentUser = await GetCurrentUserAsync();

            if(currentUser.Email != user.Email && !IsEmailUnique(user.Email))
            {
                throw new BadRequestException(ValidationMessages.EmailIsNotUniqueMessage);
            }

            currentUser.Email = user.Email;

            if(currentUser.UserName != user.UserName && !IsUserNameUnique(user.UserName))
            {
                throw new BadRequestException(ValidationMessages.UsernameIsNotUniqueMessage);
            }

            currentUser.UserName = user.UserName;

            _context.Users.Update(currentUser);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserDto>(currentUser);
        }

        public async Task SendResetEmailAsync(string email)
        {
            var emailToken = GenerateEmailToken();

            var mail = new MailDto
            {
                Subject = "Reset password",
                Content = ResetEmailContentGenerator.EmailResetStringBody(email, emailToken),
                To = email
            };

            await _emailService.SendEmailAsync(mail);
        }

        public async Task ResetPasswordAsync(ResetPasswordDto newInfo)
        {
            var user = await _context.Users.FirstAsync(user => user.Email == newInfo.Email);

            user.Password = SecurityHelper.HashPassword(newInfo.NewPassword, Convert.FromBase64String(user.Salt));

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        private async Task<User> GetCurrentUserAsync()
        {
            int currentUserId = _userIdGetter.CurrentUserId;

            return await _context.Users.FirstAsync(user => user.Id == currentUserId);
        }

        private string GenerateEmailToken()
        {
            var tokenBytes = RandomNumberGenerator.GetBytes(32);

            return Convert.ToBase64String(tokenBytes);
        }

        private bool ValidateImageFormat(string imageType)
        {
            var idxDot = imageType.LastIndexOf('.') + 1;
            var extFile = imageType.Substring(idxDot, imageType.Length).ToLower();

            return extFile == "jpg" || extFile == "jpeg" || extFile == "png";
        }
    }
}
