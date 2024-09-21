using HospitalSystem.BLL.ModelVM.MedicalReport;
using HospitalSystem.DAL.Entity;


namespace HospitalSystem.BLL.Service.Abstraction
{
    public interface IAMedicalReportService
    {
        Task<bool> CreateReportAsync(CreateReportVM model);
        Task<List<MedicalReport>> GetAllReportsAsync();
        Task<MedicalReport> GetReportByIdAsync(int reportId);
        Task<bool> UpdateReportAsync(EditReportVM editReportVM);
        bool Delete(int id);
    }
}
