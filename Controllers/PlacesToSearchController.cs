using Microsoft.AspNetCore.Mvc;
using MurderAPI.Entities;
using MurderAPI.Services;

namespace MurderAPI.Controllers
{
    [ApiController]
    public class PlacesToSearchController : ControllerBase
    {
        private readonly IPlacesToSearchService _placesToSearchService;

        public PlacesToSearchController(IPlacesToSearchService placesToSearchService)
        {
            _placesToSearchService = placesToSearchService;
        }

        [HttpGet]
        [Route("/Rooms/{roomName}/{placeName}")] 
        public IActionResult GetPlaceToSearch(string roomName, string placeName)
        {
            if (_placesToSearchService.GetPlaceToSearch(roomName, placeName, out PlaceToSearch? result)) return Ok(result);
            return BadRequest("Cannot search there.");
        }
    }
}
