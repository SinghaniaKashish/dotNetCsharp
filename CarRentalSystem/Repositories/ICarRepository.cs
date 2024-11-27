using CarRentalSystem.Models;
namespace CarRentalSystem.Repositories
{
//, , , 
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAvailableCars();
        Task<Car> GetCarById(string id);
        Task<Car> AddCar(Car c);
        Task<Car> UpdateCarAvailability(string id);


    }
}
