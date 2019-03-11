using HolidayWeb.Models;
using HolidayWeb.Models.Interface;
using HolidayWeb.Models.SampleData;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;


namespace HolidayWeb.Models {
    public class InMemoryAppointmentsDataContext {
        IHttpContextAccessor _contextAccessor;
        //IMemoryCache _memoryCache;
        IAppointment _appointment;


//        public InMemoryAppointmentsDataContext(IHttpContextAccessor contextAccessor, IMemoryCache memoryCache, IAppointment appointment)
        public InMemoryAppointmentsDataContext(IHttpContextAccessor contextAccessor, IAppointment appointment)
        {
            _contextAccessor = contextAccessor;
//            _memoryCache = memoryCache;
            _appointment = appointment;
        }

        public ICollection<Appointment> Appointments
        {
            get
            {

                return _appointment.GetAppointmentCollection();

                //                var session = _contextAccessor.HttpContext.Session;
                //                var key = session.Id + "_Appointments";

                //                if (_memoryCache.Get(key) == null)
                //                {

                ////                    _memoryCache.Set<ICollection<Appointment>>(key, SampleData.SampleData.Appointments, new MemoryCacheEntryOptions
                //                    _memoryCache.Set<ICollection<Appointment>>(key, _appointment.GetAppointmentCollection() , new MemoryCacheEntryOptions
                //                    {
                //                        SlidingExpiration = TimeSpan.FromMinutes(10)
                //                    });
                //                    session.SetInt32("dirty", 1);
                //                }

                //                return _memoryCache.Get<ICollection<Appointment>>(key);

            }
        }
        public void SaveChanges() {
            //foreach(var appointment in Appointments.Where(a => a.AppointmentId == 0)) {
            //    appointment.AppointmentId = Appointments.Max(a => a.AppointmentId) + 1;

                foreach (var appointment in Appointments.Where(a => a.AppointmentId == 0))
                {
                    appointment.AppointmentId = Appointments.Max(a => a.AppointmentId) + 1;

                }
        }
    }
}
