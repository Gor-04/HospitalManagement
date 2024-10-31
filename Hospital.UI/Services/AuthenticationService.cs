using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hospital.Data.Entities;
using Hospital.Data.DAO;

namespace Hospital.UI.Services
{
    public class AuthenticationService
    {
        private readonly ApplicationDBContext _context;

        public AuthenticationService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterUserAsync(User user)
        {
            // Check if the email is already registered
            if (await _context.Users.AnyAsync(u => u.Email == user.Email))
            {
                return false; // Email already exists
            }

            // Add the user and save changes
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> LoginUserAsync(string email, string password)
        {
            // Validate user credentials
            return await _context.Users.AnyAsync(u => u.Email == email && u.Password == password);
        }
    }
}
