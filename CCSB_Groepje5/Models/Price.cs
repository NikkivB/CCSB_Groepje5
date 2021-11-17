using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


    namespace CCSB_Groepje5.Models
{
    public class Price
    {
        [Key]
        public int Id { get; set; }
        public int NewPrice { get; set; }
        public string VehicleType { get; set; }
        public string AddedBy { get; set; }
        public DateTime EditDate { get; set; }
           
    }
}
