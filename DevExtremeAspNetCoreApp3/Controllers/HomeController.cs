using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolidayWeb.Models;
using HolidayWeb.Models.Interface;
using HolidayWeb.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HolidayWeb.Controllers
{
    public class HomeController : Controller
    {

        private readonly IEvent _events;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHolidayEntitlement _holidayEntitlement;

        public HomeController(IEvent events, UserManager<IdentityUser> userManager, IHolidayEntitlement _HolidayEntitlement)
        {
            _events = events;
            _userManager = userManager;
            _holidayEntitlement = _HolidayEntitlement;
        }

        public IActionResult Index()
        {
            var Events = _events.GetAllEvent().OrderBy(p => p.StartTime);


//            var Test = new MainEventView();
//            Test.UserList = _userManager.Users;
//            Test.Entitlement = _holidayEntitlement.GetAllHolidayEntitlement();
//            Test.Events = _events;

            return View(Events);
        }

    }
}
