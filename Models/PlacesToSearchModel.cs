using MurderAPI.Entities;
using System.Text.Json;

namespace MurderAPI.Models
{
    public interface IPlacesToSearchModel
    {
        List<PlaceToSearch>? GetAllPlacesToSearch();
        //PlaceToSearch? GetPlaceToSearch(string roomName, string placeName);
    }
    public class PlacesToSearchModel : IPlacesToSearchModel
    {
        private readonly IRoomsModel _roomsModel;

        public PlacesToSearchModel(IRoomsModel roomsModel)
        {
            _roomsModel = roomsModel;
        }

        public List<PlaceToSearch>? GetAllPlacesToSearch()
        {
            return JsonSerializer.Deserialize<List<PlaceToSearch>>(File.ReadAllText("Json_Data\\PlacesToSearch.json"));
        }

        //public PlaceToSearch? GetPlaceToSearch(string roomName, string placeName)
        //{
        //    return GetAllPlacesToSearch()!
        //        .Where(p => p.RoomId == _roomsModel.GetAllRooms()!.FirstOrDefault(r => r.RoomName!.ToLower() == roomName.ToLower())!.Id)
        //        .Where(p => p.PlaceName!.ToLower() == placeName.ToLower())
        //        .FirstOrDefault();
        //}
    }
}
