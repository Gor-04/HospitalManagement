using System;
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

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="user">User entity containing Name, Surname, ID Number, Email, and Password.</param>
        /// <returns>True if registration is successful, otherwise false.</returns>
        public async Task<bool> RegisterUserAsync(User user)
        {
            try
            {
                // Check if the email is already registered
                if (await _context.Users.AnyAsync(u => u.Email == user.Email))
                {
                    return false; // Email already exists
                }

                // Add the new user to the database
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                return true; // Registration successful
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during registration: {ex.Message}");
                return false; // Registration failed
            }
        }

        /// <summary>
        /// Logs in a user by validating credentials.
        /// </summary>
        /// <param name="email">User's email.</param>
        /// <param name="password">User's password.</param>
        /// <returns>True if credentials are valid, otherwise false.</returns>
        public async Task<bool> LoginUserAsync(string email, string password)
        {
            // Validate user credentials without password hashing
            return await _context.Users.AnyAsync(u => u.Email == email && u.Password == password);
        }

        /// <summary>
        /// Checks if the user is a doctor based on the email domain.
        /// </summary>
        /// <param name="email">User's email.</param>
        /// <returns>True if the user is a doctor, otherwise false.</returns>
        public async Task<bool> IsDoctorAsync(string email)
        {
            // Example logic: Assume doctor emails end with "@doctor.com"
            return email.EndsWith("@doctor.com", StringComparison.OrdinalIgnoreCase);
        }
    }
}
