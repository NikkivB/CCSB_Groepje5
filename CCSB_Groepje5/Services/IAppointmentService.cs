using CCSB_Groepje5.Models;
using CCSB_Groepje5.Models.ViewModels;
using CCSB_Groepje5.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB_Groepje5.Services
{
    public interface IAppointmentService
    {
        public List<AdminViewModel> GetAdminList();
        public List<CustomerViewModel> GetCustomerList();
        public Task<int> AddUpDate(AppointmentViewModel model);
    }
}
