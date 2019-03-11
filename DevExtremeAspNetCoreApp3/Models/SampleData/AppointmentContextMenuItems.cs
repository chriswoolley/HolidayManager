using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWeb.Models.SampleData {
    public partial class SampleData {
        public static List<AppointmentContextMenuItem> AppointmentContextMenuItems {
            get {
                var items = new List<AppointmentContextMenuItem> {
                    new AppointmentContextMenuItem {                       
                        Name = "Open"
//                        ,Text = "Open"
                    },
                    new AppointmentContextMenuItem {
                        Name = "Delete"
//                        ,Text = "Delete"
                    },
                    new AppointmentContextMenuItem {
                        Name = "RepeatWeekly",
//                        Text = "Repeat Weekly",
                        BeginGroup = true
                    },
                    new AppointmentContextMenuItem {
                        Name = "SetRoom",
//                        Text = "Set Room",
                        BeginGroup = true,
                        Disabled = true
                    }
                };

                //items.AddRange(RecurringAppointmentsResources.Select(resource =>
                //    new AppointmentContextMenuItem {
                //        Id = resource.Id,
                //        Text = resource.Text,
                //        Color = resource.Color
                //    })
                //);

                return items;
            }
        }
    }
}
