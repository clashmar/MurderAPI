using Microsoft.AspNetCore.Mvc;
using MurderAPI.Entities;
using MurderAPI.Services;
using Newtonsoft.Json.Linq;

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
            if (_roomsService.GetAllRooms(out string? result)) return Ok(result);
            return BadRequest("Cannot find rooms.");
        }

        [HttpGet]
        [Route("{roomName}")]
        public IActionResult GetRoomByName(string roomName)
        {
            if (_roomsService.GetRoomByName(roomName, out string? result)) return Ok(result);
            return BadRequest("This house does not have a room with that name.");
        }

        [HttpGet]
        [Route("Basement")]
        public IActionResult GetBasement(string? password)
        {
            if (password == null || password!.ToLower() != "bastet") return Unauthorized("At the bottom of the stairs you see an imposing brass door sealed with an in-built, six-character alphabetical lock. Above the combination lock is an embossed relief of a regal looking Egyptian cat.");
            if (_roomsService.GetRoomByName("basement", out string? result)) return Ok(result);
            return BadRequest("This house does not have a room with that name.");
        }
    }
}
