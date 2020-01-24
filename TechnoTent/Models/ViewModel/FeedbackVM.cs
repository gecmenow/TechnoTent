using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.ViewModel
{
    public class FeedbackVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string Tel { get; set; }
        [Required]
        public string Message { get; set; }
    }
}