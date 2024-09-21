using System.ComponentModel.DataAnnotations;


namespace HospitalSystem.DAL.Entity
{
    public class Doctor 
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Specialization { get; set; }
        public string? Image { get; set; }
        public bool IsDelete { get; set; }
       
    }
}
