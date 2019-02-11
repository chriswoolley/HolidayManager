using HolidayWeb.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWeb.ViewModels
{
    public class HolidayEntitlementCreateView
    {
        [Key]
        public int id;
        public HolidayEntitlement HolidayEntitlement;
        public IEnumerable<IdentityUser> Users;

    }
}
