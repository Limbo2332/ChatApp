using ChatApp.DAL.Entities;
using System.Linq.Expressions;

namespace ChatApp.DAL.Repositories.Abstract
{
    public interface IRefreshTokenRepository : IGenericRepository<RefreshToken>
    {
    }
}
