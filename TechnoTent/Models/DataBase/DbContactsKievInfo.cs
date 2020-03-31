using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.DataBase
{
    public class DbContactsKievInfo
    {
        public int Id { get; set; }
        public string AddressUa { get; set; }
        public string AddressRu { get; set; }
        public string AddressEn { get; set; }
        public string PhoneNameUa { get; set; }
        public string PhoneNameRu { get; set; }
        public string PhoneNameEn { get; set; }
        public string PhoneNumber { get; set; }
        public string ViberNameUa { get; set; }
        public string ViberNameRu { get; set; }
        public string ViberNameEn { get; set; }
        public string ViberNumber { get; set; }
        public string WorkTimeUa { get; set; }
        public string WorkTimeEn { get; set; }
        public string WorkTimeRu { get; set; }
    }
}