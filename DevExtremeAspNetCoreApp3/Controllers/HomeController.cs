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
using Newtonsoft.Json;

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
        private readonly IAppointment _appointmentRepository;
        private readonly MainViewModel _MainViewModel;

//        public HomeController(IEvent events, UserManager<IdentityUser> userManager, IHolidayEntitlement _HolidayEntitlement)
        public HomeController(IDepartment department, UserManager<HolidayUser> userManager, IHolidayEntitlement _HolidayEntitlement, IState state, 
            IRuntime _Runtime, IAppointment AppointmentRepository, IHolidayCalc holidayCalc)
        {
//            _events = events;
            _userManager = userManager;
            _holidayEntitlement = _HolidayEntitlement;
            _DepartmentList = department;
            _StateList = state;
            _runtime = _Runtime;
            if (_runtime.CurrentDepartmentId == 0)
                _runtime.CurrentDepartmentId = 1;
            _appointmentRepository = AppointmentRepository;
            _MainViewModel = new MainViewModel();
            _MainViewModel.DepartmentList = _DepartmentList.GetAllDepartment();
            _MainViewModel.StateList = _StateList.GetAllState();
            _MainViewModel.UserList = _userManager.Users.ToList();
            _MainViewModel.AppointmentList = _appointmentRepository.GetAllAppointment();

            holidayCalc.HolidayRemaining(_MainViewModel.UserList, System.DateTime.Now);

        }

        public ActionResult WebAPIService()
        {
            return View();
        }

                
        public IActionResult Index(int DepartmentId)
        {
            if (DepartmentId != 0)
                _runtime.CurrentDepartmentId = DepartmentId;

            var users = _userManager.Users;
            ViewBag.Users = users.Select(x => new SelectListItem { Text = x.UserName, Value = x.Id }).ToList();

            if (_runtime.CurrentDepartmentId != 0)
                _MainViewModel.UserList = _userManager.Users.Where(p => p.Department.Id == _runtime.CurrentDepartmentId);
            return View("Index", _MainViewModel);
        }

//        public IActionResult Test(int DepartmentId)
        //public IActionResult Test(int DepartmentId)
        //{
        //    _runtime.CurrentDepartmentId = DepartmentId;

        //    var users = _userManager.Users;
        //    ViewBag.Users = users.Select(x => new SelectListItem { Text = x.UserName, Value = x.Id }).ToList();

        //    if (_runtime.CurrentDepartmentId != 0)
        //        _MainViewModel.UserList = _userManager.Users.Where(p => p.Department.Id == _runtime.CurrentDepartmentId);

        //    return View("Index", _MainViewModel);
        //}

    }
}
