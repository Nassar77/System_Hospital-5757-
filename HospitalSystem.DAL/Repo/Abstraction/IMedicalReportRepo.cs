using HospitalSystem.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.DAL.Repo.Abstraction
{
    public interface IMedicalReportRepo
    {
        MedicalReport GetByReportIdAndPatientId(string reportId, string patientNationalId);
        List<MedicalReport> GetReportsByPatientId(string patientId);
    }
}
