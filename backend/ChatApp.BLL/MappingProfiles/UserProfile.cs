using AutoMapper;
using ChatApp.BLL.MappingProfiles.Resolvers;
using ChatApp.Common.DTO.User;
using ChatApp.DAL.Entities;
using ChatApp.DAL.Repositories.Abstract;
using Microsoft.Extensions.Configuration;

namespace ChatApp.BLL.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegisterDto, User>();

            CreateMap<User, UserDto>().ConvertUsing<UserToUserDtoConverter>();

            CreateMap<User, UserPreviewDto>().ConvertUsing<UserToUserPreviewConverter>();
        }
    }
}
