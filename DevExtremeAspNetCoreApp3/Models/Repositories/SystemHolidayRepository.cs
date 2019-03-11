using HolidayWeb.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWeb.Models.Repositories
{
    public class SystemHolidayRepository : ISystemHoliday
    {

        private readonly AppDbContext _AppDbContext;
        public SystemHolidayRepository(AppDbContext AppDbContext)
        {
            _AppDbContext = AppDbContext;
        }

        public IEnumerable<SystemHoliday> GetAllHolidays()
        {
            return _AppDbContext.SystemHolidays.OrderBy(p =>p.Id);
        }


        public Event GetSystemHolidayById(int HolidayId)
        {
            return _AppDbContext.Event.FirstOrDefault(p => p.Id == HolidayId);
        }

        public void EditSystemHoliday(SystemHoliday SystemHoliday)
        {
            _AppDbContext.SystemHolidays.Update(SystemHoliday);
            _AppDbContext.SaveChanges();
        }

        public void DeleteSystemHoliday(SystemHoliday SystemHoliday)
        {
            _AppDbContext.SystemHolidays.Remove(SystemHoliday);
            _AppDbContext.SaveChanges();
        }

        public void AddSystemHoliday(SystemHoliday SystemHoliday)
        {
            _AppDbContext.SystemHolidays.Add(SystemHoliday);
            _AppDbContext.SaveChanges();
        }


    }
}
