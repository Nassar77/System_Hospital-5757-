using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace HospitalSystem.DAL.Entity
{
    public class Patient : IdentityUser
    {
        [Required]
        [MaxLength(30, ErrorMessage = "Name must be less than 30 letter")]
        [MinLength(3, ErrorMessage = "NAme must be greater than 3 letter")]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@"(Male|Famale)", ErrorMessage = "Gender Must be Male or Fmale")]
        public string Gender { get; set; }= string.Empty;
        [Required]
        public string NationalId { get; set; }=string.Empty;
        
        public string? Address { get; set; }
        public string? City { get; set; }
      //  public string EmailVerificationCode { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string? Image { get; set; }
        public DateTime DOB { get; set; } = DateTime.Now;
        // public ICollection<Appointment> Appointments { get; set; }

        // Navigation property for the bills
        public ICollection<Bill>? Bills { get; set; }
    }
}
