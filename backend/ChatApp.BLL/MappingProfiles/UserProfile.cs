using AutoMapper;
using ChatApp.BLL.MappingProfiles.Resolvers;
using ChatApp.Common.DTO.User;
using ChatApp.DAL.Entities;

namespace ChatApp.BLL.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegisterDto, User>();

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.ImagePath, conf => conf.ConvertUsing<ImagePathResolver, string>(src => src.ImagePath!));

            CreateMap<User, UserPreviewDto>()
                .ForMember(dest => dest.ImagePath, conf => conf.ConvertUsing<ImagePathResolver, string>(src => src.ImagePath!));
        }
    }
}
