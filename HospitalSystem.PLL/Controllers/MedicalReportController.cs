using HospitalSystem.BLL.Service.Abstraction;
using HospitalSystem.DAL.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace HospitalSystem.PLL.Controllers
{

 //   [Authorize(Roles = "Patient")]
    public class MedicalReportController : Controller
    {
        private readonly IMedicalReportService _medicalReportService;

        public MedicalReportController(IMedicalReportService medicalReportService)
        {
            _medicalReportService = medicalReportService;
        }

        [HttpGet]
        public IActionResult ViewReport()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ViewReport(MedicalReport model)
        {
            if (ModelState.IsValid)
            {
                var report = _medicalReportService.GetReport(model.ReportID, model.PatientNationalId);

                if (report != null)
                {
                    return View("ReportDetails", report);
                }

                ModelState.AddModelError(string.Empty, "Report not found.");
            }

            return View(model);
        }

        public IActionResult MyReports()
        {
            var patientReports = _medicalReportService.GetPatientReports(User);

            if (!patientReports.Any())
            {
                ModelState.AddModelError(string.Empty, "No reports found for this patient.");
                return View();
            }

            return View(patientReports);
        }

        [HttpGet]
        public IActionResult ReportDetails(MedicalReport report)
        {
            return View(report);
        }

    }
}

