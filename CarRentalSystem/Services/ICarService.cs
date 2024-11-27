using CarRentalSystem.Models;

namespace CarRentalSystem.Services
{
    public interface ICarService
    {
        public Task<IEnumerable<Car>> GetAvailable();
        public Task<Car> GetById(string id);
        public Task<Car> Add(Car c);
        public Task<Car> UpdateAvailability(string id);
        public Task<string> RentCar(string carId);
    }
}
