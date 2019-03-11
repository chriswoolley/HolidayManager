using HolidayWeb.Models.Interface;
using HolidayWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace HolidayWeb.Models.Repositories
{
    public class HolidayEntitlementRepository : IHolidayEntitlement
    {
        private readonly AppDbContext _appDbContext;
        public HolidayEntitlementRepository(AppDbContext AppDbContext)
        {
            _appDbContext = AppDbContext;
        }

        public IEnumerable<HolidayEntitlement> GetAllHolidayEntitlement()
        {
            return _appDbContext.HolidayEntitlements.Include(x => x.Users);
        }
        
        public HolidayEntitlement GetHolidayEntitlementById(int HolidayEntitlementId)
        {
            return _appDbContext.HolidayEntitlements.Include(x => x.Users).FirstOrDefault(p => p.Id == HolidayEntitlementId);
        }

        public void EditHolidayEntitlement(HolidayEntitlement holidayEntitlement)
        {
            _appDbContext.HolidayEntitlements.Update(holidayEntitlement);
            _appDbContext.SaveChanges();
        }
        public void DeleteHolidayEntitlement(HolidayEntitlement holidayEntitlement)
        {
            _appDbContext.HolidayEntitlements.Remove(holidayEntitlement);
            _appDbContext.SaveChanges();
        }

        public void AddHolidayEntitlement(HolidayEntitlement holidayEntitlement)
        {
            _appDbContext.HolidayEntitlements.Add(holidayEntitlement);
            _appDbContext.SaveChanges();
        }


        public float GetUserHolidayEntitlement(string userId, int year)
        {
            HolidayEntitlement holidayEntitlement = _appDbContext.HolidayEntitlements.FirstOrDefault(p => p.Users.Id == userId & p.Year== year);

            if (holidayEntitlement != null)
            {
                return holidayEntitlement.YearsEntitlement;
            }
            else
            {
                return 0;
            }

        }

    }
}
