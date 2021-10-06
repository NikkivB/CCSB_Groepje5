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

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        public IActionResult Index()
        {
            ViewBag.AdminList = _appointmentService.GetAdminList();
            ViewBag.CustomerList = _appointmentService.GetCustomerList();
            ViewBag.Duration = Helper.GetTimeDropDown();
            return View();
        }
    }
}
