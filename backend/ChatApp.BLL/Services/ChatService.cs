using AutoMapper;
using ChatApp.BLL.Interfaces;
using ChatApp.BLL.Services.Abstract;
using ChatApp.Common.DTO.Chat;
using ChatApp.Common.DTO.Message;
using ChatApp.Common.DTO.User;
using ChatApp.Common.Logic.Abstract;
using ChatApp.DAL.Context;
using ChatApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.BLL.Services
{
    public class ChatService : BaseService, IChatService
    {
        private readonly IUserIdGetter _userIdGetter;

        public ChatService(ChatAppContext context, IMapper mapper, IUserIdGetter userIdGetter) : base(context, mapper)
        {
            _userIdGetter = userIdGetter;
        }

        public async Task<List<ChatPreviewDto>> GetChatsAsync()
        {
            int currentUserId = _userIdGetter.CurrentUserId;
                
            return await _context.UserChats
                .Include(userChat => userChat.Chat)
                .Include(userChat => userChat.User)
                    .ThenInclude(user => user.Messages)
                .GroupBy(userChat => userChat.ChatId)
                .Where(group => group.Any(userChat => userChat.UserId == currentUserId))
                .Select(group => new ChatPreviewDto
                {
                    Interlocutor = _mapper.Map<UserPreviewDto>(
                        group.First(userChat => userChat.UserId != currentUserId).User),
                    LastMessage = _mapper.Map<LastMessagePreviewDto>(
                        group.First(userChat => userChat.UserId != currentUserId).User.Messages
                             .OrderByDescending(message => message.CreatedAt)
                             .First()
                    )
                })
                .ToListAsync();
        }
    }
}
