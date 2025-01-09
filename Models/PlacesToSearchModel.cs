using MurderAPI.Entities;
using System.Text.Json;

namespace MurderAPI.Models
{
    public interface IPlacesToSearchModel
    {
        List<PlaceToSearch>? GetAllPlacesToSearch();
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
    }
}
