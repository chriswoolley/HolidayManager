using HolidayWeb.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWeb.ViewModels
{
    public class MainEventView
    {

        public HolidayWeb.Models.Event Events;
        public HolidayWeb.Models.Interface.IHolidayEntitlement Entitlement;
        public IEnumerable<HolidayUser> UserList;


    }
}
