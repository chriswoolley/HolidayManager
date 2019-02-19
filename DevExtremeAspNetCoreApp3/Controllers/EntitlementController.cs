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
    public class EntitlementController : Controller
    {

        private readonly IHolidayEntitlement _holidayEntitlement;
        private readonly UserManager<HolidayUser> _userManager;

//        IHolidayEntitlement holidayEntitlement;
        public EntitlementController(IHolidayEntitlement _HolidayEntitlement, UserManager<HolidayUser> userManager)
        {
            _holidayEntitlement = _HolidayEntitlement;
            _userManager = userManager;
        }

        public IActionResult Details()
        {
            dont work ere
            var holidayentitlement = _holidayEntitlement.GetAllHolidayEntitlement().OrderBy(p => p.Id);
            return View("Details", holidayentitlement);

            //var holidayEntitlement = _holidayEntitlement.GetAllHolidayEntitlement().OrderBy(p => p.Id);
            //return View(holidayEntitlement);
        }

        public IActionResult Edit(int id)
        {
            var holidayEntitlement = _holidayEntitlement.GetHolidayEntitlementById(id);
            return View(holidayEntitlement);
        }

        [HttpPost]
        public IActionResult Edit(HolidayEntitlement holidayentitlement)
        {
            if (ModelState.IsValid)
            {
                _holidayEntitlement.EditHolidayEntitlement(holidayentitlement);
            }
            var holidayEntitlement = _holidayEntitlement.GetAllHolidayEntitlement().OrderBy(p => p.Id);
            return View("Details", holidayEntitlement);
        }


        public IActionResult Delete(int id)
        {
            var holidayEntitlement = _holidayEntitlement.GetHolidayEntitlementById(id);
            return View(holidayEntitlement);
        }

        [HttpPost]
        public IActionResult Delete(HolidayEntitlement holidayentitlement)
        {
            _holidayEntitlement.DeleteHolidayEntitlement(holidayentitlement);
            var holidayEntitlement = _holidayEntitlement.GetAllHolidayEntitlement().OrderBy(p => p.Id);
            return View("Details", holidayEntitlement);

        }

        public IActionResult Create()
        {
            var users = _userManager.Users;
            ViewBag.Users = users.Select(x => new SelectListItem { Text = x.UserName, Value = x.Id }).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(HolidayEntitlementView HolidayEntitlementView)
        {
            if (ModelState.IsValid)
            {


                HolidayEntitlement holidayEntitlement = new HolidayEntitlement();
                holidayEntitlement.Users = _userManager.Users.FirstOrDefault(p => p.Id == HolidayEntitlementView.UserId);
                holidayEntitlement.Year = HolidayEntitlementView.Year;
                holidayEntitlement.YearsEntitlement = HolidayEntitlementView.YearsEntitlement;




                _holidayEntitlement.AddHolidayEntitlement(holidayEntitlement);

                but does ere
                var bob = _holidayEntitlement.GetAllHolidayEntitlement().OrderBy(p => p.Id);
                return View("Details", bob);
            }
            else
            {
                return View();
            }
        }


    }
}