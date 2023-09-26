using DuplexCenima.Models;
using System.Linq.Expressions;

namespace DuplexCenima.Data.Base
{
    public interface iEntityBaseRepository<T> where T: class, iEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeproperties);
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
    }
}
