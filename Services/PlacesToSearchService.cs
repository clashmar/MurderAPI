using MurderAPI.Entities;
using MurderAPI.Helpers;
using MurderAPI.Models;
using Newtonsoft.Json;

namespace MurderAPI.Services
{
    public interface IPlacesToSearchService
    {
        bool GetPlaceToSearch(string roomName, string placeName, out string? result);
    }
    public class PlacesToSearchService : IPlacesToSearchService
    {
        private readonly IPlacesToSearchModel _placesToSearchModel;
        private readonly IRoomsModel _roomsModel;

        public PlacesToSearchService(IPlacesToSearchModel placesToSearchModel, IRoomsModel roomsModel)
        {
            _placesToSearchModel = placesToSearchModel;
            _roomsModel = roomsModel;
        }

        public bool GetPlaceToSearch(string roomName, string placeName, out string? result)
        {
            result = null;
            Room? room = _roomsModel.GetAllRooms()!.FirstOrDefault(r => r.RoomName!.ToLower() == roomName.ToLower());
            if(room == null) return false;

            List<PlaceToSearch>? allPlacesToSearch = _placesToSearchModel.GetAllPlacesToSearch();
            if (allPlacesToSearch == null) return false;

            PlaceToSearch? placeToSearch = allPlacesToSearch!
                .Where(p => p.RoomId == room.Id && p.PlaceName!.ToLower() == placeName.ToLower())
                .FirstOrDefault();
            if (placeToSearch == null) return false;

            result = JsonConvert.SerializeObject(placeToSearch,
            Formatting.Indented,
            new JsonSerializerSettings
            {
                ContractResolver = new IgnorePropertiesResolver("RoomId")
            });
            return true;
        }
    }
}
