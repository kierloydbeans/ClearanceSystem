using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Authentication.Login
{
    public class LoginCommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
