using AutoMapper;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using ChatApp.BLL.Interfaces;
using ChatApp.BLL.Services.Abstract;
using ChatApp.Common.Helpers;
using ChatApp.Common.Logic.Abstract;
using ChatApp.DAL.Context;
using Microsoft.AspNetCore.Http;

namespace ChatApp.BLL.Services
{
    public class BlobStorageService : BaseService, IBlobStorageService
    {
        private readonly BlobContainerClient _blobContainerClient;

        public BlobStorageService(ChatAppContext context, IMapper mapper, IUserIdGetter userIdGetter, BlobContainerClient blobContainerClient) 
            : base(context, mapper, userIdGetter)
        {
            _blobContainerClient = blobContainerClient;
        }

        public async Task<string> UploadNewProfileAvatarAsync(IFormFile newAvatar)
        {
            var uniqueImageName = FileNameGeneratorHelper.GenerateUniqueFileName(newAvatar.FileName);

            var blobInstance = _blobContainerClient.GetBlobClient(uniqueImageName);

            var blobHttpHeaders = new BlobHttpHeaders
            {
                ContentType = newAvatar.ContentType,
            };

            await blobInstance.UploadAsync(newAvatar.OpenReadStream(), blobHttpHeaders);

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
