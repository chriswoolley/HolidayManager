using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Data;
using Newtonsoft.Json;
using HolidayWeb.Models;
using HolidayWeb.Models.Interface;
using HolidayWeb.Core;

namespace HolidayWeb.Controllers.ApiControllers {
    [Route("api/[controller]")]
    public class SchedulerDataController : Controller {
        InMemoryAppointmentsDataContext _data;
        IAppointment _appointment;

        public SchedulerDataController(IHttpContextAccessor httpContextAccessor, IMemoryCache memoryCache, IAppointment appointment) {
//            _data = new InMemoryAppointmentsDataContext(httpContextAccessor, memoryCache, appointment);
            _data = new InMemoryAppointmentsDataContext(httpContextAccessor,appointment);
            _appointment = appointment;
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions) {
            return DataSourceLoader.Load(_data.Appointments, loadOptions);
        }
        
        [HttpPost]
        public IActionResult Post(string values) {
            var newAppointment = new Appointment();
            JsonConvert.PopulateObject(values, newAppointment);

            if(!TryValidateModel(newAppointment))
//                return BadRequest(ModelState.GetFullErrorMessage());
                return BadRequest();



            if (newAppointment.StartPeriod == Period.Morning)
            {
                newAppointment.StartDate = new DateTime(newAppointment.StartDate.Year, newAppointment.StartDate.Month, newAppointment.StartDate.Day, 9, 0, 0);
            }
            else
            {
                newAppointment.StartDate = new DateTime(newAppointment.StartDate.Year, newAppointment.StartDate.Month, newAppointment.StartDate.Day, 13, 0, 0);
            }


            if (newAppointment.EndPeriod == Period.Morning)
            {
                newAppointment.EndDate = new DateTime(newAppointment.EndDate.Year, newAppointment.EndDate.Month, newAppointment.EndDate.Day, 13, 0, 0);
            }
            else
            {
                newAppointment.EndDate = new DateTime(newAppointment.EndDate.Year, newAppointment.EndDate.Month, newAppointment.EndDate.Day, 17, 0, 0);
            }



            _appointment.AddAppointment(newAppointment);

            _data.Appointments.Add(newAppointment);
            _data.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int key, string values) {
            var appointment = _data.Appointments.First(a => a.AppointmentId == key);
            JsonConvert.PopulateObject(values, appointment);
            if(!TryValidateModel(appointment))
            //    return BadRequest(ModelState.GetFullErrorMessage());
                return BadRequest();

            _data.SaveChanges();
            _appointment.EditAppointment(appointment);
            return Ok();
        }

        [HttpDelete]
        public void Delete(int key) {
            var appointment = _data.Appointments.First(a => a.AppointmentId == key);
            _data.Appointments.Remove(appointment);
            _data.SaveChanges();
            _appointment.DeleteAppointment(appointment);
        }
    }
}
