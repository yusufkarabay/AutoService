using System.Linq.Expressions;

namespace AutoService.WebUI.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<List<T>> SearchAsync(Expression<Func<T, bool>> conditions);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> FindAsync(Expression<Func<T, bool>> conditions);
    }
}
