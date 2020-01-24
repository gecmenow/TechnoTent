using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.ViewModel.Admin
{
    public class AdminEditVM
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public string NovaPoshtaKey { get; set; }
        public string InTimeKey { get; set; }
    }
}