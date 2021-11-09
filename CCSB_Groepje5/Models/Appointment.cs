using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB_Groepje5.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public string AdminId { get; set; }
        public string CustomerId { get; set; }
        public string VehicleId { get; set; }
    }
}
