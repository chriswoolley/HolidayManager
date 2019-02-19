using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWeb.Models
{
    public class Event
    {

        public Event()
        {
        }

        ~Event()
        {
        }

        [Key]
        public int Id { get; set; }
//        public virtual User user { get; set; }
        public DateTime StartTime { get; set; }
        //public DateTime EndTime { get; set; }
        public virtual EventType EventType { get; set; }
        public virtual State State { get; set; }
        public string Subject { set; get; }
        public virtual HolidayUser User { set; get; }

    }
}
