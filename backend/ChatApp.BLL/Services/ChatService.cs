using AutoMapper;
using ChatApp.BLL.Hubs;
using ChatApp.BLL.Hubs.Clients;
using ChatApp.BLL.Interfaces;
using ChatApp.BLL.Services.Abstract;
using ChatApp.Common.DTO.Chat;
using ChatApp.Common.DTO.Conversation;
using ChatApp.Common.DTO.Message;
using ChatApp.Common.DTO.Page;
using ChatApp.Common.DTO.User;
using ChatApp.Common.Exceptions;
using ChatApp.Common.Logic.Abstract;
using ChatApp.DAL.Entities;
using ChatApp.DAL.Repositories.Abstract;
using Microsoft.AspNetCore.SignalR;
using System.Linq.Dynamic.Core;

namespace ChatApp.BLL.Services
{
    public class ChatService : BaseService, IChatService
    {
        private readonly IHubContext<ChatHub, IChatHubClient> _hubContext;
        private readonly IUserService _userService;
        private readonly IChatRepository _chatRepository;
        private readonly IUserChatsRepository _userChatsRepository;
        private readonly IMessageRepository _messageRepository;

        public ChatService(
            IMapper mapper,
            IUserIdGetter userIdGetter,
            IHubContext<ChatHub, IChatHubClient> hubContext,
            IUserService userService,
            IChatRepository chatRepository,
            IUserChatsRepository userChatsRepository,
            IMessageRepository messageRepository)
            : base(mapper, userIdGetter)
        {
            _hubContext = hubContext;
            _userService = userService;
            _userChatsRepository = userChatsRepository;
            _chatRepository = chatRepository;
            _messageRepository = messageRepository;
        }

        public async Task<List<ChatPreviewDto>> GetChatsAsync(PageSettingsDto? pageSettings)
        {
            int currentUserId = _userIdGetter.CurrentUserId;

            var userChats = await _userChatsRepository.GetAllAsync();

            var chats = userChats
                .GroupBy(userChat => userChat.Chat)
                .Where(group => group.Any(userChat => userChat.UserId == currentUserId))
                .Select(group => new ChatPreviewDto
                {
                    Id = group.Key.Id,
                    Interlocutor = _mapper.Map<UserPreviewDto>(
                        group.First(userChat => userChat.ChatId == group.Key.Id && userChat.UserId != currentUserId).User),
                    LastMessage = _mapper.Map<MessagePreviewDto>(
                        group.First(userChat => userChat.ChatId == group.Key.Id).Chat.Messages
                             .OrderByDescending(message => message.CreatedAt)
                             .First()
                    ),
                    InterlocutorUnreadMessagesCount =
                        group.First(userChat => userChat.ChatId == group.Key.Id).Chat.Messages
                             .Count(message => !message.IsRead && message.UserId != currentUserId),
                });

            if (pageSettings?.Filter is not null)
            {
                chats = chats
                   .AsQueryable()
                   .Where($"{pageSettings.Filter.PropertyName}.Contains(@0)", pageSettings.Filter.PropertyValue)
                   .ToList();
            }

            if (pageSettings?.Pagination is not null)
            {
                chats = chats
                    .Skip((pageSettings.Pagination.PageNumber - 1) * pageSettings.Pagination.PageSize)
                    .Take(pageSettings.Pagination.PageSize)
                    .ToList();
            }

            return chats
                .OrderByDescending(chat => chat.LastMessage.SentAt)
                .ToList();
        }

        public async Task<ChatConversationDto> GetConversationAsync(int chatId, PageSettingsDto? pageSettings)
        {
            int currentUserId = _userIdGetter.CurrentUserId;

            var userChats = await _userChatsRepository.GetAllAsync();

            var chatConversation = userChats
                .GroupBy(userChat => userChat.Chat)
                .Select(group => new ChatConversationDto
                {
                    ChatId = group.Key.Id,
                    Interlocutor = _mapper.Map<UserPreviewDto>(
                        group.First(userChat => userChat.UserId != currentUserId).User),
                    Messages = _mapper.Map<IEnumerable<MessagePreviewDto>>(
                        group.First(userChat => userChat.ChatId == group.Key.Id).Chat.Messages
                             .OrderByDescending(message => message.CreatedAt)
                             .ToList()
                    )
                })
                .FirstOrDefault(chat => chat.ChatId == chatId)
                    ?? throw new NotFoundException(nameof(Chat));

            if (pageSettings?.Filter is not null)
            {
                chatConversation.Messages = chatConversation.Messages
                   .AsQueryable()
                   .Where($"{pageSettings.Filter.PropertyName}.Contains(@0)", pageSettings.Filter.PropertyValue)
                   .ToList();
            }

            if (pageSettings?.Pagination is not null)
            {
                chatConversation.Messages = chatConversation.Messages
                   .Skip((pageSettings.Pagination.PageNumber - 1) * pageSettings.Pagination.PageSize)
                   .Take(pageSettings.Pagination.PageSize)
                   .ToList();
            }

            return chatConversation;
        }

