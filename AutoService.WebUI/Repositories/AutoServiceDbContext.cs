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
            builder.Entity<Role>().HasData(new Role
            {
                Id = 1,
                Name = "Admin",

            });
            builder.Entity<User>().HasData(new User
            {
                Id = 1,
                Name = "Admin",
                Email = "admin@gmail.com",
                Password = "123456",               
                RoleId=1,
                UserName="Admin",
                Surname="Admin",
                PhoneNum="0535 123 45 67",
                IsActive=true,             

            });
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
