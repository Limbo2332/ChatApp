using ChatApp.DAL.Context;
using ChatApp.DAL.Entities;
using ChatApp.DAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.DAL.Repositories
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(ChatAppContext context) : base(context)
        {
        }

        public async Task UpdateEveryMessageByExpressionAsync(Func<Message, object> func, object value)
        {
            await _dbSet.ExecuteUpdateAsync(message => message.SetProperty(func, value));

            await SaveChangesAsync();
        }
    }
}
