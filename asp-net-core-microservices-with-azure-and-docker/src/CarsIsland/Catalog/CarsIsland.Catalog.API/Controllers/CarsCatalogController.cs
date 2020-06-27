using CarsIsland.Catalog.Domain.Model;
using CarsIsland.Catalog.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CarsIsland.Catalog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsCatalogController : ControllerBase
    {
        private readonly ICarsCatalogRepository _carsCatalogRepository;

        public CarsCatalogController(ICarsCatalogRepository carsCatalogRepository)
        {
            _carsCatalogRepository = carsCatalogRepository;
        }

        /// <summary>
        /// Gets list with available cars in the catalog
        /// </summary>
        [ProducesResponseType(typeof(IReadOnlyList<Car>), (int)HttpStatusCode.OK)]
        [HttpGet]
        public async Task<IActionResult> GetAllCarsAsync()
        {
            var cars = await _carsCatalogRepository.ListAllAsync();
            return Ok(cars);
        }

        /// <summary>
        /// Gets car from the catalog
        /// </summary>
        [ProducesResponseType(typeof(Car), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarAsync(Guid id)
        {
            var car = await _carsCatalogRepository.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound(new { Message = $"Car with id {id} not found." });
            }
            return Ok(car);
        }

        /// <summary>
        /// Add new car to the catalog
        /// </summary>
        [ProducesResponseType(typeof(Car), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpPost]
        public async Task<IActionResult> AddCarAsync([FromBody] Car car)
        {
            var addedCar = await _carsCatalogRepository.AddAsync(car);
            return CreatedAtAction(nameof(GetCarAsync), new { id = addedCar.Id });
        }


        /// <summary>
        /// Update existing car in the catalog
        /// </summary>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> UpdateCarAsync([FromBody] Car carToUpdate)
        {
            var existingCarFromTheCatalog = await _carsCatalogRepository.GetByIdAsync(carToUpdate.Id);

            if (existingCarFromTheCatalog == null)
            {
                return NotFound(new { Message = $"Car with id {carToUpdate.Id} not found." });
            }

            else
            {
                existingCarFromTheCatalog.Brand = carToUpdate.Brand;
                existingCarFromTheCatalog.Model = carToUpdate.Model;
                existingCarFromTheCatalog.PricePerDay = carToUpdate.PricePerDay;
                existingCarFromTheCatalog.PricePerWeek = carToUpdate.PricePerWeek;
                existingCarFromTheCatalog.PricePerMonth = carToUpdate.PricePerMonth;

                await _carsCatalogRepository.UpdateAsync(existingCarFromTheCatalog);
                return NoContent();
            }
        }
    }
}
