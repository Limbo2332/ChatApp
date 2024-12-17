using AutoMapper;
using ChatApp.Common.DTO.User;
using ChatApp.DAL.Entities;
using ChatApp.DAL.Repositories.Abstract;
using Microsoft.Extensions.Configuration;

namespace ChatApp.BLL.MappingProfiles.Resolvers
{
    public class UserToUserDtoConverter : ITypeConverter<User, UserDto>
    {
        private readonly IImageRepository _imageRepository;
        private readonly IConfiguration _configuration;

        public UserToUserDtoConverter(IImageRepository imageRepository, IConfiguration configuration)
        {
            _imageRepository = imageRepository;
            _configuration = configuration;
        }

        public UserDto Convert(User source, UserDto destination, ResolutionContext context)
        {
            var image = _imageRepository.GetAsync(source.ImageId).GetAwaiter().GetResult();

            var blobUrlAccess = _configuration.GetSection("BlobStorage:AccessPath").Value;
            var imagePath = image is not null
                ? $"{blobUrlAccess}/{image.ImagePath}"
                : null;

            return new UserDto
            {
                Id = source.Id,
                Email = source.Email,
                UserName = source.UserName,
                ImagePath = imagePath,
                SqlImage = source.BlobImageId.HasValue ?
                    new BlobImageDto
                    {
                        Id = source.BlobImageId.Value,
                        ContentType = source.BlobImage!.ContentType,
                        Data = source.BlobImage!.Data,
                        Name = source.BlobImage!.Name,
                    }
                    : null
            };
        }
    }
}
