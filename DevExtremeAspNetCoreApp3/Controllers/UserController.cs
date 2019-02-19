using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolidayWeb.Models;
using HolidayWeb.Models.Interface;
using HolidayWeb.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HolidayWeb.Controllers
{
    public class UserController : Controller
    {

        private readonly IDepartment _department;
        private readonly SignInManager<HolidayUser> _signInManager;
        private readonly UserManager<HolidayUser> _userManager;

        public UserController(SignInManager<HolidayUser> signInManager, UserManager<HolidayUser> userManager, IDepartment departmentRepository)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _department = departmentRepository;
        }

        public IActionResult List()
        {
            var users = _userManager.Users;

            return View(users);
        }

        public IActionResult AddUser()
        {
            ViewBag.Departments = _department.GetAllDepartment();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserViewModel addUserViewModel)
        {
            if (addUserViewModel.xDepartmentId != 0)
            {
                addUserViewModel.DepartmentId = _department.GetDepartmentById(addUserViewModel.xDepartmentId);
            } 

            if (!ModelState.IsValid) return View(addUserViewModel);

            var user = new HolidayUser()
            {
                UserName = addUserViewModel.UserName,
                Email = addUserViewModel.Email,
               
            };

            IdentityResult result = await _userManager.CreateAsync(user, addUserViewModel.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("List", _userManager.Users);
            }

            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
//            return View(addUserViewModel);
            return View();
        }

        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return RedirectToAction("List", _userManager.Users);

            var claims = await _userManager.GetClaimsAsync(user);
            var vm = new EditUserViewModel() { Id = user.Id, Email = user.Email, UserName = user.UserName, UserClaims = claims.Select(c => c.Value).ToList() };

            return View(vm);
        }


    }
}