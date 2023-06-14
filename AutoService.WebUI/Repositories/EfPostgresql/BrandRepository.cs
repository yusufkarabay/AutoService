using AutoService.WebUI.Entities;

namespace AutoService.WebUI.Repositories.EfPostgresql
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(AutoServiceDbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
