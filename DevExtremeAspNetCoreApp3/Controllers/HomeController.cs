using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolidayWeb.Models;
using HolidayWeb.Models.Interface;
using HolidayWeb.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HolidayWeb.Controllers
{
    public class HomeController : Controller
    {

        private readonly IEvent _events;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHolidayEntitlement _holidayEntitlement;

        public RunTime runTime = new RunTime();


        public HomeController(IEvent events, UserManager<IdentityUser> userManager, IHolidayEntitlement _HolidayEntitlement)
        {
            _events = events;
            _userManager = userManager;
            _holidayEntitlement = _HolidayEntitlement;
        }


        public ActionResult WebAPIService()
        {
            return View();
        }



        public IActionResult Index()
        {
//            var Events = _events.GetAllEvent().OrderBy(p => p.StartTime);
            var users = _userManager.Users;
            ViewBag.Users = users.Select(x => new SelectListItem { Text = x.UserName, Value = x.Id }).ToList();

//            if (runTime.CurrentDepartmentId != 0)
            return View(users);
        }


        public IActionResult Test(int DepartmentId)
        {
            runTime.CurrentDepartmentId = DepartmentId;
            return View("Index");
        }


    }
}
