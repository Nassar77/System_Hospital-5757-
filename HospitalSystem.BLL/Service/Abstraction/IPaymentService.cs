using HospitalSystem.DAL.Entity;



namespace HospitalSystem.BLL.Service.Abstraction
{
    public interface IPaymentService 
    {
        public Bill ViewBill(int id);
    }
}
