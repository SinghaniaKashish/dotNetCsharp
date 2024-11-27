using CarRentalSystem.Models;
using CarRentalSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }
        [HttpGet]
        //[Authorize(Policy = "All")] 
        public async Task<IActionResult> GetAvailableCars()
        {
            var cars = await _carService.GetAvailable();
            return Ok(cars);
        }

        [HttpPost]
        //[Authorize(Policy = "AdminOnly")] // Only Admins 
        public async Task<IActionResult> AddCar([FromBody] Car car)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _carService.Add(car);
            return CreatedAtAction(nameof(GetCars), new { id = car.Id }, car);
        }

        [HttpPut("{id}")]
        //[Authorize(Policy = "AdminOnly")] 
        public async Task<IActionResult> UpdateCar(int id, [FromBody] Car car)
        {
            if (id != car.Id)
                return BadRequest("Car ID mismatch");

            var existingCar = await _carService.GetCarByIdAsync(id);
            if (existingCar == null)
                return NotFound($"Car with ID {id} not found");

            await _carService.UpdateAvailability(car);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminOnly")] // Only Admins 
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _carService.GetCarByIdAsync(id);
            if (car == null)
                return NotFound($"Car with ID {id} not found");

            await _carService.DeleteCarAsync(id);
            return NoContent();
        }

    }
}



   
        
