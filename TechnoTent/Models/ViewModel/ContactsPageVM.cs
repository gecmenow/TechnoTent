using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.ViewModel
{
    public class ContactsPageVM
    {
        public int Id { get; set; }
        public List<int> PhoneIdList { get; set; }
        public List<int> ViberIdList { get; set; }
        public string Address { get; set; }
        public string AddressUa { get; set; }
        public string AddressRu { get; set; }
        public string AddressEn { get; set; }
        public string PhoneName { get; set; }
        public List<string> PhoneNameList { get; set; }
        //public string PhoneNameUa { get; set; }
        //public string PhoneNameRu { get; set; }
        //public string PhoneNameEn { get; set; }
        public List<string> PhoneNameRu { get; set; }
        public List<string> PhoneNameEn { get; set; }
        public List<string> PhoneNameUa { get; set; }
        public List<List<string>> PhoneNumbers { get; set; }
        public List<string> PhoneList { get; set; }
        public string PhoneNumber { get; set; }
        public string ViberName { get; set; }
        public List<string> ViberNameList { get; set; }
        public List<string> ViberNameUa { get; set; }
        public List<string> ViberNameRu { get; set; }
        public List<string> ViberNameEn { get; set; }
        public List<string> ViberNumber { get; set; }
        //ublic List<ViberInfo> ViberInfoList { get; set; }
        public string WorkTime { get; set; }
        public List<string> WorkTimeList { get; set; }
        public string WorkTimeUa { get; set; }
        public string WorkTimeEn { get; set; }
        public string WorkTimeRu { get; set; }

        public class ViberInfo
        {
            public string ViberName { get; set; }
            public string ViberNameUa { get; set; }
            public string ViberNameRu { get; set; }
            public string ViberNameEn { get; set; }
            public string ViberNumber { get; set; }
        }
    }
}