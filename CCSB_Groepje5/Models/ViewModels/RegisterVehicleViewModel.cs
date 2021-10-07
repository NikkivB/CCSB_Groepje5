using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB_Groepje5.Models.ViewModels
{
    public class RegisterVehicleViewModel
    {
        [DisplayName("Klant")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string Customer { get; set; }

        [DisplayName("Kentekenplaat")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string LicensePlate { get; set; }

        [DisplayName("Soort voertuig")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string VehicleType { get; set; }
    }
}