        public async Task<MessagePreviewDto> AddMessageAsync(NewMessageDto newMessage)
        {
            var message = _mapper.Map<Message>(newMessage);

            var messagePreview = await CreateNewMessageAsync(message);

            await SendNewMessageNotificationToInterlocutor(message);

            return messagePreview;
        }

        public async Task<ChatPreviewDto> AddNewChatWithAsync(NewChatDto newChat)
        {
            int currentUserId = _userIdGetter.CurrentUserId;

            var interlocutor = await _userService.FindUserByUsernameAsync(newChat.UserName);

            if (await FindCommonChatsAsync(interlocutor.Id))
            {
                throw new BadRequestException("This chat is already created");
            }

            var chat = new Chat();

            await _chatRepository.AddAsync(chat);

            var message = new Message
            {
                Value = newChat.NewMessage,
                ChatId = chat.Id,
                UserId = currentUserId,
            };

            await CreateUserChatsAsync(chat.Id, interlocutor.Id);

            var currentUser = await _userService.GetCurrentUserAsync();

            var chatPreview = new ChatPreviewDto
            {
                Id = chat.Id,
                Interlocutor = _mapper.Map<UserPreviewDto>(currentUser),
                LastMessage = await CreateNewMessageAsync(message),
            };

            await SendNewChatNotificationToInterlocutor(interlocutor, chatPreview);

            chatPreview.Interlocutor = _mapper.Map<UserPreviewDto>(interlocutor);

            return chatPreview;
        }

        public async Task ReadMessagesAsync(ChatReadDto chat)
        {
            var messages = await _messageRepository
                .GetAllAsync();

            messages = messages
                .Where(message => message.ChatId == chat.Id
                    && message.UserId != chat.UserId
                    && !message.IsRead);

            await _messageRepository.UpdateEveryMessageByExpressionAsync(message => message.IsRead, true);

            var userChat = await GetUserChatAsync(chat.Id, chat.UserId);

            await _hubContext.Clients
                .Group(userChat.UserId.ToString())
                .ReadMessagesAsync(chat);
        }

        private async Task<MessagePreviewDto> CreateNewMessageAsync(Message message)
        {
            await _messageRepository.AddAsync(message);

            return _mapper.Map<MessagePreviewDto>(message);
        }

        private async Task SendNewMessageNotificationToInterlocutor(Message message)
        {
            var userChat = await GetUserChatAsync(message.ChatId, message.UserId);

            var messagePreview = _mapper.Map<MessagePreviewDto>(message);
            messagePreview.IsMine = !messagePreview.IsMine;

            await _hubContext.Clients.Group(userChat.UserId.ToString()).SendNewMessageAsync(messagePreview);
        }

        private async Task SendNewChatNotificationToInterlocutor(User interlocutor, ChatPreviewDto chatPreview)
        {
            chatPreview.LastMessage.IsMine = !chatPreview.LastMessage.IsMine;

            await _hubContext.Clients.Group(interlocutor.Id.ToString()).CreateNewChatAsync(chatPreview);
        }

        private async Task<bool> FindCommonChatsAsync(int interlocutorId)
        {
            int currentUserId = _userIdGetter.CurrentUserId;

            var userChats = await _userChatsRepository.GetAllAsync();

            var myUserChats = userChats
                .Where(userChat => userChat.UserId == currentUserId)
                .Select(userChat => userChat.Chat)
                .ToList();

            var interlocutorChats = userChats
                .Where(userChat => userChat.UserId == interlocutorId)
                .Select(userChat => userChat.Chat)
                .ToList();

            var commonChats = myUserChats
                .Intersect(interlocutorChats)
                .ToList();

            return commonChats.Any();
        }

        private async Task CreateUserChatsAsync(int chatId, int interlocutorId)
        {
            int currentUserId = _userIdGetter.CurrentUserId;

            var myUserChat = new UserChats
            {
                ChatId = chatId,
                UserId = currentUserId,
            };

            var interLocutorUserChat = new UserChats
            {
                ChatId = chatId,
                UserId = interlocutorId,
            };

            await _userChatsRepository.AddRangeAsync(new List<UserChats> { myUserChat, interLocutorUserChat });
        }

        private async Task<UserChats> GetUserChatAsync(int chatId, int userId)
        {
            return await _userChatsRepository
                .GetByExpressionAsync(userChat => userChat.ChatId == chatId
                         && userChat.UserId != userId)
                ?? throw new NotFoundException(nameof(UserChats));
        }
    }
}
