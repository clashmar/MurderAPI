using MurderAPI.Entities;
using MurderAPI.Models;

namespace MurderAPI.Services
{
    public interface IPlacesToSearchService
    {
        bool GetPlaceToSearch(string roomName, string placeName, out PlaceToSearch? result);
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

        public bool GetPlaceToSearch(string roomName, string placeName, out PlaceToSearch? result)
        {
            result = null;
            Room? room = _roomsModel.GetAllRooms()!.FirstOrDefault(r => r.RoomName!.ToLower() == roomName.ToLower());
            if(room == null) return false;

            List<PlaceToSearch>? allPlacesToSearch = _placesToSearchModel.GetAllPlacesToSearch();
            if (allPlacesToSearch == null) return false;

            result = allPlacesToSearch!
                .Where(p => p.RoomId == room.Id && p.PlaceName!.ToLower() == placeName.ToLower())
                .FirstOrDefault();

            if(result == null) return false;
            return true;
        }
    }
}
