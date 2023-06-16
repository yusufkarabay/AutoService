using AutoService.WebUI.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoService.WebUI.Repositories
{
    public class AutoServiceDbContext : DbContext
    {
        public AutoServiceDbContext(DbContextOptions<AutoServiceDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
           
            base.OnModelCreating(builder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Entities.Service> Services { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sale> Sales { get; set; }

       
    }
}
