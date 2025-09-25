using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace CMS.Infrastructure.Security
{
    public class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            // takes the user's input password and the stored hash.
            // hashes the input and compares it to the stored hash securely.
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
