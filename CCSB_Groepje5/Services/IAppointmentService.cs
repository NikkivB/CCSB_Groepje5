﻿using CCSB_Groepje5.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB_Groepje5.Services
{
    public interface IAppointmentService
    {
        public List<AdministratorViewModel> GetAdministratorList();
        public List<KlantViewModel> GetKlantList();
        public Task<int> AddUpdate(AppointmentViewModel model);
    }
}
