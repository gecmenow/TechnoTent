using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using TechnoTent.Cookies;
using TechnoTent.Models.DataBase;
using TechnoTent.Models.ViewModel;

namespace TechnoTent.Models
{
    public class Company
    {
        public static CompanyVM GetInfo()
        {
            CompanyVM info = new CompanyVM();

            var language = Cookie.CheckLanguageCookie();

            List<string> phones = new List<string>();
            List<string> email = new List<string>();

            using (DataBaseContext db = new DataBaseContext())
            {
                switch (language)
                {
                    case "uk":
                        info = db.CompanyDb.Select(x => new CompanyVM
                        {
                            About = x.AboutUa,
                            Address = x.AddressUa,
                            Banking = x.Banking,
                            BankReq = x.BankReq,
                            INN = x.INN,
                            OrgName = x.OrgNameUa,
                            PhoneNumbers = x.Phone,
                            Emails = x.Email,
                        }).FirstOrDefault();

                        var orgInfo = db.CompanyDb.ToList();

                        info.Name = new List<string>();
                        info.Phone = new List<List<string>>();
                        info.Email = new List<List<string>>();

                        foreach (var data in orgInfo)
                        {
                            if (data.Phone != null)
                            {
                                if (data.Phone.Contains("|"))
                                {
                                    var temp = data.Phone.Split('|').ToList();

                                    for (int i = 0; i < temp.Count(); i++)
                                        temp[i] = Regex.Replace(temp[i], @"[^\d]", "");

                                    info.Phone.Add(temp);
                                }
                                else
                                {
                                    List<string> temp = new List<string>();

                                    temp.Add(data.Phone);
                                    info.Phone.Add(temp);
                                }
                            }

                            if (data.Email != null)
                            {
                                if (data.Email.Contains("|"))
                                {
                                    var temp = data.Email.Split('|').ToList();

                                    for (int i = 0; i < temp.Count(); i++)
                                        temp[i] = Regex.Replace(temp[i], @"[^\d]", "");

                                    info.Email.Add(temp);
                                }
                                else
                                {
                                    List<string> temp = new List<string>();

                                    temp.Add(data.Email);
                                    info.Email.Add(temp);
                                }
                            }

                            info.Name.Add(data.NameUa);
                        }

                        break;
                    case "en":
                        info = db.CompanyDb.Select(x => new CompanyVM
                        {
                            About = x.AboutEn,
                            Address = x.AddressEn,
                            Banking = x.Banking,
                            BankReq = x.BankReq,
                            INN = x.INN,
                            OrgName = x.OrgNameEn,
                            PhoneNumbers = x.Phone,
                            Emails = x.Email,
                        }).FirstOrDefault();

                        var orgInfoEn = db.CompanyDb.ToList();

                        info.Name = new List<string>();
                        info.Phone = new List<List<string>>();
                        info.Email = new List<List<string>>();

                        foreach (var data in orgInfoEn)
                        {
                            if (data.Phone != null)
                            {
                                if (data.Phone.Contains("|"))
                                {
                                    var temp = data.Phone.Split('|').ToList();

                                    for (int i = 0; i < temp.Count(); i++)
                                        temp[i] = Regex.Replace(temp[i], @"[^\d]", "");

                                    info.Phone.Add(temp);
                                }
                                else
                                {
                                    List<string> temp = new List<string>();

                                    temp.Add(data.Phone);
                                    info.Phone.Add(temp);
                                }
                            }

                            if (data.Email != null)
                            {
                                if (data.Email.Contains("|"))
                                {
                                    var temp = data.Email.Split('|').ToList();

                                    for (int i = 0; i < temp.Count(); i++)
                                        temp[i] = Regex.Replace(temp[i], @"[^\d]", "");

                                    info.Email.Add(temp);
                                }
                                else
                                {
                                    List<string> temp = new List<string>();

                                    temp.Add(data.Email);
                                    info.Email.Add(temp);
                                }
                            }

                            info.Name.Add(data.NameEn);
                        }

                        break;
                    default:
                        info = db.CompanyDb.Select(x => new CompanyVM
                        {
                            About = x.AboutRu,
                            Address = x.AddressRu,
                            Banking = x.Banking,
                            BankReq = x.BankReq,
                            INN = x.INN,
                            OrgName = x.OrgNameRu,
                            PhoneNumbers = x.Phone,
                            Emails = x.Email,
                        }).FirstOrDefault();

                        var orgInfoRu = db.CompanyDb.ToList();

                        info.Name = new List<string>();
                        info.Phone = new List<List<string>>();
                        info.Email = new List<List<string>>();

                        foreach (var data in orgInfoRu)
                        {
                            if (data.Phone != null)
                            {
                                if (data.Phone.Contains("|"))
                                {
                                    var temp = data.Phone.Split('|').ToList();

                                    for(int i = 0; i < temp.Count(); i++)
                                        temp[i] = Regex.Replace(temp[i], @"[^\d]", "");

                                    info.Phone.Add(temp);
                                }
                                else
                                {
                                    List<string> temp = new List<string>();

                                    temp.Add(data.Phone);
                                    info.Phone.Add(temp);
                                }
                            }

                            if (data.Email != null)
                            {
                                if (data.Email.Contains("|"))
                                {
                                    var temp = data.Email.Split('|').ToList();

                                    for (int i = 0; i < temp.Count(); i++)
                                        temp[i] = Regex.Replace(temp[i], @"[^\d]", "");

                                    info.Email.Add(temp);
                                }
                                else
                                {
                                    List<string> temp = new List<string>();

                                    temp.Add(data.Email);
                                    info.Email.Add(temp);
                                }
                            }

                            info.Name.Add(data.NameRu);
                        }

                        break;
                }
            }
            return info;
        }
    }
}