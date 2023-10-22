using AutoMapper;
using ChatApp.Common.DTO.Message;
using ChatApp.Common.Logic.Abstract;
using ChatApp.DAL.Entities;

namespace ChatApp.BLL.MappingProfiles.Resolvers
{
    public class LastMessagePreviewResolver : IValueResolver<Message, LastMessagePreviewDto, bool>
    {
        private readonly IUserIdGetter _userIdGetter;

        public LastMessagePreviewResolver(IUserIdGetter userIdGetter)
        {
            _userIdGetter = userIdGetter;
        }

        public bool Resolve(Message source, LastMessagePreviewDto destination, bool destMember, ResolutionContext context)
        {
            return source.UserId == _userIdGetter.CurrentUserId;
        }
    }
}
