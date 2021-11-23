using CCSB_Groepje5.Models;
using CCSB_Groepje5.Models.ViewModels;
using CCSB_Groepje5.Services;
using CCSB_Groepje5.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CCSB_Groepje5.Controllers
{
    public class PriceController : Controller
    {

        private readonly ApplicationDbContext _db;

        public PriceController(ApplicationDbContext db) { _db = db; }

        public IActionResult AddPrice()
        {return View();}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPrice(PricesViewModel model)
        {
            var today = DateTime.Now;
            var admin = User.Identity.Name.ToString();

            Price p = new Price();
            p.VehicleType = model.VehicleType;
            p.NewPrice = model.NewPrice;
            p.EditDate = today;
            p.AddedBy = admin;

            _db.Prices.Add(p);
            _db.SaveChanges();

            return View(p);
        }

        public IActionResult ShowPrice()
        {
            ViewBag.PriceCamper = _db.Prices.Where(x => x.VehicleType == "Camper");
            return View();
        }
    }
}
