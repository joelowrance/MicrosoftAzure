using CarsIsland.Catalog.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace CarsIsland.Catalog.Infrastructure.Services.Data
{
    public class CarCatalogDbContext : DbContext
    {
        public CarCatalogDbContext(DbContextOptions<CarCatalogDbContext> options)
                                                              : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>().HasData(
                    new Car
                    {
                        Id = Guid.NewGuid(),
                        Brand = "BMW",
                        Model = "320",
                        AvailableForRent = true,
                        PricePerDay = 200,
                        PricePerWeek = 900,
                        PricePerMonth = 2000
                    },
                    new Car
                    {
                        Id = Guid.NewGuid(),
                        Brand = "Audi",
                        Model = "A1",
                        AvailableForRent = true,
                        PricePerDay = 120,
                        PricePerWeek = 700,
                        PricePerMonth = 1600
                    },
                    new Car
                    {
                        Id = Guid.NewGuid(),
                        Brand = "Mercedes",
                        Model = "E200",
                        AvailableForRent = true,
                        PricePerDay = 250,
                        PricePerWeek = 1100,
                        PricePerMonth = 2600
                    },
                    new Car
                    {
                        Id = Guid.NewGuid(),
                        Brand = "Ford",
                        Model = "Focus",
                        AvailableForRent = true,
                        PricePerDay = 90,
                        PricePerWeek = 400,
                        PricePerMonth = 1000
                    }
                );
        }
    }
}
