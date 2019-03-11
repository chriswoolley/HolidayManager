using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWeb.Models.Interface
{
    public interface IEventType
    {
        IEnumerable<EventType> GetAllEvent();
        EventType GetEventTypeById(int eventTypeId);
        void EditType(EventType eventType);
        void DeleteType(EventType eventType);
        void AddType(EventType eventType);
    }
}
