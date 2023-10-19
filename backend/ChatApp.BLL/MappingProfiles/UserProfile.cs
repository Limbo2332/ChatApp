using AutoMapper;
using ChatApp.Common.DTO.Auth;
using ChatApp.Common.DTO.User;
using ChatApp.DAL.Entities;

namespace ChatApp.BLL.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegisterDto, User>();

            CreateMap<User, UserDto>();
        }
    }
}
