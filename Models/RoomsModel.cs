using MurderAPI.Entities;
using System.Text.Json;

namespace MurderAPI.Models
{
    public interface IRoomsModel
    {
        List<Room>? GetAllRooms();
        Room? GetRoomByName(string name);
    }
    public class RoomsModel : IRoomsModel
    {
        public List<Room>? GetAllRooms()
        {
            return JsonSerializer.Deserialize<List<Room>>(File.ReadAllText("Json_Data\\Rooms.json"));
        }
        public Room? GetRoomByName(string name)
        {
            return GetAllRooms()?.FirstOrDefault(r => r.Name.ToLower() == name.ToLower());
        }
    }
}
