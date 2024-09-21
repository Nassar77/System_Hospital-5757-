using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace HospitalSystem.DAL.Entity
{
    public class Appointment
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Patient")]
        public string? PatientID { get; set; }
        public Patient? Patient { get; set; }
        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }
        public Doctor? Doctor { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        
        [ForeignKey("RoomAvailability")]
        public int RoomAvailabilityID { get; set; } // Linking to specific room availability
        public RoomAvailability RoomAvailability { get; set; }
    }

}
