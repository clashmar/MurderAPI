﻿using Microsoft.AspNetCore.Authorization;
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
            if (_placesToSearchService.GetPlaceToSearch(roomName, placeName, out string? result)) return Ok(result);
            return BadRequest("Not a valid location.");
        }

        [HttpGet]
        [Authorize]
        [Route("/Rooms/Basement/{placeName}")]
        public IActionResult GetPlaceToSearchInBasement(string placeName)
        {
            if (_placesToSearchService.GetPlaceToSearch("basement", placeName, out string? result)) return Ok(result);
            return BadRequest("Not a valid location.");
        }
    }
}
