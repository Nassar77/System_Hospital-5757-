using HospitalSystem.DAL.DB;
using HospitalSystem.DAL.Entity;
using HospitalSystem.DAL.Repo.Abstracion;
using System.Security.Claims;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace HospitalSystem.DAL.Repo.Implemintation
{
    public class AppointmentRepo : IAppointmentRepo
    {

        private readonly AppDbContext db;
        public AppointmentRepo(AppDbContext db)
        {
            this.db = db;
        }



        // Get all rooms from the database
        public List<Room> GetAllRooms()
        {
            return db.Rooms.ToList();
        }
        public RoomAvailability? BookRoom(Room room, DateTime date, TimeSpan time, string PatientId)
        {
            // Check if this specific availability already exists
            var existingAvailability = db.RoomAvailabilities
                .Where(ra => ra.RoomID == room.ID && ra.Date == date && ra.Time == time)
                .OrderByDescending(ra => ra.ID)
                .FirstOrDefault();



            if (existingAvailability == null)
            {

                // Create a new RoomAvailability record for the specific date and time
                var roomAvailability = new RoomAvailability
                {
                    RoomID = room.ID,
                    Date = date,
                    Time = time,
                    AvailablePlaces = room.Capacity - 1, // Initialize with the room's capacity
                    PatientID = PatientId
                };
                var bill = new Bill
                {
                    Amount = 250,
                    PaymentDate = DateTime.Now,
                    PatientID = PatientId,
                    RoomAvailability = roomAvailability
                };
                db.RoomAvailabilities.Add(roomAvailability);
                db.Bills.Add(bill);
                db.SaveChanges();
                
                return roomAvailability;
            }
            else if (existingAvailability.AvailablePlaces == 0)
            {
                return null;
            }
            else
            {
                // Create a new RoomAvailability record for the specific date and time
                var roomAvailability = new RoomAvailability
                {
                    RoomID = room.ID,
                    Date = date,
                    Time = time,
                    AvailablePlaces = existingAvailability.AvailablePlaces - 1// Initialize with the room's capacity
                };
                var bill = new Bill
                {
                    Amount = 250,
                    PaymentDate = DateTime.Now,
                    PatientID = PatientId,
                    RoomAvailability = roomAvailability
                };

                db.RoomAvailabilities.Add(roomAvailability);
                db.Bills.Add(bill);
                db.SaveChanges();
                return roomAvailability;
            }
        }

        public List<Bill> GetMyBills(string patientId)
        {
           return db.Bills.Where(b => b.PatientID == patientId).ToList();
        }
    }
    }

