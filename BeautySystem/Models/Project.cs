using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeautySystem.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }
        [Display(Name = "Project Description")]
        public string ProjectDesc { get; set; }
    }
}