using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeautySystem.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }
        public string Address { get; set; }
    }
}