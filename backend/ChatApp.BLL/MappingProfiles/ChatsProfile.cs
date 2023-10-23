using AutoMapper;
using ChatApp.BLL.MappingProfiles.Resolvers;
using ChatApp.Common.DTO.Message;
using ChatApp.DAL.Entities;

namespace ChatApp.BLL.MappingProfiles
{
    public class ChatsProfile : Profile
    {
        public ChatsProfile()
        {
            CreateMap<Message, MessagePreviewDto>()
                .ForMember(dest => dest.SentAt, src => src.MapFrom(msg => msg.CreatedAt))
                .ForMember(dest => dest.IsMine, src => src.MapFrom<MessagePreviewResolver>());
        }
    }
}
