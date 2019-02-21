using Microsoft.AspNetCore.Identity;
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


                context.Roles.AddRange(
                     new IdentityRole
                     {
                         Id = "b562e963-6e7e-4f41-8229-4390b1257hg6",                     
                         Name = "Admin",
                         NormalizedName = "ADMIN"
                     });

                context.SaveChanges();


                HolidayUser user = new HolidayUser
                { 
                    
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "123@123.com",
                    NormalizedEmail = "123@123.com",
                    PasswordHash = "AQAAAAEAACcQAAAAEGYx0ceZPyILR6qk5zAijkxxLsJgMY00dYy+t74mNNjstHp0p5lwXetxHGBZOAGJ1Q==",//Qwerty1@
                    LockoutEnabled = true,
                    SecurityStamp = "96a58895-0ca2-4145-b6bb-b4b5411361a2"
                };

                context.Users.Add(user);
                context.SaveChanges();


                IdentityUserRole<string> ur = new IdentityUserRole<string>();
                ur.RoleId = "b562e963-6e7e-4f41-8229-4390b1257hg6";
                ur.UserId = user.Id;

                context.UserRoles.Add(ur);
                context.SaveChanges();
            }
            context.SaveChanges();
        }
    }
}
