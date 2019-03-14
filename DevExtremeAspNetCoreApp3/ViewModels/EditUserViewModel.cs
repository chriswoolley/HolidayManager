using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HolidayWeb.ViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Please enter the user name")]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter the user email")]
        public string Email { get; set; }

        [Display(Name = "Color")]
        public string colorHighlight { get; set; }

        public List<string> UserClaims { get; set; }

        public int ReturnedDepartmentId { get; set; }
        
        public int? ReturnedDepartmentManagerId { get; set; }
    }
}