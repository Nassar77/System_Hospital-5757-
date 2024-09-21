
using HospitalSystem.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH.DAL.Repo.Abstracion
{
    public interface IDectorRepo
    {
        List<Doctor> GetDoctors();
        bool Edit(Doctor doc);
        bool Create(Doctor doc);
        bool DElete(Doctor doc);
		Doctor GetById(int id);
	}
}
