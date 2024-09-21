using HospitalSystem.BLL.Service.Abstraction;
using HospitalSystem.DAL.Entity;
using HospitalSystem.DAL.Repo.Abstraction;



namespace HospitalSystem.BLL.Service.Impelementation
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepo paymentRepo;
        public PaymentService(IPaymentRepo paymentRepo)
        { this.paymentRepo = paymentRepo; }

        public Bill ViewBill(int id)
        {
            return paymentRepo.ViewBill(id);
        }
    }
}
