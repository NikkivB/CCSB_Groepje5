using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB_Groepje5.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        [EmailAddress(ErrorMessage ="Dit is geen geldig email adres")]
        [Display(Name ="E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        [DataType(DataType.Password)]
        [Display(Name = "Wachtwoord")]
        public string Password { get; set; }

        [Display(Name = "Onthoud mij")]
        public string RememberMe { get; set; }
    }
}
