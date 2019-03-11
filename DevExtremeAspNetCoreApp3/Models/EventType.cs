using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWeb.Models
{
    public class EventType
    {
        public EventType()
        {
        }

        ~EventType()
        {
        }

        [Key]
        public int Id { get; set; }
        [StringLength(120)]
        [Required]
        public string Name { get; set; }

    }
}
