using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeautySystem.Models
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDesc { get; set; }
        public string ServiceCost { get; set; }
        public string Duration { get; set; }
        public string Photo { get; set; }
        public bool Active { get; set; }
        public bool IsDeleted { get; set; }
    }
}