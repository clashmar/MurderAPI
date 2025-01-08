using Microsoft.AspNetCore.Mvc;
using MurderAPI.Entities;
using MurderAPI.Services;

namespace MurderAPI.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomsService _roomsService;

        public RoomsController(IRoomsService roomsService)
        {
            _roomsService = roomsService;
        }

        [HttpGet]
        public IActionResult GetAllRooms()
        {
            if (_roomsService.GetAllRooms(out List<Room>? result)) return Ok(result);
            return BadRequest("Cannot find rooms.");
        }

        [HttpGet]
        [Route("{roomName}")]
        public IActionResult GetRoomByName(string roomName)
        {
            if (_roomsService.GetRoomByName(roomName, out Room? result)) return Ok(result);
            return BadRequest("This house does not have a room with that name.");
        }
    }
}
