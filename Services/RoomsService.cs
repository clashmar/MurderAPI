using MurderAPI.Entities;
using MurderAPI.Helpers;
using MurderAPI.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Text.Json;
using Newtonsoft.Json.Linq;

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

        public RoomsService(IRoomsModel roomsModel)
        {
            _roomsModel = roomsModel;
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

            result = JsonConvert.SerializeObject(room,
            Formatting.Indented,
            new JsonSerializerSettings
            {
                ContractResolver = new IgnorePropertiesResolver("Id", "IsLocked")
            });
            return true;
        }
    }
}
