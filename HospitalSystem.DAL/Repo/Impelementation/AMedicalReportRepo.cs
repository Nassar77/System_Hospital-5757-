
using HospitalSystem.DAL.DB;
using HospitalSystem.DAL.Entity;
using HospitalSystem.DAL.Repo.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.DAL.Repo.Impelementation
{
    public class AMedicalReportRepo : IAMedicalReportRepo
    {
        private readonly AppDbContext _context;

        public AMedicalReportRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddReportAsync(MedicalReport report)
        {
            _context.MedicalReports.Add(report);
            await _context.SaveChangesAsync();
        }
        public async Task<List<MedicalReport>> GetAllReportsAsync()
        {
            return await _context.MedicalReports.ToListAsync();
        }

        public async Task<MedicalReport> GetReportByIdAsync(int reportId)
        {
            return await _context.MedicalReports.FindAsync(reportId);
        }

        public async Task UpdateReportAsync(MedicalReport report)
        {
            _context.MedicalReports.Update(report);
            await _context.SaveChangesAsync();
        }

        public bool Delete(int id)
        {
            var report = _context.MedicalReports.FirstOrDefault(r => r.ID == id);
            if (report == null)
            {
                return false;
            }

            _context.MedicalReports.Remove(report);
            return _context.SaveChanges() > 0;
        }
    }
}
