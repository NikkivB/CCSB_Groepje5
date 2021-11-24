using System;
using System.ComponentModel.DataAnnotations;

namespace CCSB_Groepje5.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        public double Amount { get; set; }

        public int VehicleId { get; set; }

        public DateTime PaymentDate { get; set; }
    }
}
