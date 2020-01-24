using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.DataBase
{
    public class DbCart
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public int UserId { get; set; }
        public string VendorCode { get; set; }
        public string ItemCount { get; set; }
        public double ItemPrice { get; set; }
    }
}