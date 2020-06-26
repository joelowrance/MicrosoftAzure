using CarsIsland.Catalog.Domain.Services.Interfaces;

namespace CarsIsland.Catalog.Domain.Services
{
    public class CarsCatalogService : ICarsCatalogService
    {
        private readonly ICarsCatalogRepository _carsCatalogRepository;

        public CarsCatalogService(ICarsCatalogRepository carsCatalogRepository)
        {
            _carsCatalogRepository = carsCatalogRepository;
        }
    }
}
