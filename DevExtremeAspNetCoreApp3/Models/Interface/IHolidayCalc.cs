using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWeb.Models.Interface
{
    public interface IHolidayCalc
    {

        void HolidayRemaining(IEnumerable<HolidayUser> users, DateTime whichYear);


    }
}
