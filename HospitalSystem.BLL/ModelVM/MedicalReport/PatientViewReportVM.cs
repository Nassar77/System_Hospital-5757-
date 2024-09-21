using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.BLL.ModelVM.MedicalReport
{
	public class PatientViewReportVM
	{
		public string ReportID { get; set; }

		public string? ReportImagePath { get; set; } 
	}
}
