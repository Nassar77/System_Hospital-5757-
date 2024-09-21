using HospitalSystem.DAL.DB;
using HospitalSystem.DAL.Entity;
using HospitalSystem.DAL.Repo.Abstraction;


namespace HospitalSystem.DAL.Repo.Impelementation
{
    public class RoomRepo : IRoomRepo
    {
        private readonly AppDbContext _context;

        public RoomRepo(AppDbContext context)
        {
            _context = context;
        }

        public bool AddRoom(Room room)
        {
            _context.Rooms.Add(room);
            return _context.SaveChanges() > 0;
        }

        public Room GetRoomById(int id)
        {
            return _context.Rooms.FirstOrDefault(r => r.ID == id);
        }

        public List<Room> GetAllRooms()
        {
            return _context.Rooms.ToList();
        }

        public bool UpdateRoom(Room room)
        {
            _context.Rooms.Update(room);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteRoom(int id)
        {
            var room = _context.Rooms.FirstOrDefault(r => r.ID == id);
            if (room == null)
            {
                return false;
            }

            _context.Rooms.Remove(room);
            return _context.SaveChanges() > 0;
        }
    }

}
