using HolidayWeb.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return _appDbContext.HolidayEntitlements;
        }
        
        public HolidayEntitlement GetHolidayEntitlementById(int HolidayEntitlementId)
        {
            return _appDbContext.HolidayEntitlements.FirstOrDefault(p => p.Id == HolidayEntitlementId);
        }

    }
}
