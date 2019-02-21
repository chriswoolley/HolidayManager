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
        private readonly AppDbContext _AppDbContext;
        private readonly IDepartment _department;
        private readonly SignInManager<HolidayUser> _signInManager;
        private readonly UserManager<HolidayUser> _userManager;

        public UserController(SignInManager<HolidayUser> signInManager, UserManager<HolidayUser> userManager, IDepartment departmentRepository, AppDbContext AppDbContext)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _department = departmentRepository;
            _AppDbContext = AppDbContext;
        }

        public IActionResult List()
        {
            var users = _userManager.Users;
            return View(users);
        }

        public IActionResult AddUser()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserViewModel addUserViewModel)
        {
            if (addUserViewModel.ReturnedDepartmentId != 0)
            {
                addUserViewModel.DepartmentId = _department.GetDepartmentById(addUserViewModel.ReturnedDepartmentId);
            }

            if (addUserViewModel.ReturnedDepartmentManagerId != 0)
            {
                addUserViewModel.DepartmentManagerId = _department.GetDepartmentById(addUserViewModel.ReturnedDepartmentManagerId);
            }
            else
            {
                addUserViewModel.DepartmentManagerId = null;
            }
            //Could be blank, so we  ignore this one
            ModelState.Remove("ReturnedDepartmentManagerId");
            if (!ModelState.IsValid) return View(addUserViewModel);

            var user = new HolidayUser()
            {
                UserName = addUserViewModel.UserName,
                Email = addUserViewModel.Email,
                Department = addUserViewModel.DepartmentId,
                DepartmentManager = addUserViewModel.DepartmentManagerId
            };

            IdentityResult result = await _userManager.CreateAsync(user, addUserViewModel.Password);
            _AppDbContext.SaveChanges();
            if (result.Succeeded)
            {
                return RedirectToAction("List", _userManager.Users);
            }
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View();
        }


        public async Task<IActionResult> EditUser(string Id)
        {

            var user = await _userManager.FindByIdAsync(Id);

            if (user == null)
                return RedirectToAction("List", _userManager.Users);

            var claims = await _userManager.GetClaimsAsync(user);
            var vm = new EditUserViewModel() { Id = user.Id, Email = user.Email, UserName = user.UserName,
                ReturnedDepartmentId = user.Department.Id, ReturnedDepartmentManagerId = user.DepartmentManager?.Id,
                UserClaims = claims.Select(c => c.Value).ToList() };

            return View(vm);
        }

        [HttpPost]
        public IActionResult EditUser(EditUserViewModel editUserViewModel)
        {
            if (ModelState.IsValid)
            {
                var _user = _userManager.Users.FirstOrDefault(p => p.Id == editUserViewModel.Id);
                _user.UserName = editUserViewModel.UserName;
                _user.Email = editUserViewModel.Email;

                if (editUserViewModel.ReturnedDepartmentId != 0)
                {
                    _user.Department = _department.GetDepartmentById(editUserViewModel.ReturnedDepartmentId);
                }

                if (editUserViewModel.ReturnedDepartmentManagerId != null)
                {
                    _user.DepartmentManager = _department.GetDepartmentById(editUserViewModel?.ReturnedDepartmentManagerId ??0);
                }
                else
                {
                    _user.DepartmentManager = null;
                }

                _userManager.UpdateAsync(_user);
                _AppDbContext.SaveChanges();              

            }
            var users = _userManager.Users;
            return View("List", users);
        }



        [HttpPost]
        public IActionResult DeleteUser(string Id)
        {

             var _user = _userManager.Users.FirstOrDefault(p => p.Id == Id);
             _userManager.DeleteAsync(_user);
             _AppDbContext.SaveChanges();

            var users = _userManager.Users;
            return View("List", users);
        }

    }
}