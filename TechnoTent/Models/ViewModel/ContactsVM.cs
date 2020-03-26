using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.ViewModel
{
    public class ContactsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameRu { get; set; }
        public string NameUa { get; set; }
        public string NameEn { get; set; }
        public string Phone { get; set; }
    }
}