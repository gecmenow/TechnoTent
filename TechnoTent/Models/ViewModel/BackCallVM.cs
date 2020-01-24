using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.ViewModel
{
    public class BackCallVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Tel { get; set; }
        [Required]
        public string Message { get; set; }
    }
}