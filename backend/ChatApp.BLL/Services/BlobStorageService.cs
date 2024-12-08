using AutoMapper;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using ChatApp.BLL.Interfaces;
using ChatApp.BLL.Services.Abstract;
using ChatApp.Common.Helpers;
using ChatApp.Common.Logic.Abstract;
using Microsoft.AspNetCore.Http;

namespace ChatApp.BLL.Services
{
    public class BlobStorageService : BaseService, IBlobStorageService
    {
        private readonly BlobContainerClient _blobContainerClient;

        public BlobStorageService(
            IMapper mapper,
            IUserIdGetter userIdGetter,
            BlobContainerClient blobContainerClient)
            : base(mapper, userIdGetter)
        {
            _blobContainerClient = blobContainerClient;
        }

        public async Task<string> UploadNewFileAsync(IFormFile newAvatar)
        {
            var uniqueImageName = FileNameGeneratorHelper.GenerateUniqueFileName(newAvatar.FileName);

            var blobInstance = _blobContainerClient.GetBlobClient(uniqueImageName);

            var blobHttpHeaders = new BlobHttpHeaders
            {
                ContentType = newAvatar.ContentType,
                ContentDisposition = newAvatar.ContentDisposition,
            };

            var uploadOptions = new BlobUploadOptions
            {
                HttpHeaders = blobHttpHeaders,
            };

            await blobInstance.UploadAsync(newAvatar.OpenReadStream(), uploadOptions);

            return uniqueImageName;
        }

        public string GetFullAvatarPath(string uniqueImageName)
        {
            return _blobContainerClient.GetBlobClient(uniqueImageName).Uri.AbsoluteUri;
        }

        public async Task DeleteProfileAvatarAsync(string uniqueImageName)
        {
            var client = _blobContainerClient.GetBlobClient(uniqueImageName);

            await client.DeleteIfExistsAsync();
        }
    }
}
