using CarsManagement.Application.DTOs;
using CarsManagement.Application.Services;
using CarsManagement.Infra.Persistence.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;

namespace cars_management_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly AppDbContext _context;

        public CarController(ICarService carService, AppDbContext dbContext)
        {
            _carService = carService;
            _context = dbContext;
        }

        [HttpGet]
        [EnableQuery]

        public async Task<ActionResult<IEnumerable<CarDto>>> GetAllCars()
        {
            var totalCount = await _context.Cars.CountAsync();

            var cars = await _carService.GetAllCarsAsync();

            HttpContext.Response.Headers.Add("X-Total-Count", totalCount.ToString());

            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarDto>> GetCarById(Guid id)
        {
            var car = await _carService.GetCarByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [HttpPost]
        public async Task<ActionResult<CarDto>> AddCar(CreateCarDto carDto)
        {
            var createdCar = await _carService.AddCarAsync(carDto);
            return CreatedAtAction(nameof(GetCarById), new { id = createdCar.Id }, createdCar);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(Guid id, CarDto carDto)
        {
            await _carService.UpdateCarAsync(id, carDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(Guid id)
        {
            await _carService.DeleteCarAsync(id);
            return NoContent();
        }
    }
}
