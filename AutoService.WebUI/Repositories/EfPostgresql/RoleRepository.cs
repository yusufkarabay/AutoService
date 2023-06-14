using AutoService.WebUI.Entities;

namespace AutoService.WebUI.Repositories.EfPostgresql
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(AutoServiceDbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
