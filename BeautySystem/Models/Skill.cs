using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeautySystem.Models
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public string SkillDesc { get; set; }

    }
}