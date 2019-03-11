using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWeb.Models.Interface
{
    public interface ISystemHoliday
    {

        IEnumerable<SystemHoliday> GetAllHolidays();

        Event GetSystemHolidayById(int HolidayId);

        void EditSystemHoliday(SystemHoliday SystemHoliday);

        void DeleteSystemHoliday(SystemHoliday SystemHoliday);


        void AddSystemHoliday(SystemHoliday SystemHoliday);
            



    }
}
