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
    public class AdminController : Controller
    {
        private readonly IDepartment _department;
        private readonly SignInManager<HolidayUser> _signInManager;
        private readonly UserManager<HolidayUser> _userManager;

        public AdminController(SignInManager<HolidayUser> signInManager, UserManager<HolidayUser> userManager, IDepartment departmentRepository)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _department = departmentRepository;
        }

        public IActionResult Index()
        {
            return View(_userManager);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return View(loginViewModel);
            var user = await _userManager.FindByNameAsync(loginViewModel.UserName);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "User name/password not found");
            return View(loginViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}