using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWeb.Models.Interface
{
    public interface IHolidayEntitlement
    {
        IEnumerable<HolidayEntitlement> GetAllHolidayEntitlement();

        HolidayEntitlement GetHolidayEntitlementById(int HolidayEntitlementId);
    }
}
