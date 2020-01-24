using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.UserModels
{
    public class Authentication
    {
        public Registration Registration { get; set; }
        public Login Login { get; set; }
    }
}