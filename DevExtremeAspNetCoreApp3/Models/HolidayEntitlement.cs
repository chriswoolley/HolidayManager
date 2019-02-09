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

        ~HolidayEntitlement()
        {
        }

        [Key]
        public int Id { get; set; }
//        public virtual User user { get; set; }
        public int Year { get; set; }
        [Required]
        public int YearsEntitlement { get; set; }
    }
}
