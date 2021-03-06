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
    public class RegisterVehicleController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IVehicleService _IVehicleService;

        public RegisterVehicleController(IVehicleService vehicleService, ApplicationDbContext db)
        {
            _IVehicleService = vehicleService;
            _db = db;
        }

        //Get a list of customers
        public List<CustomerViewModel> GetCustomerList()
        {
            var customers = (from user in _db.Users
                             join userRole in _db.UserRoles on user.Id equals userRole.UserId
                             join role in _db.Roles.Where(x => x.Name == Helper.Customer) on userRole.RoleId equals role.Id
                             select new CustomerViewModel
                             {
                                 Id = user.Id,
                                 Name = string.IsNullOrEmpty(user.Middlename) ?
                                 user.FirstName + " " + user.LastName :
                                 user.FirstName + " " + user.Middlename + " " + user.LastName
                             }
                                  ).OrderBy(u => u.Name).ToList();
            return customers;
        }

        

        public IActionResult Index()
        {
            ViewBag.CustomerList = _IVehicleService.GetCustomerList();

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(RegisterVehicleViewModel model)
        {
            ViewBag.CustomerList = _IVehicleService.GetCustomerList();

            // Value inside the if statement (waarde aangeven)
            // Value Uppercase is set, only uppercases
            if (model.LicensePlate.ToUpper().Contains('A') || model.LicensePlate.ToUpper().Contains('E') || model.LicensePlate.ToUpper().Contains('U') || model.LicensePlate.ToUpper().Contains('O') || model.LicensePlate.ToUpper().Contains('I'))
            {
                ViewBag.message = "Onjuist: Voeg geen klinkers toe aan Kentekenplaat.";
            }
            else if (model.LicensePlate.IndexOf("-") == 0 || model.LicensePlate.EndsWith("-"))
    {
                ViewBag.message = "Onjuist: Geen streepjes voor/achter/naast elkaar in";
            }
            else if (model.LicensePlate != model.LicensePlate.ToUpper())
            {
                ViewBag.message = "Onjuist: Geen hoofdletters";
            }
            else if (model.LicensePlate.Length != 8)
            {
                ViewBag.message = "Onjuist: Je hebt geen 8 tekens";
            }
            else
            {

                //creating a new vehicle based on the input in the RegisterVehicle/Index.
                Vehicle v = new Vehicle();
                v.LicensePlate = model.LicensePlate;
                v.VehicleType = model.VehicleType;
                v.SurfaceTaken = model.SurfaceTaken;
                v.CustomerId = model.CustomerId;

                _db.Vehicles.Add(v);
                _db.SaveChanges();

                //displays what the license plate number was of the added vehicle
                ViewBag.message = "Het voertuig met kentekenplaat: '" + model.LicensePlate + "' is toegevoegd!";

            }


            return View();
        }
    }
}