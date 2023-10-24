using AutoMapper;
using ChatApp.Common.DTO.Message;
using ChatApp.Common.Logic.Abstract;
using ChatApp.DAL.Entities;

namespace ChatApp.BLL.MappingProfiles.Resolvers
{
    public class CurrentUserResolver : IValueResolver<NewMessageDto, Message, int>
    {
        private readonly IUserIdGetter _userIdGetter;

        public CurrentUserResolver(IUserIdGetter userIdGetter)
        {
            _userIdGetter = userIdGetter;
        }

        public int Resolve(NewMessageDto source, Message destination, int destMember, ResolutionContext context)
        {
            return _userIdGetter.CurrentUserId;
        }
    }
}
