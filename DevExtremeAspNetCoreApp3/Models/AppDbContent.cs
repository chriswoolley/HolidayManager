using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWeb.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Models.Department> Departments { get; set; }
        //public DbSet<Models.DepartmentManager> DepartmentManagers { get; set; }
        public DbSet<Models.Event> Event { get; set; }
        //public DbSet<Models.EventChangeLog> EventChangeLogs { get; set; }
        public DbSet<Models.HolidayEntitlement> HolidayEntitlements { get; set; }
        public DbSet<Models.State> States { get; set; }
        public DbSet<Models.EventType> EventTypes { get; set; }
        public DbSet<Models.Appointment> Appointment { get; set; }
       


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public override int SaveChanges()
        {
            // 

            return base.SaveChanges();
        }


    }
}
