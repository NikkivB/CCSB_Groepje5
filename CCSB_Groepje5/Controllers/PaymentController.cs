using CCSB_Groepje5.Models;
using CCSB_Groepje5.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CCSB_Groepje5.Controllers
{
    public class PaymentController : Controller
    {

        private readonly ApplicationDbContext _db;

        public PaymentController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult AddPayment()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPayment(PaymentViewModel model)
        {

            Payment p = new Payment();
            p.Amount = model.Amount;
            p.VehicleId = model.VehicleId;
            p.PaymentDate = model.PaymentDate;

            _db.Payment.Add(p);
            _db.SaveChanges();

            //displays what the license plate number was of the added vehicle
            ViewBag.message = "De betaling van: '" + model.Amount + " op " + model.PaymentDate + "' is toegevoegd!";
            return View();
        }
    }
}
