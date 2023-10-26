using Microsoft.AspNetCore.Http;

namespace ChatApp.BLL.Interfaces
{
    public interface IBlobStorageService
    {
        Task<string> UploadNewProfileAvatarAsync(IFormFile newAvatar);

        string GetFullAvatarPath(string uniqueImageName);

        Task DeleteProfileAvatarAsync(string uniqueImageName);
    }
}
