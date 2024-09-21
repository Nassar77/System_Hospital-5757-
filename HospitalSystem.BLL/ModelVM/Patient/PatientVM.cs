using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.BLL.ModelVM.Patient
{
    public class PatientVM
    {
        [Required]
        [MaxLength(30, ErrorMessage = "Name must be less than 30 characters")]
        [MinLength(3, ErrorMessage = "Name must be greater than 3 characters")]
        public required string FullName { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public required string NationalId { get; set; }
        public IFormFile? FormFile { get; set; }

        public string? Address { get; set; }
        public string? City { get; set; }
        public bool IsDeleted { get; set; } = false;
        [Required]
        public DateTime DOB { get; set; }
    }
}
