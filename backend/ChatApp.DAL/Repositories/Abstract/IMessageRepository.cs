using ChatApp.DAL.Entities;

namespace ChatApp.DAL.Repositories.Abstract
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
        Task UpdateEveryMessageByExpressionAsync(Func<Message, object> func, object value);
    }
}
