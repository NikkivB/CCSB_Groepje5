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
using MimeKit;
using MailKit.Net.Smtp;

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

        /// <summary>Gets the customer list.</summary>
       
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
        public IActionResult Index(RegisterVehicleViewModel model, RegisterViewModel model1)
        {
            ViewBag.CustomerList = _IVehicleService.GetCustomerList();

            ViewBag.User = _db.Users.Where(x => x.Email == User.Identity.Name).ToList();
            ViewBag.User = _db.Users.Where(x => x.FirstName == model1.FirstName).ToList();

            //creating a new vehicle based on the input in the RegisterVehicle/Index.
            Vehicle v = new Vehicle();
            v.LicensePlate = model.LicensePlate;
            v.VehicleType = model.VehicleType;
            v.SurfaceTaken = model.SurfaceTaken;
            v.CustomerId = model.CustomerId;

            _db.Vehicles.Add(v);
            _db.SaveChanges();

            //    var message = new MimeMessage();
            //System.Net.Mime.ContentType contentType = new System.Net.Mime.ContentType();
            //contentType.MediaType = System.Net.Mime.MediaTypeNames.Application.Octet;
            //contentType.Name = "test.docx";
            //message.Attachments.Add(new System.Net.Mail.Attachment("I:/files/test.docx", contentType));
            //message.From.Add(new MailboxAddress("Registratie voertuig", "Groepje_5@gmail.com"));
            //message.To.Add(new MailboxAddress(model1.FirstName, User.Identity.Name));
            //message.Subject = "Bedankt voor het registreren van het voertuig";
            //message.Body = new TextPart("plain")
            //{
            //    Text = "Beste " + model1.FirstName + ",\n" + "Er is zojuist een voertuig geregistreerd bij camper-en carvan stalling Bentelo. " +
            //    "Dit is een overzicht van uw registratie:" + "\n" + "Nummerplaat: " + model.LicensePlate + "\n" + "Voertuigtype: " + model.VehicleType
            //    + "\n" + "Lengte van het voertuig: " + model.SurfaceTaken + " meter" + "\n" + "\n" + "Als deze gegevens niet kloppen of als deze email niet voor u bestemd is, kan je altijd bellen naar: 0687654321" + "\n" +
            //                "Met vriendelijke groet," + "\n" + "CCBS"
            //};
            //using (var client = new SmtpClient())
            //{
                
            //    client.Connect("smtp.gmail.com", 587, false);
            //    client.Authenticate("campergroepje5@gmail.com", "Test123#");

            //    client.Send(message);

            //    client.Disconnect(true);
            //}

            //displays what the license plate number was of the added vehicle
            ViewBag.message = "Het voertuig met kentekenplaat: " + model.LicensePlate + " is toegevoegd!";


            return View();
        }
    }
}
