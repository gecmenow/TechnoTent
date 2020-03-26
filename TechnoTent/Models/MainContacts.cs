using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnoTent.Cookies;
using TechnoTent.Models.DataBase;
using TechnoTent.Models.ViewModel;

namespace TechnoTent.Models
{
    public class MainContacts
    {
        public static void EditHeaderContacts(ContactsInfoVM contacts)
        {
            using(DataBaseContext db = new DataBaseContext())
            {
                var data = db.HeaderInfoDb.ToList();

                for(int i = 0; i < contacts.HeaderInfo.Count(); i++)
                {
                    if (data[i].NameEn != contacts.HeaderInfo[i].NameEn)
                        data[i].NameEn = contacts.HeaderInfo[i].NameEn;
                    if (data[i].NameRu != contacts.HeaderInfo[i].NameRu)
                        data[i].NameRu = contacts.HeaderInfo[i].NameRu;
                    if (data[i].NameUa != contacts.HeaderInfo[i].NameUa)
                        data[i].NameUa = contacts.HeaderInfo[i].NameUa;
                    if (data[i].Phone != contacts.HeaderInfo[i].Phone)
                        data[i].Phone = contacts.HeaderInfo[i].Phone;
                }

                db.SaveChanges();
            }
        }

        public static void EditFooterContacts(ContactsInfoVM contacts)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var data = db.FooterInfoDb.First();

                if (data.AddressEn != contacts.Footer.AddressEn)
                    data.AddressEn = contacts.Footer.AddressEn;
                if (data.AddressRu != contacts.Footer.AddressRu)
                    data.AddressRu = contacts.Footer.AddressRu;
                if (data.AddressUa != contacts.Footer.AddressUa)
                    data.AddressUa = contacts.Footer.AddressUa;
                if (data.Phone1 != contacts.Footer.Phone1)
                    data.Phone1 = contacts.Footer.Phone1;
                if (data.Phone2 != contacts.Footer.Phone2)
                    data.Phone2 = contacts.Footer.Phone2;
                if (data.Email != contacts.Footer.Email)
                    data.Email = contacts.Footer.Email;

                db.SaveChanges();
            }
        }

        public static void EditContactsContacts(ContactsInfoVM contacts)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var data = db.ContactsDb.ToList();

                for (int i = 0; i < contacts.Contacts.Count(); i++)
                {
                    if (data[i].NameEn != contacts.Contacts[i].NameEn)
                        data[i].NameEn = contacts.Contacts[i].NameEn;
                    if (data[i].NameRu != contacts.Contacts[i].NameRu)
                        data[i].NameRu = contacts.Contacts[i].NameRu;
                    if (data[i].NameUa != contacts.Contacts[i].NameUa)
                        data[i].NameUa = contacts.Contacts[i].NameUa;
                    if (data[i].Phone != contacts.Contacts[i].Phone)
                        data[i].Phone = contacts.Contacts[i].Phone;
                }
               
                db.SaveChanges();
            }
        }

        public static ContactsInfoVM AdminShowInfo()
        {
            ContactsInfoVM data = new ContactsInfoVM();

            using (DataBaseContext db = new DataBaseContext())
            {
                data.Contacts = db.ContactsDb.Select(x => new ContactsVM
                {
                    NameUa = x.NameUa,
                    NameRu = x.NameRu,
                    NameEn = x.NameEn,
                    Phone = x.Phone,
                }).ToList();

                data.HeaderInfo = db.HeaderInfoDb.Select(x => new HeaderInfoVM
                {
                    NameUa = x.NameUa,
                    NameRu = x.NameRu,
                    NameEn = x.NameEn,
                    Phone = x.Phone,
                }).ToList();

                data.Footer = db.FooterInfoDb.Select(x => new FooterInfoVM
                {
                    AddressUa = x.AddressUa,
                    AddressRu = x.AddressRu,
                    AddressEn = x.AddressEn,
                    Phone1 = x.Phone1,
                    Phone2 = x.Phone2,
                    Email = x.Email,
                }).FirstOrDefault();   
            }

            return data;
        }

        public static ContactsInfoVM ShowInfo()
        {
            ContactsInfoVM data = new ContactsInfoVM();

            using (DataBaseContext db = new DataBaseContext())
            {
                var language = Cookie.CheckLanguageCookie();

                switch (language)
                {
                    case "uk":
                        data.Contacts = db.ContactsDb.Select(x => new ContactsVM
                        {
                            Name = x.NameUa,
                            Phone = x.Phone,
                        }).ToList();

                        data.HeaderInfo = db.HeaderInfoDb.Select(x => new HeaderInfoVM
                        {
                            Name = x.NameUa,
                            Phone = x.Phone,
                        }).ToList();

                        data.Footer = db.FooterInfoDb.Select(x => new FooterInfoVM
                        {
                            Address = x.AddressUa,
                            Phone1 = x.Phone1,
                            Phone2 = x.Phone2,
                            Email = x.Email,
                        }).FirstOrDefault();
                        break;
                    case "en":
                        data.Contacts = db.ContactsDb.Select(x => new ContactsVM
                        {
                            Name = x.NameEn,
                            Phone = x.Phone,
                        }).ToList();

                        data.HeaderInfo = db.HeaderInfoDb.Select(x => new HeaderInfoVM
                        {
                            Name = x.NameEn,
                            Phone = x.Phone,
                        }).ToList();

                        data.Footer = db.FooterInfoDb.Select(x => new FooterInfoVM
                        {
                            Address = x.AddressEn,
                            Phone1 = x.Phone1,
                            Phone2 = x.Phone2,
                            Email = x.Email,
                        }).FirstOrDefault();

                        break;
                    default:
                        data.Contacts = db.ContactsDb.Select(x => new ContactsVM
                        {
                            Name = x.NameRu,
                            Phone = x.Phone,
                        }).ToList();

                        data.HeaderInfo = db.HeaderInfoDb.Select(x => new HeaderInfoVM
                        {
                            Name = x.NameRu,
                            Phone = x.Phone,
                        }).ToList();

                        data.Footer = db.FooterInfoDb.Select(x => new FooterInfoVM
                        {
                            Address = x.AddressRu,
                            Phone1 = x.Phone1,
                            Phone2 = x.Phone2,
                            Email = x.Email,
                        }).FirstOrDefault();
                        break;
                }
            }

            return data;
        }
    }
}