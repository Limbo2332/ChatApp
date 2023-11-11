using ChatApp.DAL.Entities;
using ChatApp.DAL.Entities.Abstract;
using System.Linq.Expressions;

namespace ChatApp.DAL.Repositories.Abstract
{
    public interface IUserRepository : IGenericRepository<User>
    {
        List<User> GetAll();
    }
}
