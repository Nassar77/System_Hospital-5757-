using HospitalSystem.DAL.DB;
using HospitalSystem.DAL.Entity;
using HospitalSystem.DAL.Repo.Abstraction;


namespace HospitalSystem.DAL.Repo.Impelementation
{
    public class PaymentRepo : IPaymentRepo
    {
        private readonly AppDbContext db;
        public PaymentRepo(AppDbContext db)
        {
            this.db = db;
        }
        public Bill ViewBill(int id)
        {
            return db.Bills.FirstOrDefault(b => b.ID == id);
        }

    }
}
