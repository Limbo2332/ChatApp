using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace ChatApp.BLL.MappingProfiles.Resolvers
{
    public class ImagePathResolver : IValueConverter<string, string>
    {
        private readonly IConfiguration _configuration;

        public ImagePathResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Convert(string sourceMember, ResolutionContext context)
        {
            var blobUrlAccess = _configuration.GetSection("BlobStorage:AccessPath").Value;

            return string.IsNullOrEmpty(sourceMember) ? null! : $"{blobUrlAccess}/{sourceMember}";
        }
    }
}
