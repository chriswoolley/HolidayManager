using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolidayWeb.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HolidayWeb.Controllers
{
    public class SystemSettingController : Controller
    {

        private readonly ISystemSetting _SystemSetting;

        public SystemSettingController(ISystemSetting systemSettingRepository)
        {
            _SystemSetting = systemSettingRepository;
        }

        public IActionResult Details()
        {
            var systemSettings = _SystemSetting.GetAllSystemSetting();
            return View(systemSettings);
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}


    }
}