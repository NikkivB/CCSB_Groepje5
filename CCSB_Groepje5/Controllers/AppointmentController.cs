using CCSB_Groepje5.Models;
using CCSB_Groepje5.Services;
using CCSB_Groepje5.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB_Groepje5.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly ApplicationDbContext _db;

        public AppointmentController(IAppointmentService appointmentService, ApplicationDbContext db)
        {
            _appointmentService = appointmentService;
            _db = db;
        }

        public IActionResult Index()
        {
            ViewBag.AdminList = _appointmentService.GetAdminList();
            ViewBag.CustomerList = _appointmentService.GetCustomerList();
            ViewBag.VehicleList = _appointmentService.GetVehicleList();
            ViewBag.Duration = Helper.GetTimeDropDown();
            return View();
        }
    }
}
