using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeautySystem.Models
{
    public class EmployeeSkill
    {
        [Key]
        public int EmployeeSkillId { get; set; }
        public int EmployeeId { get; set; }
        public int SkillId { get; set; }
        public bool Active { get; set; }
        public bool IsDeleted { get; set; }
    }
}