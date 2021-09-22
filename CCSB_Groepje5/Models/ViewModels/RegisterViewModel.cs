﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB_Groepje5.Models.ViewModels
{
    public class RegisterViewModel
    {
        [DisplayName("Voornaam")]
        [Required(ErrorMessage = " {0} is een verplicht veld.")]
        public string FirstName { get; set; }

        [DisplayName("Tussenvoegsels")]
        public string MiddleName { get; set; }

        [DisplayName("Achternaam")]
        [Required(ErrorMessage = " {0} is een verplicht veld.")]
        public string LastName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = " {0} is een verplicht veld.")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Wachtwoord")]
        [Required(ErrorMessage = " {0} is een verplicht veld.")]
        [StringLength(100,ErrorMessage = "Het {0} moet minstens {2} tekens bevatten.", MinimumLength =6)]
        public string Password { get; set; }

        [DisplayName("Bevestig wachtwoord")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Wachtwoorden komen niet overeen.")]
        public string PasswordConfirm { get; set; }

        [DisplayName("Rol")]
        [Required(ErrorMessage = " {0} is een verplicht veld.")]
        public string RoleName { get; set; }
    }
}
