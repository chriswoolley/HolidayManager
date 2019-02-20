using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWeb.ViewModels
{
    public class HolidayEntitlementView
    {


        public HolidayEntitlementView()
        {
        }

        ~ HolidayEntitlementView()
        {
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        //        public virtual IdentityUser User { get; set; }
        public int Year { get; set; }
        public int YearsEntitlement { get; set; }
    }

}

