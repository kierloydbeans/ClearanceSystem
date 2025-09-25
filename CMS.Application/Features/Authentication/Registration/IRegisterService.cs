using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Authentication.Registration
{
    public interface IRegisterService
    {
        Task<bool> RegisterAsync(string username, string password, string firstName, string lastName);
    }
}
