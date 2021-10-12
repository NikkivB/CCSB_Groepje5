using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CCSB_Groepje5.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {

        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
