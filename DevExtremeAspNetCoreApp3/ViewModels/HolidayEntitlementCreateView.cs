using HolidayWeb.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWeb.ViewModels
{
    public class HolidayEntitlementCreateView
    {

        public HolidayEntitlementCreateView()
        {
            year = DateTime.Now.Year;
            HolidayEntitlement = 21;
        }


        [Range(2015, 2035)]
        public int year;

//        [Key]
//        public int id;
//        [DefaultValue(2019)]
//        [Range(2015, 2035)]
//        public int CurrentYear;
          public int HolidayEntitlement;
////        public IEnumerable<IdentityUser> Users;
//        public List<int> YearOptions;

//        public HolidayEntitlementCreateView()
//        {
//            YearOptions = new List<int>();
//            for (int i = 2018; i < 2034; i++)
//            {
//                YearOptions.Add(i);
//            }

//        }



    }
}
