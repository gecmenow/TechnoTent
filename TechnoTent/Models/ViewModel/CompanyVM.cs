using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.ViewModel
{
    public class CompanyVM
    {
        public int Id { get; set; }
        public List<int> IdList { get; set; }
        public string About { get; set; }
        public string AboutRu { get; set; }
        public string AboutEn { get; set; }
        public string AboutUa { get; set; }
        public string OrgName { get; set; }
        public string OrgNameRu { get; set; }
        public string OrgNameEn { get; set; }
        public string OrgNameUa { get; set; }
        public string Address { get; set; }
        public string AddressRu { get; set; }
        public string AddressEn { get; set; }
        public string AddressUa { get; set; }
        public List<string> Name { get; set; }
        public List<string> NameRu { get; set; }
        public List<string> NameEn { get; set; }
        public List<string> NameUa { get; set; }
        public string PhoneNumbers { get; set; }
        public List<List<string>> Phone { get; set; }
        public List<string> PhoneList { get; set; }
        public string Emails { get; set; }
        public List<List<string>> Email { get; set; }
        public List<string> EmailList { get; set; }
        public string Banking { get; set; }
        public string BankReq { get; set; }
        public string INN { get; set; }

        public List<CompanyVM> OrgModel { get; set; }
    }

    //public class OrganizationModel
    //{
    //    public List<string> NameRu { get; set; }
    //    public List<string> NameEn { get; set; }
    //    public List<string> NameUa { get; set; }
    //    public List<string> PhoneList { get; set; }
    //    public List<string> EmailList { get; set; }

    //}
}