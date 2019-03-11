using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolidayWeb.Models;
using HolidayWeb.Models.Interface;
using HolidayWeb.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HolidayWeb.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartment _department;

        public DepartmentController(IDepartment departmentRepository)
        {
            _department = departmentRepository;
        }

        [Authorize]
        public IActionResult Details()
        {
            var department = _department.GetAllDepartment().OrderBy(p => p.DepartmentName);
            return View(department);
        }


        public IActionResult Edit(int id)
        {
            var department = _department.GetDepartmentById(id);
            return View(department);
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                _department.EditDepartment(department);
            }
            var Department = _department.GetAllDepartment().OrderBy(p => p.DepartmentName);
            return View("Details", Department);
        }


        public IActionResult Delete(int id)
        {
            var department = _department.GetDepartmentById(id);
            return View(department);
        }

        [HttpPost]
        public IActionResult Delete(Department department)
        {
            _department.DeleteDepartment(department);
            var Department = _department.GetAllDepartment().OrderBy(p => p.DepartmentName);
            return View("Details", Department);

        }



        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _department.AddDepartment(department);
                var Department = _department.GetAllDepartment().OrderBy(p => p.DepartmentName);
                return View("Details", Department);
            }
            else
            {
                return View();
            }
        }

    }
}