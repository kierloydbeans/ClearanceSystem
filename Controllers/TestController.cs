using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
[Authorize] 
public class TestController : ControllerBase
{
    [HttpGet("protected")]
    public IActionResult GetProtectedData()
    {
        return Ok("You have successfully accessed a protected endpoint!");
    }
}