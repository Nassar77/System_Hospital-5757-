using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace HospitalSystem.DAL.Entity
{
    public class RoomAvailability
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Room")]
        public int RoomID { get; set; }
        private Room _room;
        public Room Room
        {
            get => _room;
            set
            {
                _room = value;
                // Set AvailablePlaces only if it hasn't been modified (0 means default value and hasn't been set)
                if (_room != null && AvailablePlaces == 0)
                {
                    AvailablePlaces = _room.Capacity;
                }
            }
        }

        public DateTime Date { get; set; } // Date of availability
        public TimeSpan Time { get; set; } // Time slot

        private int _availablePlaces;
        public int AvailablePlaces
        {
            get => _availablePlaces;
            set
            {
                // Allow changing AvailablePlaces but do not change it back to the room capacity automatically
                _availablePlaces = value;
            }
        }
        [ForeignKey("Patient")]
        public string? PatientID { get; set; }
        public Patient? Patient { get; set; }

    }
}
