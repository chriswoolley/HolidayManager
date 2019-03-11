using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWeb.Models
{
    public class State
    {

        public State()
        {
        }

        ~State()
        {
        }

        [Key]
        public int Id { get; set; }
        [StringLength(120)]
        [Required]
        public string Name { get; set; }
    }
}
