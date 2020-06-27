using CarsIsland.Catalog.Domain.Model;
using CarsIsland.Catalog.Domain.Repositories.Interfaces;
using CarsIsland.Catalog.Infrastructure.Services.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsIsland.Catalog.Infrastructure.Repositories
{
    public sealed class CarsCatalogRepository : ICarsCatalogRepository
    {
        private readonly CarCatalogDbContext _sqlDbContext;
        private readonly ILogger<CarsCatalogRepository> _logger;

        public CarsCatalogRepository(CarCatalogDbContext sqlDbContext, ILogger<CarsCatalogRepository> logger)
        {
            _sqlDbContext = sqlDbContext;
            _logger = logger;
        }

        public async Task<Car> AddAsync(Car car)
        {
            try
            {
                car.Id = Guid.NewGuid();
                var entityResult = _sqlDbContext.Cars.Add(car);
                await _sqlDbContext.SaveChangesAsync();
                return entityResult.Entity;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"New entity with ID: {car.Id} was not added successfully - error details: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var car = await _sqlDbContext.Cars
                                 .Where(e => e.Id == id)
                                 .FirstOrDefaultAsync();
                if (car != null)
                {
                    _sqlDbContext.Cars.Remove(car);
                    await _sqlDbContext.SaveChangesAsync();
                }
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Entity with ID: {id} was not removed successfully - error details: {ex.Message}");
                throw;
            }
        }

        public async Task<Car> GetByIdAsync(Guid id)
        {
            try
            {
                var car = await _sqlDbContext.Cars
                                        .Where(e => e.Id == id)
                                        .FirstOrDefaultAsync();
                return car;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Entity with ID: {id} was not retrieved successfully - error details: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateAsync(Car car)
        {
            try
            {
                var existingCar = await _sqlDbContext.Cars
                                       .Where(e => e.Id == car.Id)
                                       .FirstOrDefaultAsync();

                if (existingCar.Id == car.Id)
                {
                    _sqlDbContext.Cars.Update(car);
                    await _sqlDbContext.SaveChangesAsync();
                }
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Entity with ID: {car.Id} was not updated successfully - error details: {ex.Message}");
                throw;
            }
        }

        public async Task<IReadOnlyList<Car>> ListAllAsync()
        {
            try
            {
                var cars = await _sqlDbContext.Cars
                                 .ToListAsync();
                return cars;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Entities was not retrieved successfully - error details: {ex.Message}");
                throw;
            }
        }
    }
}
