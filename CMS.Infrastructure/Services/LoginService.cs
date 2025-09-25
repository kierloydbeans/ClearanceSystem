using CMS.Application.Features.Authentication.Login;
using CMS.Domain.Entities;
using CMS.Infrastructure.Data;
using CMS.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Services
{
    public class LoginService : ILoginService
    {
        private readonly ApplicationDbContext _context;

        public LoginService(ApplicationDbContext context)
        {
             _context = context;
        }

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            // find the user in the database by their username
            var user = await _context.Users
                                     .FirstOrDefaultAsync(u => u.Username == username);

            // if no user found, the login fails. Hash if correct password.
            if (user == null || !PasswordHasher.VerifyPassword(password, user.HashedPassword))
            {
                return null;
            }

            // return the result.
            return user;
        }
    }
}