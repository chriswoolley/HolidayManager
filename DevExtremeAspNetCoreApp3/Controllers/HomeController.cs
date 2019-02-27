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

//        private readonly IEvent _events;
        private readonly UserManager<HolidayUser> _userManager;
        private readonly IHolidayEntitlement _holidayEntitlement;
        private readonly IDepartment _DepartmentList;
        private readonly IState _StateList;
        private readonly IRuntime _runtime;

        private readonly MainViewModel _MainViewModel;




//        public HomeController(IEvent events, UserManager<IdentityUser> userManager, IHolidayEntitlement _HolidayEntitlement)
        public HomeController(IDepartment department, UserManager<HolidayUser> userManager, IHolidayEntitlement _HolidayEntitlement, IState state, IRuntime _Runtime)
        {
//            _events = events;
            _userManager = userManager;
            _holidayEntitlement = _HolidayEntitlement;
            _DepartmentList = department;
            _StateList = state;
            _runtime = _Runtime;

            _MainViewModel = new MainViewModel();

            _MainViewModel.DepartmentList = _DepartmentList.GetAllDepartment();
            _MainViewModel.StateList = _StateList.GetAllState();
            _MainViewModel.UserList = _userManager.Users.ToList();



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
//            return View(users);
            return View(_MainViewModel);
           

        }


//        public IActionResult Test(int DepartmentId)
        public IActionResult Test(int DepartmentId)
        {
            _runtime.CurrentDepartmentId = DepartmentId;

            var users = _userManager.Users;
            ViewBag.Users = users.Select(x => new SelectListItem { Text = x.UserName, Value = x.Id }).ToList();

            return View("Index", _MainViewModel);
        }


    }
}
