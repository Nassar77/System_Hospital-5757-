using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HospitalSystem.DAL.Entity
{
    public class Bill
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Patient")]
        public string? PatientID { get; set; }  
        public Patient? Patient { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public DateTime? PaymentDate { get; set; } = DateTime.Now;
        public string? StripePaymentId { get; set; }

        [ForeignKey("RoomAvailability")]
        public int? RoomAvailabilityID { get; set; }
        public RoomAvailability? RoomAvailability { get; set; } 

        public bool IsPaid { get; set; } = false;
    }
}
