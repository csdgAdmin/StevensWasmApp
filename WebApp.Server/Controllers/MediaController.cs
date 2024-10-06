using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MediaController : ControllerBase
{
    [HttpGet("Public")]
    public IActionResult Public()
    {
        return Ok("You are in the MediaController domain - on public property.");
    }
}
