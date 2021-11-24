using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB_Groepje5.Models.ViewModels
{
    public class PaymentViewModel
    {
        public int Id { get; set; }

        [DisplayName("Bedrag")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public double Amount { get; set; }

        [DisplayName("Voertuig")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public int VehicleId { get; set; }


        [DisplayName("Datum")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public DateTime PaymentDate { get; set; }
    }
}
