using HospitalSystem.BLL.Service.Abstraction;
using HospitalSystem.DAL.Entity;
using HospitalSystem.DAL.Repo.Abstraction;
using System.Security.Claims;


namespace HospitalSystem.BLL.Service.Impelementation
{
    public class MedicalReportService : IMedicalReportService
    {
        private readonly IMedicalReportRepo _medicalReportRepo;

        public MedicalReportService(IMedicalReportRepo medicalReportRepo)
        {
            _medicalReportRepo = medicalReportRepo;
        }

        public MedicalReport GetReport(string reportId, string patientNationalId)
        {
            return _medicalReportRepo.GetByReportIdAndPatientId(reportId, patientNationalId);
        }

        public List<MedicalReport> GetPatientReports(ClaimsPrincipal user)
        {
            var patientId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            return _medicalReportRepo.GetReportsByPatientId(patientId);
        }
    }

}
