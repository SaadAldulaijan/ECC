using System.Linq.Expressions;

namespace ECC.Shared.Repositories
{
    public interface IRepository<T, TKey> where T : class
    {
        Task<T> GetAsync(TKey id);
        Task<IEnumerable<T>> GetAsync();
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> expression);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(TKey id);
    }
}