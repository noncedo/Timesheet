using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeautySystem.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public int ServiceID { get; set; }
        public int ClientId { get; set; }
        public string ReviewDate { get; set; }
        public string ReviewDesc { get; set; }
        public bool Active { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }
    }
}