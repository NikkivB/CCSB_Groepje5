﻿using CCSB_Groepje5.Models.ViewModels;
using CCSB_Groepje5.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB_Groepje5.Services
{
    public class AppointmentService : IAppointmentService
    {
        public List<AdministratorViewModel> GetAdministratorList()
        {
            var administrators = (from user in _db.Users
                                  join userRole in _db.UserRoles on user.Id equals userRole.UserId
                                  join role in _db.Roles.Where(x => x.Name == Helper.Admin) on userRole.RoleId equals role.Id
                                  select new AdministratorViewModel
                                  {
                                      Id = user.Id,
                                      Name = string.IsNullOrEmpty(user.MiddleName) ?
                                      user.FirstName + " " + user.LastName :
                                      user.FirstName + " " + user.MiddleName + " " + user.LastName
                                  }
                                  ).OrderBy(u => u.Name).ToList();
            return administrators;
        }

        public List<KlantViewModel> GetKlantList()
        {
            var klanten = (from user in _db.Users
                                  join userRole in _db.UserRoles on user.Id equals userRole.UserId
                                  join role in _db.Roles.Where(x => x.Name == Helper.Klant) on userRole.RoleId equals role.Id
                                  select new AdministratorViewModel
                                  {
                                      Id = user.Id,
                                      Name = string.IsNullOrEmpty(user.MiddleName) ?
                                      user.FirstName + " " + user.LastName :
                                      user.FirstName + " " + user.MiddleName + " " + user.LastName
                                  }
                                  ).OrderBy(u => u.Name).ToList();
            return klanten;
        }
    }
}
