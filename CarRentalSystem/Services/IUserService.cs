using CarRentalSystem.Models;

namespace CarRentalSystem.Services
{
    public interface IUserService
    {
        public Task<User> Add(User user);
        public Task<User> GetByEmail(string email);
        public Task<User> GetById(int id);
        public Task RegisterUser(User user);
    }
}
