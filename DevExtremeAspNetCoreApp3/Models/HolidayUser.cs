using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWeb.Models
{
    public class HolidayUser : IdentityUser
    {
        public Color coulor;
        public virtual Department Department { get; set; }
        public virtual Department DepartmentManager { get; set; }

    }
}
