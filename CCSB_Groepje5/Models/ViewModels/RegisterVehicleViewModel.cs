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
        public int Id { get; set; }

        [DisplayName("Klant")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string CustomerId { get; set; }

        //Here I give a regularexpression to licenseplate
        [DisplayName("Kentekenplaat")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        //a search pattern used for matching one or more characters within a string. (search path)
        [RegularExpression("(([B-DF-HJ-NP-TV-Z]{3}[0-9]{3})|(\\w{2}-\\w{2}-\\w{2})|([0-9]{2}-[B-DF-HJ-NP-TV-Z]{3}-[0-9]{1})|([0-9]{1}-[B-DF-HJ-NP-TV-Z]{3}-[0-9]{2})|([B-DF-HJ-NP-TV-Z]{1}-[0-9]{3}-[B-DF-HJ-NP-TV-Z]{2}))", ErrorMessage = "Voer een geldig kenteken in.")]
        public string LicensePlate { get; set; }

        [DisplayName("Soort voertuig")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string VehicleType { get; set; }

        [DisplayName("Lengte voertuig (in m)")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public int SurfaceTaken { get; set; }
    }
}
