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
                Department DevDepartment;
                Department SalesDepartment;
                context.AddRange
                (

                    DevDepartment = new Department { DepartmentName = "Development" },
                    SalesDepartment = new Department { DepartmentName = "Sales" },
                    new Department { DepartmentName = "QA" },
                    new Department { DepartmentName = "Marketing" },
                    new Department { DepartmentName = "R&D" },

                    new State { Name = "Requested" },
                    new State { Name = "Granted" },
                    new State { Name = "Denied" },
                    new State { Name = "Delayed" },

                    new EventType { Name = "Holiday" },
                    new EventType { Name = "Sick" },
                    new EventType { Name = "On-Site" },
                    new EventType { Name = "Traveling" },
                    new EventType { Name = "AWP" },

                    new SystemSetting { YearStartDate = DateTime.Parse("01/02/2019") }
                );


                context.Roles.AddRange(
                     new IdentityRole
                     {
                         Id = "b562e963-6e7e-4f41-8229-4390b1257hg6",
                         Name = "Admin",
                         NormalizedName = "ADMIN"
                     });

                context.SaveChanges();


                context.Roles.AddRange(
                     new IdentityRole
                     {
                         Id = "b4b4e963-6e7e-4f41-8229-4390b1257hg6",
                         Name = "User",
                         NormalizedName = "USER"
                     });

                context.SaveChanges();


                HolidayUser user = new HolidayUser
                {
                    Department = DevDepartment,
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


                HolidayUser user1 = new HolidayUser
                {
                    Department = DevDepartment,
                    UserName = "chris",
                    NormalizedUserName = "CHRIS",
                    Email = "1234@123.com",
                    NormalizedEmail = "123@123.com",
                    PasswordHash = "AQAAAAEAACcQAAAAEH98EQZKwd33etXkRuXHHN2IiyPb96Juffu/xZs1GteG87RqRd+YEeJvpDyIb/UXWw==",//Qwerty1@
                    LockoutEnabled = true,
                    SecurityStamp = "DYGZ56SBLC36EWFN5MGSV32O4KXKYUZC",
                    colorHighlight = "#41e4f0"
                };

                context.Users.Add(user1);
                context.SaveChanges();

                IdentityUserRole<string> ur1 = new IdentityUserRole<string>();
                ur1.RoleId = "b4b4e963-6e7e-4f41-8229-4390b1257hg6";
                ur1.UserId = user1.Id;


                context.UserRoles.Add(ur1);
                context.SaveChanges();

                //*******************************************************************
                HolidayUser Dev1 = new HolidayUser
                {
                    Department = DevDepartment,
                    UserName = "dev1",
                    NormalizedUserName = "DEV1",
                    Email = "sss@ssss.com",
                    NormalizedEmail = "SSS@SSSS.COM",
                    PasswordHash = "AQAAAAEAACcQAAAAEMomRKDIeeCGXzeKnE4tnhpIdFTKet1gX0tArLorI58EmmkIMgz1FgGcRg5agtbEBw==",//Qwerty1@
                    LockoutEnabled = true,
                    SecurityStamp = "7BIH7YGNKASJDWOQZRJHQE5PEUFKHYYL",
                    colorHighlight = "#41f072"
                };
                context.Users.Add(Dev1);
                context.SaveChanges();
                IdentityUserRole<string> Dev1ur = new IdentityUserRole<string>();
                Dev1ur.RoleId = "b4b4e963-6e7e-4f41-8229-4390b1257hg6";
                Dev1ur.UserId = Dev1.Id;
                context.UserRoles.Add(Dev1ur);
                context.SaveChanges();

                //*******************************************************************

                HolidayUser dev2 = new HolidayUser
                {
                    Department = DevDepartment,
                    UserName = "dev2",
                    NormalizedUserName = "DEV2",
                    Email = "ssssdsss@sssddss.com",
                    NormalizedEmail = "SSSSDSSS@SSSDDSS.COM",
                    PasswordHash = "AQAAAAEAACcQAAAAEDnwYkBH9Wj2gl/r1J+2US5pApOP7lbJd31ax51wwFrFO6bK8/eSnIcGMokorzWo1w==",//Qwerty1@
                    LockoutEnabled = true,
                    SecurityStamp = "KZUWAU5JZMXK5XTH22ZZ5Y7DUYRO3VKK",
                    colorHighlight = "#f05b41"
                };
                context.Users.Add(dev2);
                context.SaveChanges();
                IdentityUserRole<string> dev2ur = new IdentityUserRole<string>();
                dev2ur.RoleId = "b4b4e963-6e7e-4f41-8229-4390b1257hg6";
                dev2ur.UserId = dev2.Id;
                context.UserRoles.Add(dev2ur);
                context.SaveChanges();

                //*******************************************************************

                HolidayUser sale1 = new HolidayUser
                {
                    Department = SalesDepartment,
                    UserName = "sale1",
                    NormalizedUserName = "SALE1",
                    Email = "ssssdsss@sssddss.com",
                    NormalizedEmail = "SSSSDSSS@SSSDDSS.COM",
                    PasswordHash = "AQAAAAEAACcQAAAAEIJ645KmqwPVZXlLYMTOuDLlZs+B9/q+8juDU12jMggiiAt2fT7m8H425JBe/915xA==",//Qwerty1@
                    LockoutEnabled = true,
                    SecurityStamp = "WUFR734JM74IGFHDAS5QVDKPDGWKW35D",
                    colorHighlight = "#f0be41"
                };

                context.Users.Add(sale1);
                context.SaveChanges();

                IdentityUserRole<string> sale1ur = new IdentityUserRole<string>();
                sale1ur.RoleId = "b4b4e963-6e7e-4f41-8229-4390b1257hg6";
                sale1ur.UserId = sale1.Id;


                context.UserRoles.Add(sale1ur);
                context.SaveChanges();



                //*******************************************************************

                HolidayUser sale2 = new HolidayUser
                {
                    Department = SalesDepartment,
                    UserName = "sale2",
                    NormalizedUserName = "SALE2",
                    Email = "ssssdsss@sssddss.com",
                    NormalizedEmail = "SSSSDSSS@SSSDDSS.COM",
                    PasswordHash = "AQAAAAEAACcQAAAAEPGDvTafRidDp0iiCAwKH41JpBnDUpw/Dq0Ivh9YJvr44yUWo29AvevFXvpGpQuDgg==",//Qwerty1@
                    LockoutEnabled = true,
                    SecurityStamp = "ZYJMO4EU7N7B7FUO2VEI5JFAVIJXDDQ4",
                    colorHighlight = "#414cf0"
                };

                context.Users.Add(sale2);
                context.SaveChanges();

                IdentityUserRole<string> sale2ur = new IdentityUserRole<string>();
                sale2ur.RoleId = "b4b4e963-6e7e-4f41-8229-4390b1257hg6";
                sale2ur.UserId = sale2.Id;


                context.UserRoles.Add(sale2ur);
                context.SaveChanges();

                context.AddRange
                (
                    new HolidayEntitlement
                    {
                        Users = user,
                        Year = 19,
                        YearsEntitlement = 21
                    },

                    new HolidayEntitlement
                    {
                        Users = user1,
                        Year = 19,
                        YearsEntitlement = 31
                    },

                    new HolidayEntitlement
                    {
                        Users = Dev1,
                        Year = 19,
                        YearsEntitlement = 21
                    },

                    new HolidayEntitlement
                    {
                        Users = dev2,
                        Year = 19,
                        YearsEntitlement = 23
                    },

                    new HolidayEntitlement
                    {
                        Users = sale1,
                        Year = 19,
                        YearsEntitlement = 23
                    },

                    new HolidayEntitlement
                    {
                        Users = sale2,
                        Year = 19,
                        YearsEntitlement = 24
                    }
                );
                context.SaveChanges();

            }
            context.SaveChanges();
        }
    }
}
