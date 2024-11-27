using CarRentalSystem.Data;
using CarRentalSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace CarRentalSystem.Repositories
{
    public class UserRepository :IUserRepository
    {
        private readonly CarRentalDbContext _context;
        public UserRepository(CarRentalDbContext context)
        {
            _context = context;
        }

        //add user
        public async Task<User> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        //get by email
        public async Task<User?> GetUserByEmail(string email)
        {
            //verify email  using regular expression
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            if (!emailRegex.IsMatch(email))
            {
                throw new ArgumentException("Invalid email format.", nameof(email));
            }

            return await _context.Users.SingleOrDefaultAsync(user => user.Email == email);
        }

        //get by id
        public async Task<User?> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
