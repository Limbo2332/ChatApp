﻿using AutoMapper;
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

            var chats = await _context.UserChats
                .Include(userChat => userChat.User)
                .Include(userChat => userChat.Chat)
                    .ThenInclude(chat => chat.Messages)
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
                    )
                })
                .ToListAsync();

            return chats
                .OrderByDescending(chat => chat.LastMessage.SentAt)
                .ToList();
        }

        public async Task<ChatConversationDto> GetConversationAsync(int chatId)
        {
            int currentUserId = _userIdGetter.CurrentUserId;

            return await _context.UserChats
                .Include(userChat => userChat.User)
                .Include(userChat => userChat.Chat)
                    .ThenInclude(chat => chat.Messages)
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
                .FirstOrDefaultAsync(chat => chat.ChatId == chatId)
                ?? throw new NotFoundException(nameof(Chat));
        }

        public async Task<MessagePreviewDto> AddMessageAsync(NewMessageDto newMessage)
        {
            var message = _mapper.Map<Message>(newMessage);

            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();

            return _mapper.Map<MessagePreviewDto>(message);
        }

        public async Task<ChatPreviewDto> AddNewChatWithAsync(NewChatDto newChat)
        {
            int currentUserId = _userIdGetter.CurrentUserId;

            var interlocutor = await _context.Users
                .FirstOrDefaultAsync(user => user.UserName.ToLower() == newChat.UserName.ToLower())
                ?? throw new BadRequestException($"User with username {newChat.UserName} doesn't exist");

            if (await FindCommonChatsAsync(interlocutor.Id))
            {
                throw new BadRequestException("This chat is already created");
            }

            var chat = new Chat();

            await _context.AddAsync(chat);
            await _context.SaveChangesAsync();

            var newMessage = new NewMessageDto
            {
                Value = newChat.NewMessage,
                ChatId = chat.Id
            };

            var message = await AddMessageAsync(newMessage);

            await CreateUserChatsAsync(chat.Id, interlocutor.Id);

            return new ChatPreviewDto
            {
                Id = chat.Id,
                Interlocutor = _mapper.Map<UserPreviewDto>(interlocutor),
                LastMessage = message
            };
        }

        private async Task<bool> FindCommonChatsAsync(int interlocutorId)
        {
            int currentUserId = _userIdGetter.CurrentUserId;

            var myUserChats = await _context.UserChats
                .Include(userChat => userChat.Chat)
                .Where(userChat => userChat.UserId == currentUserId)
                .Select(userChat => userChat.Chat)
                .ToListAsync();

            var interlocutorChats = await _context.UserChats
                .Include(userChat => userChat.Chat)
                .Where(userChat => userChat.UserId == interlocutorId)
                .Select(userChat => userChat.Chat)
                .ToListAsync();

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

            await _context.UserChats.AddRangeAsync(myUserChat, interLocutorUserChat);
            await _context.SaveChangesAsync();
        }
    }
}