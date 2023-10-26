using ChatApp.Common.DTO.User;
using ChatApp.DAL.Entities;
using Microsoft.AspNetCore.Http;

namespace ChatApp.BLL.Interfaces
{
    public interface IUserService
    {
        bool IsEmailUnique(string email);

        bool IsUserNameUnique(string userName);

        Task<User> FindUserByUsernameAsync(string userName);

        Task<UserAvatarDto> UpdateUserAvatarAsync(IFormFile newAvatar);
    }
}
