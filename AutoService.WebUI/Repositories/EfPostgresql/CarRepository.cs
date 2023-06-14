using AutoService.WebUI.Entities;

namespace AutoService.WebUI.Repositories.EfPostgresql
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository(AutoServiceDbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
