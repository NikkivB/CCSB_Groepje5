using CCSB_Groepje5.Models;
using CCSB_Groepje5.Models.ViewModels;
using CCSB_Groepje5.Utility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB_Groepje5.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _db;

        public AppointmentService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<int> AddUpDate(AppointmentViewModel model)
        {
            var startDate = DateTime.Parse(model.StartDate, CultureInfo.CreateSpecificCulture("en-US"));
            var endDate = startDate.AddMinutes(Convert.ToDouble(model.Duration));
                if (model != null && model.Id > 0)
            {
                //TODO: Add code fo update appointment
                return 1;
            }
            else
            {
                //Create appointment based on viewmodel
                Appointment appointment = new Appointment()
                {
                    Title = model.Title,
                    Description = model.Description,
                    StartDate = startDate,
                    EndDate = endDate,
                    Duration = model.Duration,
                        AdminId = model.AdminId,
                        CustomerId = model.CustomerId,
                        IsAdminApproved = model.IsAdminApproved
                };
                _db.Appointments.Add(appointment);
                await _db.SaveChangesAsync();
                return 2;
            }
            }

        public List<AdminViewModel> GetAdminList()
        {
            var admins = (from user in _db.Users
                                  join userRole in _db.UserRoles on user.Id equals userRole.UserId
                                  join role in _db.Roles.Where(x => x.Name == Helper.Admin) on userRole.RoleId equals role.Id
                                  select new AdminViewModel
                                  {
                                      Id = user.Id,
                                      Name = string.IsNullOrEmpty(user.Middlename) ?
                                      user.FirstName + " " + user.LastName :
                                      user.FirstName + " " + user.Middlename + " " + user.LastName
                                  }
                                  ).OrderBy(u => u.Name).ToList();
            return admins;
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
    }
}
