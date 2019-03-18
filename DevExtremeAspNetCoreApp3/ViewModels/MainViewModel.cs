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
        public IEnumerable<HolidayUser> DepartmentUserList;  // Contain complete list of usere per department
        public IEnumerable<HolidayUser> UserList;  // Conatains 
        public IEnumerable<Appointment> AppointmentList;
        public IEnumerable<State> StateList;
        public IEnumerable<Department> DepartmentList;

        public void UpdateStats()
        {

        }

    }
}
