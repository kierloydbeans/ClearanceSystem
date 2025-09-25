using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Authentication
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
    }
}
