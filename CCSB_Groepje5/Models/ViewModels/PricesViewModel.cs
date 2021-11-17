using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB_Groepje5.Models.ViewModels
{
    public class PricesViewModel
    {
        public int Id { get; set; }

        [DisplayName("Prijs")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public int NewPrice { get; set; }

        [DisplayName("Type voertuig")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string VehicleType { get; set; }

        public string AddedBy { get; set; }

        public DateTime EditDate { get; set; }
    }
}
