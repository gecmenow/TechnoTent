using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.DataBase
{
    public class DbAdmin
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int UniqueNumber { get; set; }
        public string NovaPoshtaKey { get; set; }
        public string InTimeKey { get; set; }
    }
}