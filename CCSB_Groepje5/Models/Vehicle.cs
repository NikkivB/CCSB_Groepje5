using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB_Groepje5.Models
{
    public class Vehicle
    {
        public int Id { get; set;}
        public string CustomerId { get; set; }
        public string LicensePlate { get; set; }
        public string VehicleType { get; set; }
        public int SurfaceTaken { get; set; }
    }
}
