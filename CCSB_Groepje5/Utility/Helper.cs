using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB_Groepje5.Utility
{
    public static class Helper
    {
        public static readonly string Admin = "Beheerder";
        public static readonly string Customer = "Klant";
        public static readonly string Vehicle = "Voertuig";

        public static string AppointmentAdded = "Afspraak succesvol opgeslagen.";
        public static string AppointmentConfirmed = "Afspraak bevestigd.";
        public static string AppointmentUpdated = "Afspraak succesvol gewijzigd.";
        public static string AppointmentDeleted = "Afspraak succesvol verwijderd.";

        public static string AppointmentExists = "Afspraak bestaat al op gegeven datum en tijdstip.";
        public static string AppointmentNotExists = "Afspraak bestaat niet.";
        public static string AppointmentAddError = "Er ging iets mis. Afspraak niet toegevoegd.";
        public static string AppointmentConfirmError = "Er ging iets mis. Afspraak niet bevestigd.";
        public static string SomethingWentWrong = "Er ging iets mis. Probeer het opnieuw.";
        public static string AppointmentUpdatError = "Er ging iets mis. Afspraak niet gewijzigd.";

        public static int Succes_code = 1;
        public static int Failure_code = 0;

        public static List<SelectListItem> GetRolesForDropDown(bool isAdmin)
        {
            var items = new List<SelectListItem>
            {
                new SelectListItem{ Value=Helper.Admin , Text = Helper.Admin},
                new SelectListItem{ Value=Helper.Customer , Text = Helper.Customer},
            };
            return items.OrderBy(s => s.Text).ToList();
        }
        public static List<SelectListItem> GetTimeDropDown()
        {
            List<SelectListItem> duration = new List<SelectListItem>();
            for (int i = 10; i <= 90; i += 10)
            {
                duration.Add(new SelectListItem { Value = i.ToString(), Text = i + " minuten " });
            }
            return duration;
        }


    }
}
