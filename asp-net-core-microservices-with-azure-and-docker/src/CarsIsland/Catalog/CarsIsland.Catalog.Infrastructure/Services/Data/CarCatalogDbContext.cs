using CarsIsland.Catalog.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CarsIsland.Catalog.Infrastructure.Services.Data
{
    public class CarCatalogDbContext : DbContext
    {
        public CarCatalogDbContext(DbContextOptions<CarCatalogDbContext> options)
                                                              : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
    }
}
