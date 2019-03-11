using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWeb.Models.Interface
{
    public interface IAppointment
    {
        void AddAppointment(Appointment appointment);
        void DeleteAppointment(Appointment appointment);
        void EditAppointment(Appointment appointment);
        IEnumerable<Appointment> GetAllAppointment();
        ICollection<Appointment> GetAppointmentCollection();
        Appointment GetAppointmentById(int AppointmentId);
        IEnumerable<Appointment> GetAllAppointmentPerUserYear(string UserId, DateTime startDate, DateTime endTime);

    }
}
