using MurderAPI.Entities;
using MurderAPI.Helpers;
using MurderAPI.Models;
//using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace MurderAPI.Services
{
    public interface IRoomsService
    {
        bool GetAllRooms(out string? result);
        bool GetRoomByName(string name, out Room? result);
    }
    public class RoomsService : IRoomsService
    {
        private readonly IRoomsModel _roomsModel;

        public RoomsService(IRoomsModel roomsModel)
        {
            _roomsModel = roomsModel;
        }

        public bool GetAllRooms(out string? result)
        {
            List<Room>? allRooms = _roomsModel.GetAllRooms();
            result = null;
            if(allRooms == null) return false;

            foreach (Room room in allRooms!) room.Clues = null;
  
            result = JsonSerializer.Serialize(allRooms,
            new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                WriteIndented = true
            });
            return true;
        }

        public bool GetRoomByName(string name, out Room? result)
        {
            result = _roomsModel.GetRoomByName(name);
            return result != null;
        }
    }
}
