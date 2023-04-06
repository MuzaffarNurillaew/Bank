using System.Linq.Expressions;

namespace Bank.Data.IRepositories
{
    public interface IRepository<T>
    {
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(Expression<Func<T, bool>> expression);
        Task<T> SelectAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> SelectAll();
        Task SaveAsync();
    }
}
