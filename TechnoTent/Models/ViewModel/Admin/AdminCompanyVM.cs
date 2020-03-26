using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.ViewModel.Admin
{
    public class AdminCompanyVM
    {
        public int Id { get; set; }
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
        public string Name { get; set; }
        public string[] NameRu { get; set; }
        public string[] NameEn { get; set; }
        public string[] NameUa { get; set; }
        public string Phone { get; set; }
        public List<string> PhoneList { get; set; }
        public string Email { get; set; }
        public List<string> EmailList { get; set; }
        public string Banking { get; set; }
        public string BankReq { get; set; }
        public string INN { get; set; }

        //public List<OrganizationModel> OrgModel { get; set; }
    }
}