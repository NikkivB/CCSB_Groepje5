using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB_Groepje5.Models.ViewModels
{
    public class BlockDaysViewModel
    {
        [DisplayName("begin datum")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public DateTime StartBd { get; set; }

        [DisplayName("eind datum")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public DateTime EndBd { get; set; }
    }
}
