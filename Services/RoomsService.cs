using MurderAPI.Entities;
using MurderAPI.Models;

namespace MurderAPI.Services
{
    public interface IRoomsService
    {
        bool GetAllRooms(out List<Room>? result);
        bool GetRoomByName(string name, out Room? result);
    }
    public class RoomsService : IRoomsService
    {
        private readonly IRoomsModel _roomsModel;

        public RoomsService(IRoomsModel roomsModel)
        {
            _roomsModel = roomsModel;
        }

        public bool GetAllRooms(out List<Room>? result)
        {
            result = _roomsModel.GetAllRooms();
            return result != null;
        }

        public bool GetRoomByName(string name, out Room? result)
        {
            result = _roomsModel.GetRoomByName(name);
            return result != null;
        }
    }
}
