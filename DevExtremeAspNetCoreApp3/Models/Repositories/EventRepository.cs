using HolidayWeb.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWeb.Models.Repositories
{
    public class EventRepository : IEvent
    {
        private readonly AppDbContext _AppDbContext;
        public EventRepository(AppDbContext AppDbContext)
        {
            _AppDbContext = AppDbContext;
        }

        public IEnumerable<Event> GetAllDepartment()
        {
            return _AppDbContext.Event;
        }

        public IEnumerable<Event> GetAllEvent()
        {
            return _AppDbContext.Event.OrderBy(p => p.StartTime);
        }

        public Event GetEventById(int eventId)
        {
            return _AppDbContext.Event.FirstOrDefault(p => p.Id == eventId);
        }

        public void EditEvent(Event _event)
        {
            _AppDbContext.Event.Update(_event);
            _AppDbContext.SaveChanges();
        }

        public void DeleteEvent(Event _event)
        {
            _AppDbContext.Event.Remove(_event);
            _AppDbContext.SaveChanges();
        }

        public void AddEvent(Event _event)
        {
            _AppDbContext.Event.Add(_event);
            _AppDbContext.SaveChanges();
        }

    }
}
