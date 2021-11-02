﻿using CCSB_Groepje5.Models;
using CCSB_Groepje5.Models.ViewModels;
using CCSB_Groepje5.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB_Groepje5.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly ApplicationDbContext _db;

        public VehicleService(ApplicationDbContext db)
        {
            _db = db;
        }


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

        //public async Task<int> AddUpDate(RegisterVehicleViewModel model)
        //{
            
        //    if (model != null && model.Id > 0)
        //    {
        //        //TODO: Add code for update vehicle
        //        return 1;
        //    }
        //    else
        //    {
        //        //Create vehicle based on viewmodel
        //        Vehicle v = new Vehicle();
        //        v.LicensePlate = model.LicensePlate;
        //        v.VehicleType = model.VehicleType;
        //        v.SurfaceTaken = model.SurfaceTaken;
        //        v.CustomerId = model.CustomerId;

        //        _db.Vehicles.Add(v);
        //        await _db.SaveChangesAsync();

        //        return 2;
        //    }
        //}


    }
}
