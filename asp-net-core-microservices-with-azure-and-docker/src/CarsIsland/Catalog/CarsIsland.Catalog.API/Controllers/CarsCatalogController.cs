using CarsIsland.Catalog.Domain.Model;
using CarsIsland.Catalog.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        /// <summary>
        /// Gets list with available cars
        /// </summary>
        /// <returns>
        /// List with available cars
        /// </returns> 
        /// <response code="200">List with cars</response>
        /// <response code="401">Access denied</response>
        /// <response code="404">Cars catalog found</response>
        /// <response code="500">Oops! something went wrong</response>
        [ProducesResponseType(typeof(IReadOnlyList<Car>), 200)]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllProducts()
        {
            var cars = await _carsCatalogRepository.ListAllAsync();
            return Ok(cars);
        }
    }
}
