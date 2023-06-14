using AutoService.WebUI.Entities;

namespace AutoService.WebUI.Repositories.EfPostgresql
{
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {
        public SaleRepository(AutoServiceDbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
