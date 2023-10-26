using AutoMapper;
using ChatApp.BLL.Interfaces;
using ChatApp.BLL.Services.Abstract;
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
            int currentUserId = _userIdGetter.CurrentUserId;

            var user = await _context.Users.FirstAsync(user => user.Id == currentUserId);

            var newImagePath = await _blobStorageService.UploadNewProfileAvatarAsync(newAvatar);

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
    }
}
