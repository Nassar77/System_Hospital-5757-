
using HospitalSystem.DAL.Entity;

namespace HospitalSystem.DAL.Repo.Abstraction
{
    public interface IPaymentRepo
    {
        public Bill ViewBill(int id);
    }
}
