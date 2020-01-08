using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeautySystem.Models
{
    public class Slot
    {
        [Key]
        public int SlotId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsTaken { get; set; }
        public bool Active { get; set; }
        public bool IsDeleted { get; set; }
    }
}