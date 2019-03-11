using HolidayWeb.Models;
using HolidayWeb.Models.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWeb.Core
{

    public enum Period
    {
        Morning,
        Afternoon
    }

    public class HolidayCalc : IHolidayCalc
    {

        private readonly ISystemHoliday systemHolidays;
        private readonly IHolidayEntitlement _holidayEntitlement;
        private readonly ISystemSetting systemSetting;


//        public HolidayCalc(ISystemHoliday systemHolidays, UserManager<HolidayUser> userManager, IHolidayEntitlement _HolidayEntitlement, ISystemSetting systemSetting)
        public HolidayCalc(ISystemHoliday systemHolidays, UserManager<HolidayUser> userManager, IHolidayEntitlement _HolidayEntitlement)
        //        public HolidayCalc()
        {
            this.systemHolidays = systemHolidays;
            _holidayEntitlement = _HolidayEntitlement;
//            this.systemSetting = systemSetting;
        }

        private void GetHolidayStartPeriod(int year, out DateTime start, out DateTime endDate)
        {
            DateTime systemDate = systemSetting.GetSystemSettingById(1).YearStartDate;
             start = new DateTime(year, systemDate.Month, systemDate.Day, 0, 1, 0);
             endDate = start.AddYears(1).AddDays(-1);
        }


        private bool NonWorkinyDay(DateTime Checkdate)
        {
            return true;
        }


        private int RawHolidaysRequired(DateTime Startdate, Period StartPeriod, DateTime Enddate, Period EndPeriod)
        {
            int TotalPeriods = (int)StartPeriod + 1;
            if (Enddate.Date > Startdate.Date)
            {
                TimeSpan Days;
                Days = (Enddate.Date - Startdate.Date);
                TotalPeriods = TotalPeriods + (((int)Days.TotalDays) * 2);

                if (EndPeriod == Period.Morning)
                {
                    TotalPeriods = TotalPeriods - 1;
                }
            }
            return TotalPeriods;
        }

        private int NonWorkingPeriod(DateTime Startdate, Period StartPeriod, DateTime Enddate, Period EndPeriod)
        {
            int NonePeriods = 0;
            if (Enddate.Date > Startdate.Date)
            {
                var Enumerabledays = Enumerable.Range(Convert.ToInt32(Startdate.Date), Convert.ToInt32(Enddate.Date));
                foreach (int day in Enumerabledays)
                {
                    if (NonWorkinyDay(Convert.ToDateTime(day)))
                    {
                        // two edge case's
                        if (((Convert.ToDateTime(day) == Startdate.Date) && (StartPeriod == Period.Afternoon)) || ((Convert.ToDateTime(day) == Enddate.Date) && (StartPeriod == Period.Morning)))
                        {
                            NonePeriods = NonePeriods + 1;
                        }
                        else
                        {
                            NonePeriods = NonePeriods + 2;
                        }
                    }
                }
            }
            else//only got the one day to check
            {
                if (StartPeriod < EndPeriod)
                { return 2; }
                else
                { return 1; }

            }

            return NonePeriods;
        }


        private int HolidayRequired(DateTime Startdate, Period StartPeriod, DateTime Enddate, Period EndPeriod)
        {
            return RawHolidaysRequired(Startdate, StartPeriod, Enddate, EndPeriod) - NonWorkingPeriod(Startdate, StartPeriod, Enddate, EndPeriod);

        }



        private float HolidaysBookthisYear(int year)
        {
            DateTime startdate;
            DateTime endDate;
            GetHolidayStartPeriod(year, out startdate, out endDate);
//////////////////////////////////////////////////////////////////////////            goto dates loop appointments and calc

            return 0;
        }



        public void HolidayRemaining(IEnumerable<HolidayUser> users, DateTime whichYear)
            { 
            Random random = new Random();

            foreach (HolidayUser test in users)
            {
                test.HolidaysAssigned = _holidayEntitlement.GetUserHolidayEntitlement(test.Id, 19);

            //    test.HolidaysRemaining = test.HolidaysAssigned - HolidaysBookthisYear(19);

            //    int randomNumber = random.Next(0, 25);
            //    test.HolidaysRemaining = randomNumber;
            }

            }


    }
}
