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

            var holidayentitlement = _holidayEntitlement.GetAllHolidayEntitlement().OrderBy(p => p.Id);
            return View("Details", holidayentitlement);

            //var holidayEntitlement = _holidayEntitlement.GetAllHolidayEntitlement().OrderBy(p => p.Id);
            //return View(holidayEntitlement);
        }

        public IActionResult Edit(int id)
        {
            var holidayEntitlement = _holidayEntitlement.GetHolidayEntitlementById(id);
            var users = _userManager.Users;
            ViewBag.Users = users.Select(x => new SelectListItem { Text = x.UserName, Value = x.Id }).ToList();
            HolidayEntitlementView holidayEntitlementView = new HolidayEntitlementView();
            holidayEntitlementView.Year = holidayEntitlement.Year;
            holidayEntitlementView.YearsEntitlement = holidayEntitlement.YearsEntitlement;
            holidayEntitlementView.UserId = holidayEntitlement.Users.Id;
            holidayEntitlementView.Id = holidayEntitlement.Id;

            return View(holidayEntitlementView);
        }

        [HttpPost]
        public IActionResult Edit(HolidayEntitlementView HolidayEntitlementView)
        {
            if (ModelState.IsValid)
            {
                HolidayEntitlement PostedholidayEntitlement = new HolidayEntitlement();
                PostedholidayEntitlement.Users = _userManager.Users.FirstOrDefault(p => p.Id == HolidayEntitlementView.UserId);
                PostedholidayEntitlement.Year = HolidayEntitlementView.Year;
                PostedholidayEntitlement.YearsEntitlement = HolidayEntitlementView.YearsEntitlement;
                PostedholidayEntitlement.Id = HolidayEntitlementView.Id;

                _holidayEntitlement.EditHolidayEntitlement(PostedholidayEntitlement);
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