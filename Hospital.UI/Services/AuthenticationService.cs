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
            try
            {
                if (await _context.Users.AnyAsync(u => u.Email == user.Email))
                {
                    return false; // Email already exists
                }

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during registration: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> LoginUserAsync(string email, string password)
        {
            // Validate user credentials without password hashing
            return await _context.Users.AnyAsync(u => u.Email == email && u.Password == password);
        }
        public async Task<bool> IsDoctorAsync(string email)
        {
            // Check if the email domain matches "@doctors.com"
            return email.EndsWith("@doctor.com", StringComparison.OrdinalIgnoreCase);
        }
    }
}
