using ChatApp.Common.DTO.Mail;
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
        
        Task<BlobImage> UpdateUserSqlAvatarAsync(IFormFile newAvatar);

        Task<UserDto> UpdateUserAsync(UserEditDto user);

        Task<MailDto?> SendResetEmailAsync(string email);

        Task ResetPasswordAsync(ResetPasswordDto newInfo);

        string GenerateEmailToken();

        Task<User> GetCurrentUserAsync();
    }
}
