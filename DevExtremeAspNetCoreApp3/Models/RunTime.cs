using HolidayWeb.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWeb.Models
{
    public class RunTime : IRuntime
    {
        public int CurrentDepartmentId { get; set; }
    }
}
