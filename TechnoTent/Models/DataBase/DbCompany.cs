using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.DataBase
{
    public class DbCompany
    {
        public int Id { get; set; }
        public string AboutRu { get; set; }
        public string AboutEn { get; set; }
        public string AboutUa { get; set; }
        public string OrgNameRu { get; set; }
        public string OrgNameEn { get; set; }
        public string OrgNameUa { get; set; }
        public string AddressRu { get; set; }
        public string AddressEn { get; set; }
        public string AddressUa { get; set; }
        public string NameRu { get; set; }
        public string NameEn { get; set; }
        public string NameUa { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Banking { get; set; }
        public string BankReq { get; set; }
        public string INN { get; set; }
    }
}