using AutoService.WebUI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AutoService.WebUI.Repositories.EfPostgresql
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AutoServiceDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        protected virtual IQueryable<T> DatasetAsNoTracking => _context.Set<T>().AsNoTracking();
        public GenericRepository(AutoServiceDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork=unitOfWork;
        }


        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking().AsQueryable();
        }

        public async Task<List<T>> SearchAsync(Expression<Func<T, bool>> conditions)
        {
            return await DatasetAsNoTracking.Where(conditions).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _context.AddAsync(entity);
        }

        public Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            _unitOfWork.SaveChangesAsync();
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> conditions)
        {
            var result = await DatasetAsNoTracking.Where(conditions).FirstOrDefaultAsync();
            return result;
        }
    }
}