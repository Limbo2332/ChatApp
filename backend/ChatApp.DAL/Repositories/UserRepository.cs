using System.Linq.Expressions;
using ChatApp.DAL.Context;
using ChatApp.DAL.Entities;
using ChatApp.DAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ChatAppContext context) : base(context)
        {
        }

        public new Task<User?> GetByExpressionAsync(Expression<Func<User, bool>> expression)
        {
            return _context.Users
                .Include(u => u.BlobImage)
                .FirstOrDefaultAsync(expression);
        }

        public List<User> GetAll()
        {
            return _context.Users
                .Include(u => u.BlobImage)
                .ToList();
        }
    }
}
