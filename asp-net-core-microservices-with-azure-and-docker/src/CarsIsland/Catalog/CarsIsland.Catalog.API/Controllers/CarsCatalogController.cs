using CarsIsland.Catalog.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarsIsland.Catalog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsCatalogController : ControllerBase
    {
        private readonly ICarsCatalogRepository _carsCatalogRepository;
        private readonly ILogger<CarsCatalogController> _logger;

        public CarsCatalogController(ICarsCatalogRepository carsCatalogRepository, ILogger<CarsCatalogController> logger)
        {
            _carsCatalogRepository = carsCatalogRepository;
            _logger = logger;
        }
    }
}
