using CMS.Application.Features.Authentication.Login;
using CMS.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Test.Web.Controllers
{
    [ApiController]
    [Route("api/faculty")]
    public class FacultyController : ControllerBase
    {
        private readonly ApplicationDbContext _appDb;

        public FacultyController(ApplicationDbContext facultyDb, ApplicationDbContext appDb)
        {
            _appDb = appDb;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var faculty = await _appDb.Faculties
                .FirstOrDefaultAsync(f => f.Username == command.Username);

            if (faculty == null || !CMS.Infrastructure.Security.PasswordHasher.VerifyPassword(command.Password, faculty.HashedPassword))
            {
                return Unauthorized(new { message = "Invalid username or password." });
            }

            return Ok(new { message = "Login successful", facultyId = faculty.Id, department = faculty.Department });
        }

        [HttpGet("library/applications")]
        public async Task<IActionResult> GetLibraryApplications()
        {
            var applications = await _appDb.ClearanceApplications
                .Select(a => new
                {
                    a.Id,
                    a.FirstName,
                    a.LastName,
                    a.StudentNumber,
                    a.Course,
                    a.YearLevel,
                    a.Section
                })
                .ToListAsync();

            return Ok(applications);
        }
    }
}
