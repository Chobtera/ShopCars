using Microsoft.EntityFrameworkCore;
using ShopCars.Cars.Models;

namespace ShopCars.Cars.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }

    }
}
