using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB_Groepje5.Models.ViewModels
{
    public class AppointmentViewModel
    {
        public int? Id { get; set; }
        public string CustomerName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int Duration { get; set; }
        public string AdminId { get; set; }
        public string CustomerId { get; set; }
        public string VehicleId { get; set; }
        public string AdminName { get; set; }
        public bool IsForCustomer { get; set; }
    }
}
