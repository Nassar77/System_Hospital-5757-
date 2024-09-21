using HospitalSystem.DAL.Entity;

namespace HospitalSystem.BLL.Service.Abstraction
{
    public interface IAppointmentService
    {
        public List<Room> GetAllRooms();
        public RoomAvailability? BookRoom(Room room, DateTime date, TimeSpan time, string patientId);
        public List<Bill> GetMyBills(string PatientId);

    }
}
