using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWeb.Models
{
    public class SystemHoliday
    {

        [Key]
        public int Id { get; set; }
        //        public virtual User user { get; set; }
        public DateTime HolidayDate { get; set; }

    }
}
