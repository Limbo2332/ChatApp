using AutoMapper;
using ChatApp.BLL.Interfaces;
using ChatApp.BLL.Services.Abstract;
using ChatApp.Common.Constants;
using ChatApp.Common.DTO.User;
using ChatApp.Common.Exceptions;
using ChatApp.Common.Logic.Abstract;
using ChatApp.DAL.Context;
using ChatApp.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.BLL.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IBlobStorageService _blobStorageService;

        public UserService(ChatAppContext context, IMapper mapper, IUserIdGetter userIdGetter, IBlobStorageService blobStorageService)
            : base(context, mapper, userIdGetter)
        {
            _blobStorageService = blobStorageService;
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

        private async Task<User> GetCurrentUserAsync()
        {
            int currentUserId = _userIdGetter.CurrentUserId;

            return await _context.Users.FirstAsync(user => user.Id == currentUserId);
        }
    }
}
