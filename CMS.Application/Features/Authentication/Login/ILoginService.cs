using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Authentication.Login
{
    public interface ILoginService
    {
        // The method returns true for a successful login, false otherwise.
        Task<User> AuthenticateAsync(string username, string password);
    }
}
