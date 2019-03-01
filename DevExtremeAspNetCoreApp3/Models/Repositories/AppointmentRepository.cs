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
        private readonly IRuntime _runtime;


        public AppointmentRepository(AppDbContext AppDbContext, IRuntime _Runtime)
        {
            _AppDbContext = AppDbContext;
            _runtime = _Runtime;
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

//            return _AppDbContext.Appointment.ToList();
            return _AppDbContext.Appointment.Where(p => p.DepartmentID == _runtime.CurrentDepartmentId).ToList();
        }

//        ICollection<string> collection = (ICollection<string>)monthsofYear;

        public Appointment GetAppointmentById(int AppointmentId)
        {
            return _AppDbContext.Appointment.FirstOrDefault(p => p.AppointmentId == AppointmentId);
        }
    }
}

