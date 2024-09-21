using HospitalSystem.DAL.DB;
using HospitalSystem.DAL.Entity;
using Microsoft.EntityFrameworkCore;

using SH.DAL.Repo.Abstracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH.DAL.Repo.Implemintation
{
    public class DoctorRepo : IDectorRepo
    {
        private readonly AppDbContext entitiy;

        public DoctorRepo(AppDbContext entitiy)
        {
            this.entitiy = entitiy;
        }
		bool IDectorRepo.Create(Doctor doc)
		{
			try
			{
				entitiy.Doctors.Add(doc);
				entitiy.SaveChanges();
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}

		bool IDectorRepo.DElete(Doctor doc)
		{
			try
			{

				var data = entitiy.Doctors.Where(e => e.Id == doc.Id).FirstOrDefault();
				data.IsDelete = !data.IsDelete;
				entitiy.SaveChanges();
				return true;

			}
			catch (Exception)
			{
				return false;
			}
		}

		bool IDectorRepo.Edit(Doctor doc)
		{
			try
			{
				var data = entitiy.Doctors.Where(d => d.Id == doc.Id).FirstOrDefault();
				data.FullName = doc.FullName;
				data.Address = doc.Address;
				data.PhoneNumber = doc.PhoneNumber;
				data.Email = doc.Email;
				data.Gender = data.Gender;
				data.Specialization = data.Specialization;
				entitiy.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		Doctor IDectorRepo.GetById(int id)
		{
			return entitiy.Doctors.Where(e => e.Id == id).FirstOrDefault();
		}

		List<Doctor> IDectorRepo.GetDoctors()
		{
			return entitiy.Doctors.ToList();
		}

	}
}
