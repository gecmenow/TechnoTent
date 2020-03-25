using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnoTent.Models.DataBase;
using TechnoTent.Models.ViewModel.Admin;

namespace TechnoTent.Models
{
    public class AdminCompany
    {
        public void AddInfo(AdminCompanyVM adminCompanyVM)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                db.CompanyDb.Add(
                    new DbCompany
                    {
                        AboutRu = adminCompanyVM.AboutRu,
                        AboutEn = adminCompanyVM.AboutEn,
                        AboutUa = adminCompanyVM.AboutUa,
                        AddressRu = adminCompanyVM.AddressRu,
                        AddressEn = adminCompanyVM.AddressEn,
                        AddressUa = adminCompanyVM.AddressUa,
                        Banking = adminCompanyVM.Banking,
                        BankReq = adminCompanyVM.BankReq,
                        INN = adminCompanyVM.INN,
                        NameRu = adminCompanyVM.NameRu,
                        NameEn = adminCompanyVM.NameEn,
                        NameUa = adminCompanyVM.NameUa,
                        Phone = adminCompanyVM.Phone,
                        Email = adminCompanyVM.Email,
                    });

                db.SaveChanges();
            }
        }

        public AdminCompanyVM GetInfo()
        {
            AdminCompanyVM info = new AdminCompanyVM();

            using (DataBaseContext db = new DataBaseContext())
            {
                info = db.CompanyDb.Select(x => new AdminCompanyVM
                {
                    AboutRu = x.AboutRu,
                    AboutEn = x.AboutEn,
                    AboutUa = x.AboutUa,
                    AddressRu = x.AddressRu,
                    AddressEn = x.AddressEn,
                    AddressUa = x.AddressUa,
                    Banking = x.Banking,
                    BankReq = x.BankReq,
                    INN = x.INN,
                    NameRu = x.NameRu,
                    NameEn = x.NameEn,
                    NameUa = x.NameUa,
                    Phone = x.Phone,
                    Email = x.Email,
                }).FirstOrDefault();
            }

            return info;
        }

        public void EditInfo(AdminCompanyVM adminCompanyVM)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var data = db.CompanyDb.FirstOrDefault();

                if (data.AboutRu != adminCompanyVM.AboutRu)
                    data.AboutRu = adminCompanyVM.AboutRu;
                if (data.AboutEn != adminCompanyVM.AboutEn)
                    data.AboutEn = adminCompanyVM.AboutEn;
                if (data.AboutUa != adminCompanyVM.AboutUa)
                    data.AboutUa = adminCompanyVM.AboutUa;
                if (data.AddressRu != adminCompanyVM.AddressRu)
                    data.AddressRu = adminCompanyVM.AddressRu;
                if (data.AddressEn != adminCompanyVM.AddressEn)
                    data.AddressEn = adminCompanyVM.AddressEn;
                if (data.AddressUa != adminCompanyVM.AddressUa)
                    data.AddressUa = adminCompanyVM.AddressUa;
                if (data.OrgNameRu != adminCompanyVM.OrgNameRu)
                    data.OrgNameRu = adminCompanyVM.OrgNameRu;
                if (data.OrgNameEn != adminCompanyVM.OrgNameEn)
                    data.OrgNameEn = adminCompanyVM.OrgNameEn;
                if (data.OrgNameUa != adminCompanyVM.OrgNameUa)
                    data.OrgNameUa = adminCompanyVM.OrgNameUa;
                if (data.Banking != adminCompanyVM.Banking)
                    data.Banking = adminCompanyVM.Banking;
                if (data.BankReq != adminCompanyVM.BankReq)
                    data.BankReq = adminCompanyVM.BankReq;
                if (data.INN != adminCompanyVM.INN)
                    data.INN = adminCompanyVM.INN;
                if (data.NameRu != adminCompanyVM.NameRu)
                    data.NameRu = adminCompanyVM.NameRu;
                if (data.NameEn != adminCompanyVM.NameEn)
                    data.NameEn = adminCompanyVM.NameEn;
                if (data.NameUa != adminCompanyVM.NameUa)
                    data.NameUa = adminCompanyVM.NameUa;
                if (data.Phone != adminCompanyVM.Phone)
                    data.Phone = adminCompanyVM.Phone;
                if (data.Email != adminCompanyVM.Email)
                    data.Email = adminCompanyVM.Email;

                db.SaveChanges();
            }
        }
    }
}