using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB_Groepje5.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string Middlename { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Adress { get; set; }
        public string Postalcode { get; set; }
        public string City { get; set; }
        public string BankNumber { get; set; }

        public string FullName
        {
            get
            {
                if (string.IsNullOrEmpty(Middlename))
                {
                    return FirstName + " " + LastName;
                }
                else
                {
                    return FirstName + " " + Middlename + " " + LastName;
                }
            }
        }
    }
}
