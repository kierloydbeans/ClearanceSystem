using CMS.Application.Features.Authentication.Login;
using CMS.Application.Features.Authentication.Registration;
using CMS.Infrastructure.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CMS.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IRegisterService _registerService;
        private readonly ITokenService _tokenService; 

        public AuthController(ILoginService loginService, IRegisterService registerService, ITokenService tokenService)
        {
            _loginService = loginService;
            _registerService = registerService;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            // validate the user credentials
        var user = await _loginService.AuthenticateAsync(command.Username, command.Password);

            if (user == null) // either has username or null
            {
                return Unauthorized(new { message = "Invalid username or password." });
            }

            // if credentials are valid, create a token and return it.
            var token = await _tokenService.CreateToken(user);

            return Ok(new { token = token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _registerService.RegisterAsync(command.Username, command.Password, command.FirstName, command.LastName);

            if (result)
            {
                return Ok(new { message = "User registered successfully!" });
            }

            return BadRequest(new { message = "Username already exists." });
        }
    }
}