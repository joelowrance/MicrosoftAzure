using Microsoft.EntityFrameworkCore;

namespace CarsIsland.Rent.Infrastructure.Repositories
{
    public class RentDbContext : DbContext
    {
        public RentDbContext(DbContextOptions<RentDbContext> options)
                                                      : base(options)
        {
        }
    }
}
