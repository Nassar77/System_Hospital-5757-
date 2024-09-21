using HospitalSystem.BLL.Service.Abstraction;
using HospitalSystem.DAL.Entity;
using HospitalSystem.DAL.Repo.Abstracion;
using HospitalSystem.DAL.Repo.Implemintation;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace SystemHospital.PLL.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService AppointmentService;

        public AppointmentController(IAppointmentService AppointmentService)
        {
            this.AppointmentService = AppointmentService;
        }

        // GET: Show the booking page
        public IActionResult Book()
        {
            return View();
        }

        // POST: Book an appointment
        [HttpPost]
        public IActionResult Book(DateTime date, TimeSpan time)
        {
            // Retrieve the logged-in patient's ID from the authentication context
            var patientId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Retrieves the user's ID

            if (string.IsNullOrEmpty(patientId))
            {
                // Handle error if patient ID is not found (e.g., not logged in)
                ViewBag.ErrorMessage = "Unable to retrieve patient information. Please log in.";
                return View();
            }

            var rooms = AppointmentService.GetAllRooms();
            RoomAvailability? bookedRoom = null;

            foreach (var room in rooms)
            {
                var broom = AppointmentService.BookRoom(room, date, time, patientId);
                if (broom != null)
                {
                    bookedRoom = broom;
                    break;
                }
            }


            if (bookedRoom == null)
            {
                // If no available rooms, show an error message
                ViewBag.ErrorMessage = "No available rooms at this time.";
                return View();
            }

            // If booking is successful, display confirmation
            ViewBag.SuccessMessage = $"Booked {bookedRoom.Room.RName} at {bookedRoom.Date.ToShortDateString()} {bookedRoom.Time}";
            ViewBag.RoomName = bookedRoom.Room.RName;
            ViewBag.BookingDate = bookedRoom.Date.ToShortDateString();
            ViewBag.BookingTime = bookedRoom.Time.ToString();

            return View("Confirmation");
        }

        // Confirmation page
        public IActionResult Confirmation(string date, TimeSpan time, string roomName)
        {
            ViewBag.Date = date;
            ViewBag.Time = time;
            ViewBag.RoomName = roomName;
            return View();
        }



        
        public IActionResult MyBills()
        {
            
            var patientId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var bills = AppointmentService.GetMyBills(patientId);

            return View(bills);
        }









    }
}
