using Microsoft.AspNetCore.Mvc;
using HospitalSystem.DAL.Entity;
using Stripe;
using HospitalSystem.DAL.DB;
using HospitalSystem.BLL.Service.Abstraction;


namespace SystemHospital.PLL.Controllers
{
    public class PaymentController : Controller
    {
        // payment by used Stripe 
        private readonly IPaymentService paymentService;
        private readonly string _secretKey = "sk_test_51PyDZPKHC4DYBQLbDO0J11xfrIJ3EZBN5G33Y6MeVnMyVRr3Dodyr8XoHlH8BuWmLHMHUbf4woSdoNgGKbRqm1qJ00DpjFEqgq"; // Replace with your Stripe Secret Key
        private readonly AppDbContext db;

        public PaymentController(IPaymentService paymentService, AppDbContext db)
        {
            this.paymentService = paymentService;
            StripeConfiguration.ApiKey = _secretKey;
            this.db = db;
        }



        // Show a specific bill by ID
        [HttpGet]
        public IActionResult ViewBill(int id)
        {
            // Fetch the bill from the database using the provided ID
            Bill bill = paymentService.ViewBill(id);

            if (bill == null)
            {
                return NotFound("Bill not found");
            }

            // Pass the bill to the view
            return View(bill);
        }

        // Show payment form for unpaid bills
        [HttpGet]
        public IActionResult PayBill(int id)
        {
            // Fetch the bill by ID
            Bill bill = paymentService.ViewBill(id);

            if (bill == null)
            {
                return NotFound("Bill not found");
            }

            if (bill.IsPaid)
            {
                ViewBag.Message = "This bill has already been paid.";
                return RedirectToAction("ViewBill", new { id });
            }

            ViewBag.PublishableKey = "pk_test_51PyDZPKHC4DYBQLbAzmBpu7PhnF8iHIRZ1D9Sq9HYldT6tIt1Vut18JbK1BBCErKGeJytEeTj9lBWt01hKVaMNht00hRV3poG0"; // Replace with your Stripe Publishable Key
            return View("PaymentForm", bill); // Show payment form if bill is unpaid
        }

        // Process Stripe payment
        [HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult ProcessBillPayment(string stripeToken, int billID, decimal amount)
        {
            try
            {
                var options = new ChargeCreateOptions
                {
                    Amount = (long)(amount * 100), // Stripe works with amounts in cents
                    Currency = "usd",
                    Description = $"Bill Payment for Bill ID: {billID}",
                    Source = stripeToken,
                    Metadata = new Dictionary<string, string>
                    {
                        { "BillID", billID.ToString() }
                    }
                };

                var service = new ChargeService();
                Charge charge = service.Create(options);

                // If the charge is successful, update the bill record in the database
                Bill bill = paymentService.ViewBill(billID);
                if (bill != null)
                {
                    bill.StripePaymentId = charge.Id;
                    bill.PaymentDate = DateTime.Now;
                    bill.IsPaid = true;

                    db.SaveChanges(); // Save the changes to the database

                    ViewBag.Message = "Payment successful!";
                }

                return RedirectToAction("ViewBill", new { id = billID });
            }
            catch (StripeException ex)
            {
                ViewBag.Message = $"Payment failed: {ex.Message}";
                return View("ViewBill");
            }
        }
   
    
    
    }
}