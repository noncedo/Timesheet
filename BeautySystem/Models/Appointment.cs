using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeautySystem.Models
{
    public class Appointment
    {
        public int AppointmentId {get; set; }
        public int ClientId { get; set; }
        public int SlotId { get; set; }
        public int ServiceId { get; set; }
        public DateTime AppointmentDate { get; set; }
       // private int StateID { get; set; }
        public bool Active { get; set; }
        public bool IsDeleted { get; set; }
        public string UserCharID { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}