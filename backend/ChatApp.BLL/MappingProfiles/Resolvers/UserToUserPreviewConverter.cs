using AutoMapper;
using ChatApp.Common.DTO.User;
using ChatApp.DAL.Entities;
using ChatApp.DAL.Repositories.Abstract;
using Microsoft.Extensions.Configuration;

namespace ChatApp.BLL.MappingProfiles.Resolvers
{
    public class UserToUserPreviewConverter : ITypeConverter<User, UserPreviewDto>
    {
        private readonly IImageRepository _imageRepository;
        private readonly IConfiguration _configuration;

        public UserToUserPreviewConverter(IImageRepository imageRepository, IConfiguration configuration)
        {
            _imageRepository = imageRepository;
            _configuration = configuration;
        }

        public UserPreviewDto Convert(User source, UserPreviewDto destination, ResolutionContext context)
        {
            var image = _imageRepository.GetAsync(source.ImageId).GetAwaiter().GetResult();

            var blobUrlAccess = _configuration.GetSection("BlobStorage:AccessPath").Value;
            var imagePath = image is not null
                ? $"{blobUrlAccess}/{image.ImagePath}"
                : null;

            return new UserPreviewDto
            {
                ImagePath = imagePath,
                UserName = source.UserName,
            };
        }
    }
}
