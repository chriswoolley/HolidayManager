using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;

namespace HolidayWeb.Models
{
    public class Appointment {
        [Key]
        public int DBId { get; set; }//sorry AppointmentId populated by component
        [JsonProperty(PropertyName = "AppointmentId")]
        public int AppointmentId { get; set; }
        [JsonProperty(PropertyName = "Text")]
        public string Text { get; set; }
        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "StartDate")]
        public DateTime StartDate { get; set; }
        [JsonProperty(PropertyName = "EndDate")]
        public DateTime EndDate { get; set; }
        [JsonProperty(PropertyName = "AllDay")]
        public bool AllDay { get; set; }
        [JsonProperty(PropertyName = "RecurrenceRule")]
        public string RecurrenceRule { get; set; }

        [JsonProperty(PropertyName = "DepartmentID")]
        public int DepartmentID { get; set; }

        [JsonProperty(PropertyName = "StatusKey")]
        public int StatusKey { get; set; }

        [JsonProperty(PropertyName = "UserID")]
        public int UserID { get; set; }

    }
}
