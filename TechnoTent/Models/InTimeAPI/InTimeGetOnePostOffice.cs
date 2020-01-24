using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace TechnoTent.Models.InTimeAPI
{
    public class InTimeGetOnePostOffice
    {
        public string BranchNameUa { get; set; }
        public string BranchNameRu { get; set; }
        public string AddressUa { get; set; }
        public string AddressRu { get; set; }

        public InTimeGetOnePostOffice(string branch_name_ua, string branch_name_ru, string address_ua, string address_ru)
        {
            this.BranchNameUa = branch_name_ua;
            this.BranchNameRu = branch_name_ru;
            this.AddressUa = address_ua;
            this.AddressRu = address_ru;
        }

        public static List<InTimeGetOnePostOffice> GetSinglePostOffice(string text)
        {
            int branchNameUaStart = text.IndexOf("branch_name_ua") + "branch_name_ua : ".Length;
            int branchNameUaEnd = text.IndexOf("branch_name_en");
            string branchNameUa = text.Substring(branchNameUaStart, branchNameUaEnd - branchNameUaStart);

            branchNameUa = branchNameUa.Replace(",", "");
            branchNameUa = branchNameUa.Replace("\"", "");

            int branchNameRuStart = text.IndexOf("branch_name_ru") + "branch_name_ru : ".Length;
            int branchNameRuEnd = text.IndexOf("branch_short_name_ua");
            string branchNameRu = text.Substring(branchNameRuStart, branchNameRuEnd - branchNameRuStart);

            branchNameRu = branchNameRu.Replace(",", "");
            branchNameRu = branchNameRu.Replace("\"", "");

            int addressUaStart = text.IndexOf("address_ua") + "address_ua : ".Length;
            int addressUaEnd = text.IndexOf("address_en");
            string addressUa = text.Substring(addressUaStart, addressUaEnd - addressUaStart);

            addressUa = addressUa.Replace(",", "");
            addressUa = addressUa.Replace("\"", "");

            int addressRuStart = text.IndexOf("address_ru") + "address_ru : ".Length;
            int addressRuEnd = text.IndexOf("status");
            string addressRu = text.Substring(addressRuStart, addressRuEnd - addressRuStart);

            addressRu = addressRu.Replace(",", "");
            addressRu = addressRu.Replace("\"", "");

            List<InTimeGetOnePostOffice> result = new List<InTimeGetOnePostOffice>();

            result.Add(new InTimeGetOnePostOffice(branchNameUa, branchNameRu, addressUa, addressRu));

            return result;
        }

        public static int CheckPostOfficesCount(string text)
        {
            int count = Regex.Matches(text, "status").Count;

            return count;
        }
    }
}