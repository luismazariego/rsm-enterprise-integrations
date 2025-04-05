using Microsoft.AspNetCore.Mvc;

namespace DIYBeers.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BeersController() : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetBeers()
    {
        return Ok();
    }
}
