using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeautySystem.Models
{
    public class EmployeeProject
    {
        [Key]
        public int EmployeeProjectId { get; set; }
        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }
        [Display(Name = "Project")]
        public int ProjectId { get; set; }
        [Display(Name = "Client")]
        public int ClientId { get; set; }
        [Display(Name = "Hours Worked")]
        public int HoursWorked { get; set; }
        public DateTime Date { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; }
        public virtual Client Client { get; set; }

    }
}