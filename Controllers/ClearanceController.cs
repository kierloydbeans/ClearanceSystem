using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CMS.Infrastructure.Data;
using CMS.Application.Features.ClearanceApplications;
using Microsoft.AspNetCore.Authorization; 
using CMS.Domain.Entities; 
using System; 

namespace Test.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Faculty")] 
    public class ClearanceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClearanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        /// Endpoint for students to submit a new clearance application.
        
        [HttpPost("apply")]
        [AllowAnonymous] 
        public async Task<IActionResult> SubmitClearanceApplication([FromBody] SubmitClearanceApplicationCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // creation of new ClearanceApplication entity from the command
            var application = new ClearanceApplication
            {
                LastName = command.LastName,
                FirstName = command.FirstName,
                Mi = command.Mi,
                ContactNumber = command.ContactNumber,
                Birthday = DateTime.Parse(command.Birthday), 
                Sex = command.Sex,
                StudentNumber = command.StudentNumber,
                Department = command.Department,
                Course = command.Course,
                YearLevel = command.YearLevel,
                Section = command.Section,
                EmailAddress = command.EmailAddress,
                PurposeOfClearance = command.PurposeOfClearance,
                SubmissionDate = DateTime.Parse(command.SubmissionDate), 
                LibraryStatus = "Pending" // Initialize default status fields
            };

            _context.ClearanceApplications.Add(application);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Clearance application submitted successfully!", applicationId = application.Id });
        }


        // new endpoint to update application status
        [HttpPut("update-status")]
        public async Task<IActionResult> UpdateApplicationStatus([FromBody] UpdateClearanceApplicationStatusDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!int.TryParse(request.ApplicationId, out int appId))
            {
                return BadRequest(new { message = "Invalid application ID format." });
            }

            var application = await _context.ClearanceApplications
                                            .FirstOrDefaultAsync(a => a.Id == appId); 

            if (application == null)
            {
                return NotFound(new { message = $"Application with ID {request.ApplicationId} not found." });
            }

            // update the LibraryStatus
            application.LibraryStatus = request.Status;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Application status updated successfully." });
        }
    }
}