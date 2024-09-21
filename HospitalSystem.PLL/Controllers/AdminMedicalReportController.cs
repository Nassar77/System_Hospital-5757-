using AutoMapper;
using HospitalSystem.BLL.ModelVM.MedicalReport;
using HospitalSystem.BLL.Service.Abstraction;
using HospitalSystem.BLL.Service.Impelementation;
using HospitalSystem.DAL.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace HospitalSystem.PLL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMedicalReportController : Controller
    {
        private readonly IAMedicalReportService _AmedicalReportService;
        private readonly IMapper mapper;

        public AdminMedicalReportController(IAMedicalReportService AmedicalReportService, IMapper mapper)
        {
            _AmedicalReportService = AmedicalReportService;
           this. mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var reports = await _AmedicalReportService.GetAllReportsAsync();
            return View(reports);
          
        }
        
        [HttpGet]
        public IActionResult CreateReport()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateReport(CreateReportVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _AmedicalReportService.CreateReportAsync(model);

                if (result)
                {
                    ViewBag.SuccessMessage = "Report uploaded successfully!";
                    return View("ReportConfirmation");
                }
            }

            ModelState.AddModelError(string.Empty, "Please upload a report image.");
            return View(model);
        }

        public IActionResult ReportConfirmation()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var report = await _AmedicalReportService.GetReportByIdAsync(id);
            if (report == null)
            {
                return NotFound();
            }
            var reportViewModel = mapper.Map<EditReportVM>(report);
            return View(reportViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditReportVM model)
        {
            if (ModelState.IsValid)
            {
                var report = mapper.Map<MedicalReport>(model);
                await _AmedicalReportService.UpdateReportAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var success = _AmedicalReportService.Delete(id);
            if (success)
            {
                ViewBag.SuccessMessage = "Repot deleted successfully!";
                return RedirectToAction("Index");
            }

            return NotFound();
        }


    }

}
