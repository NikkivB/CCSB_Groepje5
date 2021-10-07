using CCSB_Groepje5.Models;
using CCSB_Groepje5.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB_Groepje5.Controllers
{
    public class RegisterVehicleController : Controller
    {
        private readonly ApplicationDbContext _db;
        public RegisterVehicleController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index(RegisterVehicleViewModel model)
        {
            
            return View();
        }
    }
}
