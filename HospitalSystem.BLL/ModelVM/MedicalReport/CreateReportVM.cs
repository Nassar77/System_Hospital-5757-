using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.BLL.ModelVM.MedicalReport
{
	public class CreateReportVM
	{
        public string ReportID { get; set; }

        public DateTime? DateCreated { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Please upload a report image.")]
        public IFormFile ReportImage { get; set; }

        [ForeignKey("Patient")]
        public string? PatientID { get; set; }
        public string PatientNationalId { get; set; }
    }
}
