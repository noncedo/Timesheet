using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeautySystem.Models
{
    public class EmployeeRole
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}