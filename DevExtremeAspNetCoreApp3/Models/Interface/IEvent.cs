using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWeb.Models.Interface
{
    public interface IEvent
    {
        IEnumerable<Event> GetAllEvent();

        Event GetEventById(int eventId);

        void EditEvent(Event _event);
        void DeleteEvent(Event _event);
        void AddEvent(Event _event);
    }
}
