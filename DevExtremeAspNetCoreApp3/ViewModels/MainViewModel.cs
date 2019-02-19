using HolidayWeb.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWeb.ViewModels
{
    public class MainViewModel
    {
        public IEnumerable<HolidayUser> UserList;
        public IEnumerable<Appointment> AppointmentList;
        public IEnumerable<State> StateList;
        public IEnumerable<Department> DepartmentList;
    }
}
