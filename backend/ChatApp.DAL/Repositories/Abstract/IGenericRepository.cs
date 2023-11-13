using System.Linq.Expressions;

namespace ChatApp.DAL.Repositories.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> GetByExpressionAsync(Expression<Func<T, bool>> expression);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(int id);

        Task<int> SaveChangesAsync();
    }
}
