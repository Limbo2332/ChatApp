using ChatApp.DAL.Entities;
using System.Linq.Expressions;

namespace ChatApp.DAL.Repositories.Abstract
{
    public interface IUserChatsRepository : IGenericRepository<UserChats>
    {
        Task AddRangeAsync(List<UserChats> userChats);
    }
}
