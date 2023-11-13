using ChatApp.DAL.Entities;

namespace ChatApp.DAL.Repositories.Abstract
{
    public interface IUserChatsRepository : IGenericRepository<UserChats>
    {
        Task AddRangeAsync(List<UserChats> userChats);
    }
}
