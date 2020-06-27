using CarsIsland.Catalog.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsIsland.Catalog.Domain.Repositories.Interfaces
{
    public interface ICarsCatalogRepository
    {
        Task<Car> GetByIdAsync(Guid id);
        Task<IReadOnlyList<Car>> ListAllAsync();
        Task<Car> AddAsync(Car car);
        Task UpdateAsync(Car car);
        Task DeleteAsync(Guid id);
    }
}
