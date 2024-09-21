using HospitalSystem.DAL.Entity;

namespace HospitalSystem.BLL.Service.Abstraction
{
    public interface IRoomService
    {
        bool AddRoom(Room room);
        Room GetRoomById(int id);
        List<Room> GetAllRooms();
        bool UpdateRoom(Room room);
        bool DeleteRoom(int id);
    }

}
