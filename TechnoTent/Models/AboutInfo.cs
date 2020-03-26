using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnoTent.Models.DataBase;
using TechnoTent.Models.ViewModel;

namespace TechnoTent.Models
{
    public class AboutInfo
    {
        public static CompanyVM GetInfo()
        {
            CompanyVM info = new CompanyVM();

            using (DataBaseContext db = new DataBaseContext())
            {
                info = db.CompanyDb.Select(x => new CompanyVM
                {
                    AboutEn = x.AboutEn,
                    AboutRu = x.AboutRu,
                    AboutUa = x.AboutUa,
                    AddressEn = x.AddressEn,
                    AddressRu = x.AddressRu,
                    AddressUa = x.AddressUa,
                    Banking = x.Banking,
                    BankReq = x.BankReq,
                    INN = x.INN,
                    OrgNameEn = x.OrgNameEn,
                    OrgNameRu = x.OrgNameRu,
                    OrgNameUa = x.OrgNameUa,
                }).FirstOrDefault();

                var orgInfo = db.CompanyDb.ToList();

                info.IdList = new List<int>();
                info.NameEn = new List<string>();
                info.NameRu = new List<string>();
                info.NameUa = new List<string>();
                info.Phone = new List<List<string>>();
                info.Email = new List<List<string>>();

                List<string> phones = new List<string>();
                List<string> email = new List<string>();

                foreach (var data in orgInfo)
                {
                    if (data.Phone != null)
                    {
                        if (data.Phone.Contains("|"))
                        {
                            var temp = data.Phone.Split('|').ToList();

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

                            info.Email.Add(temp);
                        }
                        else
                        {
                            List<string> temp = new List<string>();

                            temp.Add(data.Email);
                            info.Email.Add(temp);
                        }
                    }

                    info.IdList.Add(data.Id);
                    info.NameEn.Add(data.NameEn);
                    info.NameRu.Add(data.NameRu);
                    info.NameUa.Add(data.NameUa);
                }
            }

            return info;
        }

        public static void EditInfo(CompanyVM info)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var data = db.CompanyDb.FirstOrDefault();

                if (data.AboutEn != info.AboutEn)
                    data.AboutEn = info.AboutEn;
                if (data.AboutRu != info.AboutRu)
                    data.AboutRu = info.AboutRu;
                if (data.AboutUa != info.AboutUa)
                    data.AboutUa = info.AboutUa;
                if (data.AddressEn != info.AddressEn)
                    data.AddressEn = info.AddressEn;
                if (data.AddressRu != info.AddressRu)
                    data.AddressRu = info.AddressRu;
                if (data.AddressUa != info.AddressUa)
                    data.AddressUa = info.AddressUa;
                if (data.Banking != info.Banking)
                    data.Banking = info.Banking;
                if (data.BankReq != info.BankReq)
                    data.BankReq = info.BankReq;
                if (data.INN != info.INN)
                    data.INN = info.INN;
                if (data.OrgNameEn != info.OrgNameEn)
                    data.OrgNameEn = info.OrgNameEn;
                if (data.OrgNameRu != info.OrgNameRu)
                    data.OrgNameRu = info.OrgNameRu;
                if (data.OrgNameUa != info.OrgNameUa)
                    data.OrgNameUa = info.OrgNameUa;

                var allInfo = db.CompanyDb.ToList();

                if (allInfo.Count() == info.NameRu.Count())
                {
                    for (int i = 0; i < info.NameRu.Count(); i++)
                    {
                        if (allInfo[i].NameRu != info.NameRu[i])
                            allInfo[i].NameRu = info.NameRu[i];
                        if (allInfo[i].NameEn != info.NameEn[i])
                            allInfo[i].NameEn = info.NameEn[i];
                        if (allInfo[i].NameUa != info.NameUa[i])
                            allInfo[i].NameUa = info.NameUa[i];
                        if (allInfo[i].Phone != info.PhoneList[i])
                            allInfo[i].Phone = info.PhoneList[i];
                        if (allInfo[i].Email != info.EmailList[i])
                            allInfo[i].Email = info.EmailList[i];
                    }
                }

                else if (allInfo.Count() < info.NameRu.Count())
                {
                    for (int i = 0; i < info.NameRu.Count(); i++)
                    {
                        if (allInfo[i].NameRu != info.NameRu[i])
                            allInfo[i].NameRu = info.NameRu[i];
                        if (allInfo[i].NameEn != info.NameEn[i])
                            allInfo[i].NameEn = info.NameEn[i];
                        if (allInfo[i].NameUa != info.NameUa[i])
                            allInfo[i].NameUa = info.NameUa[i];
                        if (allInfo[i].Phone != info.PhoneList[i])
                            allInfo[i].Phone = info.PhoneList[i];
                        if (allInfo[i].Email != info.EmailList[i])
                            allInfo[i].Email = info.EmailList[i];
                    }

                    for (int i = allInfo.Count(); i < info.NameRu.Count(); i++)
                    {
                        db.CompanyDb.Add(new DbCompany
                        {
                            NameRu = info.NameRu[i],
                            NameEn = info.NameEn[i],
                            NameUa = info.NameUa[i],
                            Phone = info.PhoneList[i],
                            Email = info.EmailList[i],
                        });
                    }
                }

                else
                {
                    List<int> idList = new List<int>();

                    for (int i = 0; i < allInfo.Count(); i++)
                        idList.Add(allInfo[i].Id);

                    var differences = idList.Except(info.IdList);

                    foreach(var dif in differences)
                    {
                        var temp = db.CompanyDb.Where(x => x.Id == dif).FirstOrDefault();

                        db.CompanyDb.Remove(temp);
                    }
                }
                
                db.SaveChanges();
            }
        }
    }
}