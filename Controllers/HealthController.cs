using Microsoft.AspNetCore.Mvc;

namespace MurderAPI.Controllers
{
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        [Route("/[controller]")]
        public IActionResult CheckServerHealth()
        {
            return Ok("Server is healthy.");
        }
    }
}
