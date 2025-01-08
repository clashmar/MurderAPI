using Microsoft.AspNetCore.Mvc;

namespace MurderAPI.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetHomeInformation()
        {
            return Ok("Welcome to the MurderAPI!");
        }
    }
}
