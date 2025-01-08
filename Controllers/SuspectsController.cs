using Microsoft.AspNetCore.Mvc;
using MurderAPI.Entities;
using MurderAPI.Services;

namespace MurderAPI.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class SuspectsController : ControllerBase
    {
        private readonly ISuspectsService _suspectsService;

        public SuspectsController(ISuspectsService suspectsService)
        {
            _suspectsService = suspectsService;
        }

        [HttpGet]
        public IActionResult GetAllSuspects()
        {
            if(_suspectsService.GetAllSuspects(out List<Suspect>? result)) return Ok(result);
            return NotFound("There are currently no suspects.");
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetSuspectById(int id)
        {
            if (_suspectsService.GetSuspectById(id, out Suspect? result)) return Ok(result);
            return BadRequest("There is no suspect with that ID.");
        }
    }
}
