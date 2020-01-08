using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeautySystem.Models
{
    public class TimeSheetViewModel
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int EmployeeProjectId { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string FullName { get; set; }
        public int EmployeeId { get; set; }

       


        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        public int HoursWorked { get; set; }
        public DateTime Date { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; }
        public virtual Client Client { get; set; }
        public virtual EmployeeProject EmployeeProject { get; set; }



    }
}