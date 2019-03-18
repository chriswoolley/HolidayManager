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
using Microsoft.AspNetCore.Identity;

namespace HolidayWeb.Controllers.ApiControllers {
    [Route("api/[controller]")]
    public class SchedulerDataController : Controller {
        InMemoryAppointmentsDataContext _data;
        IAppointment _appointment;

        private readonly UserManager<HolidayUser> _userManager;


        public SchedulerDataController(IHttpContextAccessor httpContextAccessor, IMemoryCache memoryCache, IAppointment appointment, UserManager<HolidayUser> userManager)
        {
            _data = new InMemoryAppointmentsDataContext(httpContextAccessor,appointment);
            _appointment = appointment;
            _userManager = userManager;
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions) {
            return DataSourceLoader.Load(_data.Appointments, loadOptions);
        }
        
        [HttpPost]
//        public async System.Threading.Tasks.Task<IActionResult> PostAsync(string values) {
        public IActionResult Post(string values)
            {
                var newAppointment = new Appointment();
            JsonConvert.PopulateObject(values, newAppointment);

            if(!TryValidateModel(newAppointment))
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

            var holidayUser = _userManager.Users.Where(p => p.Id == newAppointment.UserID).FirstOrDefault();
            if (holidayUser != null)
            {
                newAppointment.Description = holidayUser.UserName;
                if (newAppointment.StartDate.Date == newAppointment.EndDate.Date)
                {
                    if ((newAppointment.StartPeriod == Period.Morning) && (newAppointment.EndPeriod == Period.Afternoon))
                    {
                        newAppointment.Description = newAppointment.Description + " All day";
                    }
                    else
                    {
                        newAppointment.Description = newAppointment.Description + " " + newAppointment.StartPeriod.ToString();
                    }


                }
            }

            _appointment.AddAppointment(newAppointment);

            _data.Appointments.Add(newAppointment);
            _data.SaveChanges();

            return Ok();
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetJSONJQuery()
        {


            return Json("Test Stuff here ");
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
