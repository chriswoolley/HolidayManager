using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolidayWeb.Core;
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
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(SignInManager<HolidayUser> signInManager, UserManager<HolidayUser> userManager,
            RoleManager<IdentityRole> roleManager, IDepartment departmentRepository, AppDbContext AppDbContext)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
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

        public IActionResult GetJSON()
        {
            return Json("This is a  test herw......");
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
            //_AppDbContext.SaveChanges();
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
        public async Task<IActionResult> EditUser(EditUserViewModel editUserViewModel)
        {
            if (ModelState.IsValid)
            {
                var _user = await _userManager.FindByIdAsync(editUserViewModel.Id);

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

                var x = await _userManager.UpdateAsync(_user);
                int affected = _AppDbContext.SaveChanges();              

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





        //Roles management
        public IActionResult RoleManagement()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        public IActionResult AddNewRole() => View();

        [HttpPost]
        public async Task<IActionResult> AddNewRole(AddRoleViewModel addRoleViewModel)
        {

            if (!ModelState.IsValid) return View(addRoleViewModel);

            var role = new IdentityRole
            {
                Name = addRoleViewModel.RoleName
            };

            IdentityResult result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("RoleManagement", _roleManager.Roles);
            }

            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(addRoleViewModel);
        }

        public async Task<IActionResult> EditRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
                return RedirectToAction("RoleManagement", _roleManager.Roles);

            var editRoleViewModel = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name,
                Users = new List<string>()
            };


            foreach (var user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                    editRoleViewModel.Users.Add(user.UserName);
            }

            return View(editRoleViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel editRoleViewModel)
        {
            var role = await _roleManager.FindByIdAsync(editRoleViewModel.Id);

            if (role != null)
            {
                role.Name = editRoleViewModel.RoleName;

                var result = await _roleManager.UpdateAsync(role);

                if (result.Succeeded)
                    return RedirectToAction("RoleManagement", _roleManager.Roles);

                ModelState.AddModelError("", "Role not updated, something went wrong.");

                return View(editRoleViewModel);
            }

            return RedirectToAction("RoleManagement", _roleManager.Roles);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                var result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("RoleManagement", _roleManager.Roles);
                ModelState.AddModelError("", "Something went wrong while deleting this role.");
            }
            else
            {
                ModelState.AddModelError("", "This role can't be found.");
            }
            return View("RoleManagement", _roleManager.Roles);
        }

        //Users in roles

        public async Task<IActionResult> AddUserToRole(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
                return RedirectToAction("RoleManagement", _roleManager.Roles);

            var addUserToRoleViewModel = new UserRoleViewModel { RoleId = role.Id };

            foreach (var user in _userManager.Users)
            {
                if (!await _userManager.IsInRoleAsync(user, role.Name))
                {
                    addUserToRoleViewModel.Users.Add(user);
                }
            }

            return View(addUserToRoleViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserToRole(UserRoleViewModel userRoleViewModel)
        {
            var user = await _userManager.FindByIdAsync(userRoleViewModel.UserId);
            var role = await _roleManager.FindByIdAsync(userRoleViewModel.RoleId);

            var result = await _userManager.AddToRoleAsync(user, role.Name);

            if (result.Succeeded)
            {
                return RedirectToAction("RoleManagement", _roleManager.Roles);
            }

            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(userRoleViewModel);
        }

        public async Task<IActionResult> DeleteUserFromRole(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
                return RedirectToAction("RoleManagement", _roleManager.Roles);

            var addUserToRoleViewModel = new UserRoleViewModel { RoleId = role.Id };

            foreach (var user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    addUserToRoleViewModel.Users.Add(user);
                }
            }

            return View(addUserToRoleViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUserFromRole(UserRoleViewModel userRoleViewModel)
        {
            var user = await _userManager.FindByIdAsync(userRoleViewModel.UserId);
            var role = await _roleManager.FindByIdAsync(userRoleViewModel.RoleId);

            var result = await _userManager.RemoveFromRoleAsync(user, role.Name);

            if (result.Succeeded)
            {
                return RedirectToAction("RoleManagement", _roleManager.Roles);
            }

            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(userRoleViewModel);
        }

        //Claims
        public async Task<IActionResult> ManageClaimsForUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return RedirectToAction("UserManagement", _userManager.Users);

            var claimsManagementViewModel = new ClaimsManagementViewModel { UserId = user.Id, AllClaimsList = ClaimTypes.ClaimsList };

            return View(claimsManagementViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ManageClaimsForUser(ClaimsManagementViewModel claimsManagementViewModel)
        {
            var user = await _userManager.FindByIdAsync(claimsManagementViewModel.UserId);

            if (user == null)
                return RedirectToAction("UserManagement", _userManager.Users);

            IdentityUserClaim<string> claim =
                new IdentityUserClaim<string> { ClaimType = claimsManagementViewModel.ClaimId, ClaimValue = claimsManagementViewModel.ClaimId };

            ///////////////////////////////////////////////user.Claims.Add(claim);
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
                return RedirectToAction("UserManagement", _userManager.Users);

            ModelState.AddModelError("", "User not updated, something went wrong.");

            return View(claimsManagementViewModel);
        }


    }
}