using AutoMapper;
using ChatApp.Common.DTO.Message;
using ChatApp.Common.Logic.Abstract;
using ChatApp.DAL.Entities;

namespace ChatApp.BLL.MappingProfiles.Resolvers
{
    public class MessagePreviewResolver : IValueResolver<Message, MessagePreviewDto, bool>
    {
        private readonly IUserIdGetter _userIdGetter;

        public MessagePreviewResolver(IUserIdGetter userIdGetter)
        {
            _userIdGetter = userIdGetter;
        }

        public bool Resolve(Message source, MessagePreviewDto destination, bool destMember, ResolutionContext context)
        {
            return source.UserId == _userIdGetter.CurrentUserId;
        }
    }
}
