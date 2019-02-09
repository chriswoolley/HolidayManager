using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolidayWeb.Models;
using HolidayWeb.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HolidayWeb.Controllers
{

    public class EventTypeController : Controller
    {

        private readonly IEventType _eventTypeRepository;

        public EventTypeController(IEventType eventTypeRepository)
        {
            _eventTypeRepository = eventTypeRepository;
        }

        [Authorize]
        public IActionResult Details()
        {
            var eventType = _eventTypeRepository.GetAllEvent().OrderBy(p => p.Name);
            return View(eventType);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(EventType eventType)
        {
            if (ModelState.IsValid)
            {
                _eventTypeRepository.AddType(eventType);
                var _eventType = _eventTypeRepository.GetAllEvent().OrderBy(p => p.Name);
                return View("Details", _eventType);
            }
            else
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            var _eventType = _eventTypeRepository.GetEventTypeById(id);
            return View(_eventType);
        }

        [HttpPost]
        public IActionResult Edit(EventType eventType)
        {
            if (ModelState.IsValid)
            {
                _eventTypeRepository.EditType(eventType);
            }
            var _eventType = _eventTypeRepository.GetAllEvent().OrderBy(p => p.Name);
            return View("Details", _eventType);
        }



        public IActionResult Delete(int id)
        {
            var _eventType = _eventTypeRepository.GetEventTypeById(id);
            return View(_eventType);
        }

        [HttpPost]
        public IActionResult Delete(EventType eventType)
        {
            _eventTypeRepository.DeleteType(eventType);
            var _eventType = _eventTypeRepository.GetAllEvent().OrderBy(p => p.Name);
            return View("Details", _eventType);

        }

    }
}