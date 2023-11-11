using ChatApp.DAL.Context;
using ChatApp.DAL.Entities;
using ChatApp.DAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ChatApp.DAL.Repositories
{
    public class UserChatsRepository : GenericRepository<UserChats>, IUserChatsRepository
    {
        public UserChatsRepository(ChatAppContext context) : base(context)
        {
        }

        public async Task AddRangeAsync(List<UserChats> userChats)
        {
            await _context.UserChats.AddRangeAsync(userChats);

            await SaveChangesAsync();
        }

        public override async Task<IEnumerable<UserChats>> GetAllAsync()
        {
            return await _context.UserChats
                .Include(userChat => userChat.User)
                .Include(userChat => userChat.Chat)
                    .ThenInclude(chat => chat.Messages)
                .ToListAsync();
        }
    }
}
