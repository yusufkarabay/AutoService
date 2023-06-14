namespace AutoService.WebUI.Repositories
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AutoServiceDbContext _context;

        public UnitOfWork(AutoServiceDbContext context)
        {
            _context = context;

        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}