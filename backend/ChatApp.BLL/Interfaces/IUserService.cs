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

        Task<UserDto> UpdateUserAsync(UserEditDto user);

        Task<bool> SendResetEmailAsync(string email);

        Task ResetPasswordAsync(ResetPasswordDto newInfo);

        string GenerateEmailToken();
    }
}
