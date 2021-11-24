using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB_Groepje5.Models.ViewModels
{
    public class RegisterViewModel
    {
        //volledige naam
        [DisplayName("Voornaam")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string FirstName { get; set; }

        [DisplayName("Tussenvoegsels")]
        public string MiddleName { get; set; }

        [DisplayName("Achternaam")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string LastName { get; set; }

        //Geboortedatum
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        [DisplayName("Geboortedatum")]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        //adres, postcode, woonplaats
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        [DisplayName("Adres")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        [DisplayName("Postcode")]
        public string Postalcode { get; set; }

        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        [DisplayName("Woonplaats")]
        public string City { get; set; }

        //email adress
        [EmailAddress]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string Email { get; set; }

        //telefoonnummer
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        [DisplayName("Telefoonnummer")]
        [RegularExpression("[0][6]\\s[0-9]{8}", ErrorMessage = "Voer een geldige telefoonnummer in.")]
        public string PhoneNumber { get; set; }

        //bankrekeningnummer
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        [DisplayName("bankrekeningnummer")]
        public string BankNumber { get; set; }

        //wachtwoord
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        [DataType(DataType.Password)]
        [DisplayName("Wachtwoord")]
        [StringLength(100, ErrorMessage = "Het {0} moet minstens {2} tekens bevatten.", MinimumLength = 6)]
        public string Password { get; set; }


        [DisplayName("Bevestig wachtwoord")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Wachtwoorden komen niet overeen")]
        public string PasswordConfirm { get; set; }
        

        //rol
        [DisplayName("Rol")]
        [Required(ErrorMessage = "{0} is een verplicht veld")]
        public string RoleName { get; set; }
    }
}
