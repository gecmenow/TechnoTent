using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnoTent.Models.DataBase;
using TechnoTent.Models.ViewModel;

namespace TechnoTent.Models
{
    public class Company
    {
        public CompanyVM GetInfo()
        {
            CompanyVM info = new CompanyVM();

            using(DataBaseContext db = new DataBaseContext())
            {
                info = db.CompanyDb.Select(x => new CompanyVM {
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
    }
}