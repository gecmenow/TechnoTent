using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnoTent.Models
{
    public class PhoneNumber
    {
        public static string MakePhoneNumber(string phone)
        {
            phone = phone.Replace(" - ", "");
            phone = phone.Replace("- ", "");
            phone = phone.Replace(" -", "");
            phone = phone.Replace("   ", "");
            phone = phone.Replace("  ", "");
            phone = phone.Replace("  ", "");
            phone = phone.Replace(" ", "");
            phone = phone.Replace("-", "");
            phone = phone.Replace("_", "");
            phone = phone.Replace(" _ ", "");
            phone = phone.Replace("_ ", "");
            phone = phone.Replace(" _", "");
            phone = phone.Replace("—", "");
            phone = phone.Replace(" — ", "");
            phone = phone.Replace(" —", "");
            phone = phone.Replace("— ", "");
            phone = phone.Replace(" ( ", "");
            phone = phone.Replace("( ", "");
            phone = phone.Replace(" (", "");
            phone = phone.Replace(" ) ", "");
            phone = phone.Replace(") ", "");
            phone = phone.Replace(" )", "");

            string tel = phone;

            return tel;
        }
    }
}