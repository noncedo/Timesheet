using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeautySystem.Models
{
    public class Employee
    {
        [Key]
        public int  EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }
        public string Address { get; set; }

        [NotMapped]
        public string FullName { get { return string.Format("{0} {1}", Name, Surname); } }
    }
}