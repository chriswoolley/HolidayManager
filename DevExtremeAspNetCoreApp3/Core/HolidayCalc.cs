using HolidayWeb.Models;
using HolidayWeb.Models.Interface;
using Microsoft.AspNetCore.Identity;
using Nager.Date;
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
        private readonly IAppointment _appointmentRepository;


        public HolidayCalc(ISystemHoliday systemHolidays, UserManager<HolidayUser> userManager, IHolidayEntitlement _HolidayEntitlement, ISystemSetting systemSetting
            , IAppointment AppointmentRepository)
        //        public HolidayCalc(ISystemHoliday systemHolidays, UserManager<HolidayUser> userManager, IHolidayEntitlement _HolidayEntitlement)
        //        public HolidayCalc()
        {
            this.systemHolidays = systemHolidays;
            _holidayEntitlement = _HolidayEntitlement;
            this.systemSetting = systemSetting;
            _appointmentRepository = AppointmentRepository;
        }

        private void GetHolidayStartPeriod(int year, out DateTime start, out DateTime endDate)
        {
            DateTime systemDate = systemSetting.GetSystemSettingById(1).YearStartDate;
            start = new DateTime(2000 + year, systemDate.Month, systemDate.Day, 0, 1, 0);
            endDate = start.AddYears(1).AddDays(-1);
        }


        private bool NonWorkinyDay(DateTime Checkdate)
        {
            //need to add in  public hoiday and manually added dates
            return ((Checkdate.DayOfWeek == DayOfWeek.Saturday) || (Checkdate.DayOfWeek == DayOfWeek.Sunday)
                ||(DateSystem.IsPublicHoliday(Checkdate, CountryCode.DE))) ;
        }


        private int RawHolidaysRequired(DateTime Startdate, Period StartPeriod, DateTime Enddate, Period EndPeriod)
        {
            int TotalPeriods = (StartPeriod < EndPeriod) ? 2 : 1;
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

        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }


        private int NonWorkingPeriod(DateTime Startdate, Period StartPeriod, DateTime Enddate, Period EndPeriod)
        {
            int NonePeriods = 0;
            if (Enddate.Date > Startdate.Date)
            {
                foreach (DateTime day in EachDay(Startdate, Enddate))
                {
                    if (NonWorkinyDay(day))
                    {
                        // two edge case's
                        if (((Convert.ToDateTime(day) == Startdate.Date) && (StartPeriod == Period.Afternoon)) || ((Convert.ToDateTime(day) == Enddate.Date) && (EndPeriod == Period.Morning)))
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
                // they are samer day so could use either
                if (NonWorkinyDay(Startdate))
                {
                    if (StartPeriod < EndPeriod)
                    { NonePeriods = 2; }
                    else
                    { NonePeriods = 1; }
                }
            }

            
            return NonePeriods;
        }



        private float HolidaysBookthisYear(string UserID, int year)
        {
            DateTime startdate;
            DateTime endDate;
            GetHolidayStartPeriod(year, out startdate, out endDate);
            IEnumerable<Appointment> BookedHolidays;
            BookedHolidays = _appointmentRepository.GetAllAppointmentPerUserYear(UserID, startdate, endDate);
            int HolidayCount = 0;
            foreach (Appointment holiday in BookedHolidays)
            {
                HolidayCount = HolidayCount + RawHolidaysRequired(holiday.StartDate, holiday.StartPeriod, holiday.EndDate, holiday.EndPeriod);
                HolidayCount = HolidayCount - NonWorkingPeriod(holiday.StartDate, holiday.StartPeriod, holiday.EndDate, holiday.EndPeriod);
            }
            return (float)HolidayCount/2;
        }



        public void HolidayRemaining(IEnumerable<HolidayUser> users, DateTime whichYear)
        {
            Random random = new Random();

            foreach (HolidayUser test in users)
            {
                test.HolidaysAssigned = _holidayEntitlement.GetUserHolidayEntitlement(test.Id, 19);

                test.HolidaysRemaining = test.HolidaysAssigned - HolidaysBookthisYear(test.Id, 19);
            }

        }


    }
}
