using AutoMapper;
using ChatApp.BLL.Interfaces;
using ChatApp.BLL.Services.Abstract;
using ChatApp.Common.DTO.Chat;
using ChatApp.Common.DTO.Conversation;
using ChatApp.Common.DTO.Message;
using ChatApp.Common.DTO.User;
using ChatApp.Common.Exceptions;
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
                    .ThenInclude(chat => chat.Messages)
                .Include(userChat => userChat.User)
                    .ThenInclude(user => user.Messages)
                .GroupBy(userChat => userChat.ChatId)
                .Where(group => group.Any(userChat => userChat.UserId == currentUserId))
                .Select(group => new ChatPreviewDto
                {
                    Id = group.Key,
                    Interlocutor = _mapper.Map<UserPreviewDto>(
                        group.First(userChat => userChat.UserId != currentUserId).User),
                    LastMessage = _mapper.Map<MessagePreviewDto>(
                        group.First(userChat => userChat.ChatId == group.Key).Chat.Messages
                             .OrderByDescending(message => message.CreatedAt)
                             .First()
                    )
                })
                .ToListAsync();
        }

        public async Task<ChatConversationDto> GetConversationAsync(int chatId)
        {
            int currentUserId = _userIdGetter.CurrentUserId;

            return await _context.UserChats
                .Include(userChat => userChat.Chat)
                    .ThenInclude(chat => chat.Messages)
                .Include(userChat => userChat.User)
                    .ThenInclude(user => user.Messages)
                .GroupBy(userChat => userChat.ChatId)
                .Where(group => group.Any(userChat => userChat.UserId == currentUserId))
                .Select(group => new ChatConversationDto
                {
                    ChatId = group.Key,
                    Interlocutor = _mapper.Map<UserPreviewDto>(
                        group.First(userChat => userChat.UserId != currentUserId).User),
                    Messages = _mapper.Map<IEnumerable<MessagePreviewDto>>(
                        group.First(userChat => userChat.ChatId == group.Key).Chat.Messages
                             .OrderByDescending(message => message.CreatedAt)
                             .ToList()
                    )
                })
                .FirstOrDefaultAsync(chat => chat.ChatId == chatId)
                ?? throw new NotFoundException(nameof(Chat));
        }
    }
}
