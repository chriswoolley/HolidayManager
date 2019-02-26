using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWeb.Models.Interface
{
    public interface ISystemSetting
    {
        SystemSetting GetAllSystemSetting();

        SystemSetting GetSystemSettingById(int SystemSettingId);

        void EditSystemSetting(SystemSetting SystemSetting);

        void DeleteSystemSetting(SystemSetting SystemSetting);

        void AddSystemSetting(SystemSetting SystemSetting);
        
    }
}
