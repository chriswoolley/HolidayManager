using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWeb.Models
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Departments.Any())
            {
                context.AddRange
                (
                    new Department { DepartmentName = "Development"},
                    new Department { DepartmentName = "Sales" },
                    new Department { DepartmentName = "QA" },
                    new Department { DepartmentName = "Marketing" },
                    new Department { DepartmentName = "R&D" },

                    new State { Name = "Requested"},
                    new State { Name = "Granted" },
                    new State { Name = "Denied" },
                    new State { Name = "Delayed" },

                    new EventType { Name = "Holiday" },
                    new EventType { Name = "Sick" },
                    new EventType { Name = "On-Site" },
                    new EventType { Name = "Traveling" },
                    new EventType { Name = "AWP" }








                    
                );
            }
            context.SaveChanges();
        }
    }
}
