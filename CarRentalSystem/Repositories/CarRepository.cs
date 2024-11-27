using CarRentalSystem.Models;
using CarRentalSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarRentalDbContext _context;
        public CarRepository(CarRentalDbContext context)
        {
           _context = context;
        }
        public async Task<Car> AddCar(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }


        public async Task<IEnumerable<Car>> GetAvailableCars()
        {
            var cars = await  _context.Cars
                            .Where(car => car.IsAvailable == true)
                            .ToListAsync();
            return cars;
        }

        public async Task<Car> GetCarById(string id)
        {
            var car =await _context.Cars.FindAsync(id);
            if (car == null)
                throw new KeyNotFoundException($"Car with ID {id} not found.");
            return car;
        }

        public async Task<Car> UpdateCarAvailability(string id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
                throw new KeyNotFoundException($"Car with ID {id} not found.");
            car.IsAvailable = !car.IsAvailable;
            await _context.SaveChangesAsync();
            return car;
        }
    }
}

