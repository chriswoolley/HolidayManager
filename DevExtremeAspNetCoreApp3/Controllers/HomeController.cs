using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolidayWeb.Models;
using HolidayWeb.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HolidayWeb.Controllers
{
    public class HomeController : Controller
    {

        private readonly IEvent _events;

        public HomeController(IEvent events)
        {
            _events = events;
        }

        public IActionResult Index()
        {
            var Events = _events.GetAllEvent().OrderBy(p => p.StartTime);
            return View(Events);
        }

    }
}
