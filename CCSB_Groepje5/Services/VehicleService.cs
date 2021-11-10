using CCSB_Groepje5.Models;
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

        public List<VehicleViewModel> GetVehicleList()
        {


            var vehicles = (from vehicle in _db.Vehicles
                            join user in _db.Users on vehicle.CustomerId equals user.Id
                            select new VehicleViewModel
                            {
                                Id = vehicle.Id.ToString(),
                                LicensePlate = vehicle.LicensePlate
                            }
                                 ).OrderBy(v => v.LicensePlate).ToList();

            return vehicles;
        }
    }
}
