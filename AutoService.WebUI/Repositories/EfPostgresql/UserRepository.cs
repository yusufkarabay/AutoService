using AutoService.WebUI.Entities;

namespace AutoService.WebUI.Repositories.EfPostgresql
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AutoServiceDbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
