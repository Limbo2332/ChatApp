using ChatApp.DAL.Entities;

namespace ChatApp.DAL.Repositories.Abstract
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
        Task UpdateAllUnreadMessagesFromChatAsync(int chatId, int userId);
    }
}
