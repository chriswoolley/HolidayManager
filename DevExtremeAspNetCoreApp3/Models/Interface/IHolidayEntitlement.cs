using HolidayWeb.ViewModels;
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
        float GetUserHolidayEntitlement(string userId, int year);


        void EditHolidayEntitlement(HolidayEntitlement holidayEntitlement);
        void DeleteHolidayEntitlement(HolidayEntitlement holidayEntitlement);
        void AddHolidayEntitlement(HolidayEntitlement holidayEntitlement);




//        void AddHolidayEntitlement(HolidayEntitlementView holidayEntitlementView);

    }
}
