using HospitalSystem.DAL.Entity;
using System.Security.Claims;


namespace HospitalSystem.BLL.Service.Abstraction
{
    public interface IMedicalReportService
    {
        MedicalReport GetReport(string reportId, string patientNationalId);
        List<MedicalReport> GetPatientReports(ClaimsPrincipal user);
    }
}
