using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolidayWeb.Models;
using HolidayWeb.Models.Interface;
using Microsoft.AspNetCore.Mvc;



namespace HolidayWeb.Controllers
{
    public class StateController : Controller
    {
        private readonly IState _stateRepository;

        public StateController(IState stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public IActionResult Details()
        {
            var States = _stateRepository.GetAllState().OrderBy(p => p.Name);
            return View(States);
        }


        public IActionResult Delete(int id)
        {
            var state = _stateRepository.GetStateById(id);
            return View(state);
        }

        [HttpPost]
        public IActionResult Delete(State state)
        {
            _stateRepository.DeleteState(_stateRepository.GetStateById(state.Id));
            var States = _stateRepository.GetAllState().OrderBy(p => p.Name);
            return View("Details", States);

        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(State state)
        {
            if (ModelState.IsValid)
            {
                _stateRepository.AddState(state);
                var States = _stateRepository.GetAllState().OrderBy(p => p.Name);
                return View("Details", States);
            }
            else
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            var state = _stateRepository.GetStateById(id);
            return View(state);
        }

        [HttpPost]
        public IActionResult Edit(State state)
        {
            if (ModelState.IsValid)
            {
                _stateRepository.EditState(state);
            }
            var States = _stateRepository.GetAllState().OrderBy(p => p.Name);
            return View("Details", States);
        }



    }
}