using HolidayWeb.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWeb.Models.Repositories
{
    public class SystemSettingRepository : ISystemSetting
    {
        private readonly AppDbContext _AppDbContext;
        public SystemSettingRepository(AppDbContext AppDbContext)
        {
            _AppDbContext = AppDbContext;
        }

        public SystemSetting GetAllSystemSetting()
        {
            return _AppDbContext.SystemSetting.FirstOrDefault(); ;
        }

        public SystemSetting GetSystemSettingById(int SystemSettingId)
        {
            return _AppDbContext.SystemSetting.FirstOrDefault(p => p.Id == SystemSettingId);
        }

        public void EditSystemSetting(SystemSetting SystemSetting)
        {
            _AppDbContext.SystemSetting.Update(SystemSetting);
            _AppDbContext.SaveChanges();
        }

        public void DeleteSystemSetting(SystemSetting SystemSetting)
        {
            _AppDbContext.SystemSetting.Remove(SystemSetting);
            _AppDbContext.SaveChanges();
        }

        public void AddSystemSetting(SystemSetting SystemSetting)
        {
            _AppDbContext.SystemSetting.Add(SystemSetting);
            _AppDbContext.SaveChanges();
        }


    }
}
