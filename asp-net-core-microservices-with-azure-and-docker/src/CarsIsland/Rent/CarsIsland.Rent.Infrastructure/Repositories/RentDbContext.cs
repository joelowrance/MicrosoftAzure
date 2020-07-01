using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CarsIsland.Rent.Infrastructure.Repositories
{
    public class RentDbContext : DbContext
    {
        private IDbContextTransaction _currentTransaction;

        public IDbContextTransaction CurrentTransaction => _currentTransaction;

        public RentDbContext(DbContextOptions<RentDbContext> options)
                                                      : base(options)
        {
        }
    }
}
