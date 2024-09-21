using HospitalSystem.BLL.Helper;
using HospitalSystem.BLL.ModelVM.MedicalReport;
using HospitalSystem.BLL.Service.Abstraction;
using HospitalSystem.DAL.Entity;
using HospitalSystem.DAL.Repo.Abstraction;

namespace HospitalSystem.BLL.Service.Impelementation
{
    public class AMedicalReportService : IAMedicalReportService
    {
        
        private readonly IAMedicalReportRepo _AmedicalReportRepo;

        public AMedicalReportService( IAMedicalReportRepo AmedicalReportRepo)
        {
            
            _AmedicalReportRepo = AmedicalReportRepo;
        }

        public async Task<bool> CreateReportAsync(CreateReportVM model)
        {
            var uploadedFileName = UploadImage.UploadFile("reports", model.ReportImage);

            if (string.IsNullOrEmpty(uploadedFileName))
            {
                return false; 
            }

            var report = new MedicalReport
            {
                ReportID = model.ReportID,
                PatientNationalId = model.PatientNationalId,
                ReportImagePath = uploadedFileName
            };

            await _AmedicalReportRepo.AddReportAsync(report);
            return true;
        }
        public async Task<List<MedicalReport>> GetAllReportsAsync()
        {
            return await _AmedicalReportRepo.GetAllReportsAsync();
        }

        public async Task<MedicalReport> GetReportByIdAsync(int reportId)
        {
            return await _AmedicalReportRepo.GetReportByIdAsync(reportId);
        }

        public async Task<bool> UpdateReportAsync(EditReportVM editReportVM)
        {
            var uploadedFileName = UploadImage.UploadFile("reports", editReportVM.ReportImage);

            if (string.IsNullOrEmpty(uploadedFileName))
            {
                return false;
            }

            var report = new MedicalReport
            {
                ReportID = editReportVM.ReportID,
                PatientNationalId = editReportVM.PatientNationalId,
                ReportImagePath = uploadedFileName
            };
            await _AmedicalReportRepo.UpdateReportAsync(report);
            return true;
        }
         public bool Delete(int id)
        {
            return _AmedicalReportRepo.Delete(id);
        }
    }

}
