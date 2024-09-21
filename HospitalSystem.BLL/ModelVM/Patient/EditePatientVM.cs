using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.BLL.ModelVM.Patient
{
    public class EditePatientVM
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalId { get; set; }
        public string? Image { get; set; }
         public IFormFile? NewProfileImage { get; set; }
        //    public string ExistingProfileImagePath { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }

    }
}
