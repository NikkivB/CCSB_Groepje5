using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB_Groepje5.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string Middlename { get; set; }
        public string LastName { get; set; }
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
