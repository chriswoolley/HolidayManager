using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWeb.Models
{
    public class HolidayUser : IdentityUser
    {


        public virtual Department Department { get; set; }

        public virtual Department DepartmentManager { get; set; }

        public virtual string colorHighlight { get; set; }

        [NotMapped]
        public float HolidaysRemaining { get; set; }

        [NotMapped]
        public float HolidaysAssigned { get; set; }

    }
}
