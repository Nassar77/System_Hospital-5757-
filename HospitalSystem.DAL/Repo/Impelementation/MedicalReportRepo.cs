using HospitalSystem.DAL.DB;
using HospitalSystem.DAL.Entity;
using HospitalSystem.DAL.Repo.Abstraction;


namespace HospitalSystem.DAL.Repo.Impelementation
{
    public class MedicalReportRepo : IMedicalReportRepo
    {
        private readonly AppDbContext _context;

        public MedicalReportRepo(AppDbContext context)
        {
            _context = context;
        }

        public MedicalReport GetByReportIdAndPatientId(string reportId, string patientNationalId)
        {
            return _context.MedicalReports
                    .FirstOrDefault(r => r.ReportID == r.ReportID && r.PatientNationalId == r.PatientNationalId);

        }

        public List<MedicalReport> GetReportsByPatientId(string patientId)
        {
            var patientNationalId = _context.Patients
                .Where(p => p.Id == patientId)
                .Select(p => p.NationalId)
                .FirstOrDefault();

            return _context.MedicalReports
                .Where(r => r.PatientNationalId == patientNationalId)
                .ToList();
        }
    }
}
