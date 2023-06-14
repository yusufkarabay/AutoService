namespace AutoService.WebUI.Repositories.EfPostgresql
{
    public class ServiceRepository : GenericRepository<Entities.Service>, IServiceRepository
    {
        public ServiceRepository(AutoServiceDbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
