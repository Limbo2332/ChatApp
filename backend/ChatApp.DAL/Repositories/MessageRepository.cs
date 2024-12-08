using ChatApp.DAL.Context;
using ChatApp.DAL.Entities;
using ChatApp.DAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;

namespace ChatApp.DAL.Repositories
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(ChatAppContext context) : base(context)
        {
        }

        public async Task UpdateAllUnreadMessagesFromChatAsync(int chatId, int userId)
        {
            await _context.Messages
                .Where(message => message.ChatId == chatId
                    && message.UserId != userId
                    && !message.IsRead)
                .ExecuteUpdateAsync(message => message.SetProperty(m => m.IsRead, true));
        }
    }
}
