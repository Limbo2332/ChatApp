using ChatApp.DAL.Entities;

namespace ChatApp.DAL.Repositories.Abstract
{
    public interface IUserRepository : IGenericRepository<User>
    {
        List<User> GetAll();
    }
}
