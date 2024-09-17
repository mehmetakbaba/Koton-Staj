using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Koton.Discount.Entity.Entities.Concrete;

namespace Koton.Discount.DataAccess.Context
{
    public class DapperContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("Koton.Discount.DataAccess"));
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.ToTable("Coupons"); 
            });

            base.OnModelCreating(modelBuilder); 
        }

        public DbSet<Coupon> Coupons { get; set; }
    }
}