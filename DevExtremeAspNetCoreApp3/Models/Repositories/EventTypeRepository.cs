using HolidayWeb.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWeb.Models.Repositories
{
    public class EventTypeRepository : IEventType
    {
        private readonly AppDbContext _AppDbContext;
        public EventTypeRepository(AppDbContext AppDbContext)
        {
            _AppDbContext = AppDbContext;
        }

        public IEnumerable<EventType> GetAllEvent()
        {
            return _AppDbContext.EventTypes;
        }

        public EventType GetEventTypeById(int eventTypeId)
        {
            return _AppDbContext.EventTypes.FirstOrDefault(p => p.Id == eventTypeId);
        }
                     
        public void EditType(EventType eventType)
        {
            _AppDbContext.EventTypes.Update(eventType);
            _AppDbContext.SaveChanges();
        }
        public void DeleteType(EventType eventType)
        {
            _AppDbContext.EventTypes.Remove(eventType);
            _AppDbContext.SaveChanges();
        }

        public void AddType(EventType eventType)
        {
            _AppDbContext.EventTypes.Add(eventType);
            _AppDbContext.SaveChanges();
        }

    }
}
