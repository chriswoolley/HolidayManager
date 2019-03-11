using System.Collections.Generic;
using HolidayWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HolidayWeb.ViewModels
{
    public class UserRoleViewModel
    {
        public UserRoleViewModel()
        {
            Users = new List<HolidayUser>();
        }
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public List<HolidayUser> Users { get; set; }

    }
}