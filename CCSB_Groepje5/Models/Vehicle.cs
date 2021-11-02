using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB_Groepje5.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set;}
        public string LicensePlate { get; set; }
        public string VehicleType { get; set; }
        public int SurfaceTaken { get; set; }
        public string CustomerId { get; set; }
    }
}
