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
    public class BlockDaysController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BlockDaysController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(BlockDaysViewModel model)
        {
            BlockDays bd = new BlockDays();
            bd.StartBd = model.StartBd;
            bd.EndBd = model.EndBd;

            _db.BlockDays.Add(bd);
            _db.SaveChanges();

            ViewBag.message = "er kunnen geen afsprkaen meer ingepland worden van: " + model.StartBd + " tot " + model.EndBd;

            return View();
        }
    }
}
