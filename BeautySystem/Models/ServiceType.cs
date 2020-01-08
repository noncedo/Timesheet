using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeautySystem.Models
{
    public class ServiceType
    {
        [Key]
        public int ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; }
        public string ServiceTypeDesc { get; set; }
        public bool active { get; set; }
        public bool isDeleted { get; set; }
    }
}