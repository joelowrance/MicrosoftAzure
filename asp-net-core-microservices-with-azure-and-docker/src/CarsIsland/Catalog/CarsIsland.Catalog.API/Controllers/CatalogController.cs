using CarsIsland.Catalog.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarsIsland.Catalog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly ICarsCatalogService _carsCatalogService;
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(ICarsCatalogService carsCatalogService, ILogger<CatalogController> logger)
        {
            _carsCatalogService = carsCatalogService;
            _logger = logger;
        }
    }
}
