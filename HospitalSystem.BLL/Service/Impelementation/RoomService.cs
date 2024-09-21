using HospitalSystem.BLL.Service.Abstraction;
using HospitalSystem.DAL.Entity;
using HospitalSystem.DAL.Repo.Abstraction;


namespace HospitalSystem.BLL.Service.Impelementation
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepo _roomRepo;

        public RoomService(IRoomRepo roomRepo)
        {
            _roomRepo = roomRepo;
        }

        public bool AddRoom(Room room)
        {
            var newRoom = new Room
            {
                RName = room.RName,
                Capacity = room.Capacity
            };

            return _roomRepo.AddRoom(newRoom);
        }

        public Room GetRoomById(int id)
        {
            return _roomRepo.GetRoomById(id);
        }

        public List<Room> GetAllRooms()
        {
            return _roomRepo.GetAllRooms();
        }

        public bool UpdateRoom(Room room)
        {
            var existingRoom = _roomRepo.GetRoomById(room.ID);
            if (existingRoom == null)
            {
                return false;
            }

            existingRoom.RName = room.RName;
            existingRoom.Capacity = room.Capacity;

            return _roomRepo.UpdateRoom(existingRoom);
        }

        public bool DeleteRoom(int id)
        {
            return _roomRepo.DeleteRoom(id);
        }
    }

}
