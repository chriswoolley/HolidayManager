using HolidayWeb.Models.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWeb.Models.Repositories
{
    public class AppointmentRepository : IAppointment
    {
        private readonly AppDbContext _AppDbContext;
        public AppointmentRepository(AppDbContext AppDbContext)
        {
            _AppDbContext = AppDbContext;
        }

        public void AddAppointment(Appointment appointment)
        {
            _AppDbContext.Appointment.Add(appointment);
            _AppDbContext.SaveChanges();
        }

        public void DeleteAppointment(Appointment appointment)
        {
            _AppDbContext.Appointment.Remove(appointment);
            _AppDbContext.SaveChanges();
        }


        public void EditAppointment(Appointment appointment)
        {
            _AppDbContext.Appointment.Update(appointment);
            _AppDbContext.SaveChanges();
        }

        public IEnumerable<Appointment> GetAllAppointment()
        {
            return _AppDbContext.Appointment;
        }


        public ICollection<Appointment> GetAppointmentCollection()
        {
            return _AppDbContext.Appointment.ToList();
        }

//        ICollection<string> collection = (ICollection<string>)monthsofYear;

        //        public GetAppointmentById(int AppointmentId)
        //        {
        //            return _AppDbContext.Appointment.FirstOrDefault(p => p.AppointmentId == AppointmentId);
        //        }
    }
}

