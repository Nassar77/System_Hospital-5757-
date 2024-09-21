using HospitalSystem.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.DAL.Repo.Abstracion
{
    public interface IAppointmentRepo
    {
        public List<Room> GetAllRooms();
        public RoomAvailability? BookRoom(Room room, DateTime date, TimeSpan time, string PatientId);

        public List<Bill> GetMyBills(string patientId);
    }
}
