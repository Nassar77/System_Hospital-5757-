using HospitalSystem.BLL.Service.Abstraction;
using HospitalSystem.DAL.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalSystem.PLL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoomsController : Controller
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public IActionResult AddRoom()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRoom(Room room)
        {
            if (ModelState.IsValid)
            {
                var success = _roomService.AddRoom(room);
                if (success)
                {
                    ViewBag.SuccessMessage = "Room added successfully!";
                    return View("RoomConfirmation");
                }
            }

            return View(room);
        }

        public IActionResult RoomConfirmation()
        {
            return View();
        }

        public IActionResult AllRooms()
        {
            var rooms = _roomService.GetAllRooms();
            return View(rooms);
        }

        [HttpGet]
        public IActionResult EditRoom(int id)
        {
            var room = _roomService.GetRoomById(id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        [HttpPost]
        public IActionResult EditRoom(Room room)
        {
            if (ModelState.IsValid)
            {
                var success = _roomService.UpdateRoom(room);
                if (success)
                {
                    ViewBag.SuccessMessage = "Room updated successfully!";
                    return RedirectToAction("AllRooms");
                }
            }

            return View(room);
        }

        [HttpPost]
        public IActionResult DeleteRoom(int id)
        {
            var success = _roomService.DeleteRoom(id);
            if (success)
            {
                ViewBag.SuccessMessage = "Room deleted successfully!";
                return RedirectToAction("AllRooms");
            }

            return NotFound();
        }
    }


}
