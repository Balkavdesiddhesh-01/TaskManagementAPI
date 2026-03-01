using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using TasKManagementAPI.Data;
using TasKManagementAPI.DTOs;
using TasKManagementAPI.Models;

namespace TasKManagementAPI.Services
{
    public class AuthService : IAuthService
    {

        private readonly ApplicationDbContext _Context;

        public AuthService(ApplicationDbContext context)
        {
            _Context = context;
        }


        public async Task<UserReasponseDto> RegisterAsync(RegisterDto registerDto)
        {
            // check if user already exists
            var existingUser = await _Context.Users
                .FirstOrDefaultAsync(u => u.Email == registerDto.Email ||
                                     u.Username == registerDto.UserName);

            if(existingUser != null)
            {
                throw new InvalidOperationException(
                    "User with this email or username already exist");
            }

            // hash the password
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.password);

            // create new user
            var user = new User
            {
                Username = registerDto.UserName,
                Email = registerDto.Email,
                PasswordHadh = passwordHash,
                CreatedAt = DateTime.UtcNow
            };

            //add to database
            _Context.Users.Add(user);  // in memory insertion

            await _Context.SaveChangesAsync();  // persist to database

            return new UserReasponseDto
            {
                Id = user.id,
                UserName = user.Username,
                Email = user.Email,
                CraetedDate = user.CreatedAt
            };
        }
    }
}
