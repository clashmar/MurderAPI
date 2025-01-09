using MurderAPI.Entities;
using MurderAPI.Helpers;
using MurderAPI.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using Microsoft.IdentityModel.Tokens;

namespace MurderAPI.Services
{
    public interface IRoomsService
    {
        bool GetAllRooms(out string? result);
        bool GetRoomByName(string name, out string? result);
    }
    public class RoomsService : IRoomsService
    {
        private readonly IRoomsModel _roomsModel;
        private readonly IPlacesToSearchModel _placesToSearchModel;

        public RoomsService(IRoomsModel roomsModel, IPlacesToSearchModel placesToSearchModel)
        {
            _roomsModel = roomsModel;
            _placesToSearchModel = placesToSearchModel;
        }

        public bool GetAllRooms(out string? result)
        {
            List<Room>? allRooms = _roomsModel.GetAllRooms();
            result = null;
            if(allRooms == null) return false;

            result = JsonConvert.SerializeObject(allRooms,
            Formatting.Indented,
            new JsonSerializerSettings
            {
                ContractResolver = new IgnorePropertiesResolver("Id", "Impressions")
            });
            return true;
        }

        public bool GetRoomByName(string name, out string? result)
        {
            Room? room = _roomsModel.GetRoomByName(name);
            result = null;
            if(room == null) return false;

            string roomJson = JsonConvert.SerializeObject(room,
            Formatting.Indented,
            new JsonSerializerSettings
            {
                ContractResolver = new IgnorePropertiesResolver("Id", "IsLocked")
            });

            List<string>? placesToSearch = _placesToSearchModel.GetAllPlacesToSearch()!
                .Where(p => p.RoomId == room.Id)
                .Select(p => p.PlaceName)
                .ToList()!;

            string placesJson = placesToSearch.Count > 0 ? JsonConvert.SerializeObject(placesToSearch, Formatting.Indented) : JsonConvert.SerializeObject("Nowhere", Formatting.Indented);

            JObject roomObject = JObject.Parse(roomJson);
            roomObject.Add("PlacesToSearch", JToken.Parse(placesJson));
            result = roomObject.ToString();
            return true;
        }
    }
}
