using System.Linq.Expressions;

namespace Portfolio.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);      
    }
}
