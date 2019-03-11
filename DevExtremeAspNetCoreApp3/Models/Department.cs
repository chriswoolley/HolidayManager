using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWeb.Models
{
    public class Department
    {
        public Department()
        {
        }

        ~Department()
        {
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(120)]
        public string DepartmentName { get; set; }

        //public virtual ICollection<DepartmentManager> DepartmentManagers { get; set; }
    }
}
