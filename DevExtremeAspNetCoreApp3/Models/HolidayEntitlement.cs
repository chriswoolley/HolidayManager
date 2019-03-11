using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWeb.Models
{
    public class HolidayEntitlement
    {

        public HolidayEntitlement()
        {
        }
        [Key]
        public int Id { get; set; }

        public int Year { get; set; }
        public int YearsEntitlement { get; set; }
        //        public virtual HolidayUser UserId { get; set; }
        //        public virtual HolidayUser Users { get; set; }
        public HolidayUser Users { get; set; }

    }
}
