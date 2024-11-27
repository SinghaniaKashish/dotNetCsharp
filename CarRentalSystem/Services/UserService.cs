using CarRentalSystem.Models;
using CarRentalSystem.Repositories;

namespace CarRentalSystem.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly JwtService _jwtServices;
        public UserService(IUserRepository userRepo, JwtService jwtServices)
        {

            _userRepo = userRepo;
            _jwtServices = jwtServices;
        }

        //register user
        public async Task RegisterUser(User user)
        {
            await Add(user);
        }

        //authenticate user
        public async Task<string> AuthenticateUser(string email, string password)
        {
            var user = await GetByEmail(email);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid email or password");
            }

            if(user.Password != password)
            {
                throw new UnauthorizedAccessException("Invalid email or password");
            }

            var token = _jwtServices.GenerateToken(user);
            return token;
        }


        //repo
        public Task<User> Add(User user)
        {
            return _userRepo.AddUser(user);
        }
        public Task<User> GetByEmail(string email)
        {
            return _userRepo.GetUserByEmail(email);
        }
        public Task<User> GetById(int id)
        {
            return _userRepo.GetUserById(id);
        }


    }
}
