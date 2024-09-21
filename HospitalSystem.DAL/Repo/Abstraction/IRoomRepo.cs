using HospitalSystem.DAL.Entity;


namespace HospitalSystem.DAL.Repo.Abstraction
{
    public interface IRoomRepo
    {
        bool AddRoom(Room room);
        Room GetRoomById(int id);
        List<Room> GetAllRooms();
        bool UpdateRoom(Room room);
        bool DeleteRoom(int id);
    }

}
