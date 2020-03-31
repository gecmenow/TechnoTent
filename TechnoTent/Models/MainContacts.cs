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

        public static void EditContactsKievInfo(ContactsInfoVM contacts)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var data = db.KievInfoDb.FirstOrDefault();

                if (data.AddressEn != contacts.KievContacts.AddressEn)
                    data.AddressEn = contacts.KievContacts.AddressEn;
                if (data.AddressRu != contacts.KievContacts.AddressRu)
                    data.AddressRu = contacts.KievContacts.AddressRu;
                if (data.AddressUa != contacts.KievContacts.AddressUa)
                    data.AddressUa = contacts.KievContacts.AddressUa;
                if (data.WorkTimeEn != contacts.KievContacts.WorkTimeEn)
                    data.WorkTimeEn = contacts.KievContacts.WorkTimeEn;
                if (data.WorkTimeRu != contacts.KievContacts.WorkTimeRu)
                    data.WorkTimeRu = contacts.KievContacts.WorkTimeRu;
                if (data.WorkTimeUa != contacts.KievContacts.WorkTimeUa)
                    data.WorkTimeUa = contacts.KievContacts.WorkTimeUa;

                var allInfo = db.KievInfoDb.ToList();

                if (allInfo.Count() == contacts.KievContacts.PhoneNameRu.Count())
                {
                    for (int i = 0; i < contacts.KievContacts.PhoneNameRu.Count(); i++)
                    {
                        if (allInfo[i].PhoneNameEn != contacts.KievContacts.PhoneNameEn[i])
                            allInfo[i].PhoneNameEn = contacts.KievContacts.PhoneNameEn[i];
                        if (allInfo[i].PhoneNameRu != contacts.KievContacts.PhoneNameRu[i])
                            allInfo[i].PhoneNameRu = contacts.KievContacts.PhoneNameRu[i];
                        if (allInfo[i].PhoneNameUa != contacts.KievContacts.PhoneNameUa[i])
                            allInfo[i].PhoneNameUa = contacts.KievContacts.PhoneNameUa[i];
                        if (allInfo[i].PhoneNumber != contacts.KievContacts.PhoneList[i])
                            allInfo[i].PhoneNumber = contacts.KievContacts.PhoneList[i];
                    }
                }
                else if (allInfo.Count() < contacts.KievContacts.PhoneNameRu.Count())
                {
                    for (int i = 0; i < contacts.KievContacts.PhoneNameRu.Count() - 1; i++)
                    {
                        if (allInfo[i].PhoneNameEn != contacts.KievContacts.PhoneNameEn[i])
                            allInfo[i].PhoneNameEn = contacts.KievContacts.PhoneNameEn[i];
                        if (allInfo[i].PhoneNameRu != contacts.KievContacts.PhoneNameRu[i])
                            allInfo[i].PhoneNameRu = contacts.KievContacts.PhoneNameRu[i];
                        if (allInfo[i].PhoneNameUa != contacts.KievContacts.PhoneNameUa[i])
                            allInfo[i].PhoneNameUa = contacts.KievContacts.PhoneNameUa[i];
                        if (allInfo[i].PhoneNumber != contacts.KievContacts.PhoneList[i])
                            allInfo[i].PhoneNumber = contacts.KievContacts.PhoneList[i];
                    }

                    for (int i = allInfo.Count(); i < contacts.KievContacts.PhoneNameRu.Count(); i++)
                    {
                        db.KievInfoDb.Add(new DbContactsKievInfo
                        {
                            PhoneNameEn = contacts.KievContacts.PhoneNameEn[i],
                            PhoneNameRu = contacts.KievContacts.PhoneNameRu[i],
                            PhoneNameUa = contacts.KievContacts.PhoneNameUa[i],
                            PhoneNumber = contacts.KievContacts.PhoneList[i],
                        });
                    }
                }
                else
                {
                    List<int> idList = new List<int>();

                    for (int i = 0; i < allInfo.Count(); i++)
                        idList.Add(allInfo[i].Id);

                    var differences = idList.Except(contacts.KievContacts.PhoneIdList);

                    foreach (var dif in differences)
                    {
                        var temp = db.KievInfoDb.Where(x => x.Id == dif).FirstOrDefault();

                        db.KievInfoDb.Remove(temp);
                    }
                }

                if (allInfo.Count() == contacts.KievContacts.ViberNameRu.Count())
                {
                    for (int i = 0; i < contacts.KievContacts.ViberNameRu.Count(); i++)
                    {
                        if (allInfo[i].ViberNameEn != contacts.KievContacts.ViberNameEn[i])
                            allInfo[i].ViberNameEn = contacts.KievContacts.ViberNameEn[i];
                        if (allInfo[i].ViberNameRu != contacts.KievContacts.ViberNameRu[i])
                            allInfo[i].ViberNameRu = contacts.KievContacts.ViberNameRu[i];
                        if (allInfo[i].ViberNameUa != contacts.KievContacts.ViberNameUa[i])
                            allInfo[i].ViberNameUa = contacts.KievContacts.ViberNameUa[i];
                        if (allInfo[i].ViberNumber != contacts.KievContacts.ViberNumber[i])
                            allInfo[i].ViberNumber = contacts.KievContacts.ViberNumber[i];
                    }
                }
                else if (allInfo.Count() < contacts.KievContacts.ViberNameRu.Count())
                {
                    for (int i = 0; i < contacts.KievContacts.ViberNameRu.Count() - 1; i++)
                    {
                        if (allInfo[i].ViberNameEn != contacts.KievContacts.ViberNameEn[i])
                            allInfo[i].ViberNameEn = contacts.KievContacts.ViberNameEn[i];
                        if (allInfo[i].ViberNameRu != contacts.KievContacts.ViberNameRu[i])
                            allInfo[i].ViberNameRu = contacts.KievContacts.ViberNameRu[i];
                        if (allInfo[i].ViberNameUa != contacts.KievContacts.ViberNameUa[i])
                            allInfo[i].ViberNameUa = contacts.KievContacts.ViberNameUa[i];
                        if (allInfo[i].ViberNumber != contacts.KievContacts.ViberNumber[i])
                            allInfo[i].ViberNumber = contacts.KievContacts.ViberNumber[i];
                    }

                    for (int i = allInfo.Count(); i < contacts.KievContacts.ViberNameRu.Count(); i++)
                    {
                        db.KievInfoDb.Add(new DbContactsKievInfo
                        {
                            ViberNameEn = contacts.KievContacts.ViberNameEn[i],
                            ViberNameRu = contacts.KievContacts.ViberNameRu[i],
                            ViberNameUa = contacts.KievContacts.ViberNameUa[i],
                            ViberNumber = contacts.KievContacts.ViberNumber[i],
                        });
                    }
                }
                else
                {
                    List<int> idList = new List<int>();

                    for (int i = 0; i < allInfo.Count(); i++)
                        idList.Add(allInfo[i].Id);

                    var differences = idList.Except(contacts.KievContacts.ViberIdList);

                    foreach (var dif in differences)
                    {
                        var temp = db.KievInfoDb.Where(x => x.Id == dif).FirstOrDefault();

                        db.KievInfoDb.Remove(temp);
                    }
                }

                db.SaveChanges();
            }
        }

        public static void EditContactsKonstantinovkaInfo(ContactsInfoVM contacts)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var data = db.KonstantinovkaInfoDb.FirstOrDefault();

                if (data.AddressEn != contacts.KonstantinivkaContacts.AddressEn)
                    data.AddressEn = contacts.KonstantinivkaContacts.AddressEn;
                if (data.AddressRu != contacts.KonstantinivkaContacts.AddressRu)
                    data.AddressRu = contacts.KonstantinivkaContacts.AddressRu;
                if (data.AddressUa != contacts.KonstantinivkaContacts.AddressUa)
                    data.AddressUa = contacts.KonstantinivkaContacts.AddressUa;
                if (data.WorkTimeEn != contacts.KonstantinivkaContacts.WorkTimeEn)
                    data.WorkTimeEn = contacts.KonstantinivkaContacts.WorkTimeEn;
                if (data.WorkTimeRu != contacts.KonstantinivkaContacts.WorkTimeRu)
                    data.WorkTimeRu = contacts.KonstantinivkaContacts.WorkTimeRu;
                if (data.WorkTimeUa != contacts.KonstantinivkaContacts.WorkTimeUa)
                    data.WorkTimeUa = contacts.KonstantinivkaContacts.WorkTimeUa;

                var allInfo = db.KonstantinovkaInfoDb.ToList();

                if (allInfo.Count() == contacts.KonstantinivkaContacts.PhoneNameRu.Count())
                {
                    for (int i = 0; i < contacts.KonstantinivkaContacts.PhoneNameRu.Count(); i++)
                    {
                        if (allInfo[i].PhoneNameEn != contacts.KonstantinivkaContacts.PhoneNameEn[i])
                            allInfo[i].PhoneNameEn = contacts.KonstantinivkaContacts.PhoneNameEn[i];
                        if (allInfo[i].PhoneNameRu != contacts.KonstantinivkaContacts.PhoneNameRu[i])
                            allInfo[i].PhoneNameRu = contacts.KonstantinivkaContacts.PhoneNameRu[i];
                        if (allInfo[i].PhoneNameUa != contacts.KonstantinivkaContacts.PhoneNameUa[i])
                            allInfo[i].PhoneNameUa = contacts.KonstantinivkaContacts.PhoneNameUa[i];
                        if (allInfo[i].PhoneNumber != contacts.KonstantinivkaContacts.PhoneList[i])
                            allInfo[i].PhoneNumber = contacts.KonstantinivkaContacts.PhoneList[i];
                    }
                }
                else if (allInfo.Count() < contacts.KonstantinivkaContacts.PhoneNameRu.Count())
                {
                    for (int i = 0; i < contacts.KonstantinivkaContacts.PhoneNameRu.Count() - 1; i++)
                    {
                        if (allInfo[i].PhoneNameEn != contacts.KonstantinivkaContacts.PhoneNameEn[i])
                            allInfo[i].PhoneNameEn = contacts.KonstantinivkaContacts.PhoneNameEn[i];
                        if (allInfo[i].PhoneNameRu != contacts.KonstantinivkaContacts.PhoneNameRu[i])
                            allInfo[i].PhoneNameRu = contacts.KonstantinivkaContacts.PhoneNameRu[i];
                        if (allInfo[i].PhoneNameUa != contacts.KonstantinivkaContacts.PhoneNameUa[i])
                            allInfo[i].PhoneNameUa = contacts.KonstantinivkaContacts.PhoneNameUa[i];
                        if (allInfo[i].PhoneNumber != contacts.KonstantinivkaContacts.PhoneList[i])
                            allInfo[i].PhoneNumber = contacts.KonstantinivkaContacts.PhoneList[i];
                    }

                    for (int i = allInfo.Count(); i < contacts.KonstantinivkaContacts.PhoneNameRu.Count(); i++)
                    {
                        db.KonstantinovkaInfoDb.Add(new DbKonstantinovkaContactsInfo
                        {
                            PhoneNameEn = contacts.KonstantinivkaContacts.PhoneNameEn[i],
                            PhoneNameRu = contacts.KonstantinivkaContacts.PhoneNameRu[i],
                            PhoneNameUa = contacts.KonstantinivkaContacts.PhoneNameUa[i],
                            PhoneNumber = contacts.KonstantinivkaContacts.PhoneList[i],
                        });
                    }
                }
                else
                {
                    List<int> idList = new List<int>();

                    for (int i = 0; i < allInfo.Count(); i++)
                        idList.Add(allInfo[i].Id);

                    var differences = idList.Except(contacts.KonstantinivkaContacts.PhoneIdList);

                    foreach (var dif in differences)
                    {
                        var temp = db.KonstantinovkaInfoDb.Where(x => x.Id == dif).FirstOrDefault();

                        db.KonstantinovkaInfoDb.Remove(temp);
                    }
                }

                if (allInfo.Count() == contacts.KonstantinivkaContacts.ViberNameRu.Count())
                {
                    for (int i = 0; i < contacts.KonstantinivkaContacts.ViberNameRu.Count(); i++)
                    {
                        if (allInfo[i].ViberNameEn != contacts.KonstantinivkaContacts.ViberNameEn[i])
                            allInfo[i].ViberNameEn = contacts.KonstantinivkaContacts.ViberNameEn[i];
                        if (allInfo[i].ViberNameRu != contacts.KonstantinivkaContacts.ViberNameRu[i])
                            allInfo[i].ViberNameRu = contacts.KonstantinivkaContacts.ViberNameRu[i];
                        if (allInfo[i].ViberNameUa != contacts.KonstantinivkaContacts.ViberNameUa[i])
                            allInfo[i].ViberNameUa = contacts.KonstantinivkaContacts.ViberNameUa[i];
                        if (allInfo[i].ViberNumber != contacts.KonstantinivkaContacts.ViberNumber[i])
                            allInfo[i].ViberNumber = contacts.KonstantinivkaContacts.ViberNumber[i];
                    }
                }
                else if (allInfo.Count() < contacts.KonstantinivkaContacts.ViberNameRu.Count())
                {
                    for (int i = 0; i < contacts.KonstantinivkaContacts.ViberNameRu.Count() - 1; i++)
                    {
                        if (allInfo[i].ViberNameEn != contacts.KonstantinivkaContacts.ViberNameEn[i])
                            allInfo[i].ViberNameEn = contacts.KonstantinivkaContacts.ViberNameEn[i];
                        if (allInfo[i].ViberNameRu != contacts.KonstantinivkaContacts.ViberNameRu[i])
                            allInfo[i].ViberNameRu = contacts.KonstantinivkaContacts.ViberNameRu[i];
                        if (allInfo[i].ViberNameUa != contacts.KonstantinivkaContacts.ViberNameUa[i])
                            allInfo[i].ViberNameUa = contacts.KonstantinivkaContacts.ViberNameUa[i];
                        if (allInfo[i].ViberNumber != contacts.KonstantinivkaContacts.ViberNumber[i])
                            allInfo[i].ViberNumber = contacts.KonstantinivkaContacts.ViberNumber[i];
                    }

                    for (int i = allInfo.Count(); i < contacts.KonstantinivkaContacts.ViberNameRu.Count(); i++)
                    {
                        db.KonstantinovkaInfoDb.Add(new DbKonstantinovkaContactsInfo
                        {
                            ViberNameEn = contacts.KonstantinivkaContacts.ViberNameEn[i],
                            ViberNameRu = contacts.KonstantinivkaContacts.ViberNameRu[i],
                            ViberNameUa = contacts.KonstantinivkaContacts.ViberNameUa[i],
                            ViberNumber = contacts.KonstantinivkaContacts.ViberNumber[i],
                        });
                    }
                }
                else
                {
                    List<int> idList = new List<int>();

                    for (int i = 0; i < allInfo.Count(); i++)
                        idList.Add(allInfo[i].Id);

                    var differences = idList.Except(contacts.KonstantinivkaContacts.ViberIdList);

                    foreach (var dif in differences)
                    {
                        var temp = db.KonstantinovkaInfoDb.Where(x => x.Id == dif).FirstOrDefault();

                        db.KonstantinovkaInfoDb.Remove(temp);
                    }
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

                data.KievContacts = db.KievInfoDb.Select(x => new ContactsPageVM
                {
                    AddressEn = x.AddressEn,
                    AddressRu = x.AddressRu,
                    AddressUa = x.AddressUa,
                    WorkTimeEn = x.WorkTimeEn,
                    WorkTimeRu = x.WorkTimeRu,
                    WorkTimeUa = x.WorkTimeUa,
                }).FirstOrDefault();

                var kievContactsAll = db.KievInfoDb.ToList();

                data.KievContacts.PhoneNumbers = new List<List<string>>();
                //data.KievContacts.ViberInfoList = new List<ContactsPageVM.ViberInfo>();
                data.KievContacts.PhoneIdList = new List<int>();
                data.KievContacts.ViberIdList = new List<int>();
                data.KievContacts.PhoneNameEn = new List<string>();
                data.KievContacts.PhoneNameRu = new List<string>();
                data.KievContacts.PhoneNameUa = new List<string>();
                data.KievContacts.ViberNameRu = new List<string>();
                data.KievContacts.ViberNameEn = new List<string>();
                data.KievContacts.ViberNameUa = new List<string>();
                data.KievContacts.ViberNumber = new List<string>();

                foreach (var entry in kievContactsAll)
                {
                    if (entry.PhoneNumber != null)
                    {
                        if (entry.PhoneNumber.Contains("|"))
                        {
                            var temp = entry.PhoneNumber.Split('|').ToList();

                            data.KievContacts.PhoneNumbers.Add(temp);
                        }
                        else
                        {
                            List<string> temp = new List<string>();

                            temp.Add(entry.PhoneNumber);
                            data.KievContacts.PhoneNumbers.Add(temp);
                        }
                    }

                    if (entry.ViberNumber != null)
                    {
                        data.KievContacts.ViberNameRu.Add(entry.ViberNameRu);
                        data.KievContacts.ViberNameEn.Add(entry.ViberNameEn);
                        data.KievContacts.ViberNameUa.Add(entry.ViberNameUa);
                        data.KievContacts.ViberNumber.Add(entry.ViberNumber);
                    }

                    data.KievContacts.PhoneIdList.Add(entry.Id);
                    data.KievContacts.ViberIdList.Add(entry.Id);
                    data.KievContacts.PhoneNameEn.Add(entry.PhoneNameEn);
                    data.KievContacts.PhoneNameRu.Add(entry.PhoneNameRu);
                    data.KievContacts.PhoneNameUa.Add(entry.PhoneNameUa);
                }

                data.KonstantinivkaContacts = db.KonstantinovkaInfoDb.Select(x => new ContactsPageVM
                {
                    AddressEn = x.AddressEn,
                    AddressRu = x.AddressRu,
                    AddressUa = x.AddressUa,
                    WorkTimeEn = x.WorkTimeEn,
                    WorkTimeRu = x.WorkTimeRu,
                    WorkTimeUa = x.WorkTimeUa,
                }).FirstOrDefault();

                var konstantinovkaContactsAll = db.KonstantinovkaInfoDb.ToList();

                data.KonstantinivkaContacts.PhoneNumbers = new List<List<string>>();
                //data.KonstantinivkaContacts.ViberInfoList = new List<ContactsPageVM.ViberInfo>();
                data.KonstantinivkaContacts.PhoneIdList = new List<int>();
                data.KonstantinivkaContacts.ViberIdList = new List<int>();
                data.KonstantinivkaContacts.PhoneNameEn = new List<string>();
                data.KonstantinivkaContacts.PhoneNameRu = new List<string>();
                data.KonstantinivkaContacts.PhoneNameUa = new List<string>();
                data.KonstantinivkaContacts.ViberNameRu = new List<string>();
                data.KonstantinivkaContacts.ViberNameEn = new List<string>();
                data.KonstantinivkaContacts.ViberNameUa = new List<string>();
                data.KonstantinivkaContacts.ViberNumber = new List<string>();

                foreach (var entry in konstantinovkaContactsAll)
                {
                    if (entry.PhoneNumber != null)
                    {
                        if (entry.PhoneNumber.Contains("|"))
                        {
                            var temp = entry.PhoneNumber.Split('|').ToList();

                            data.KonstantinivkaContacts.PhoneNumbers.Add(temp);
                        }
                        else
                        {
                            List<string> temp = new List<string>();

                            temp.Add(entry.PhoneNumber);
                            data.KonstantinivkaContacts.PhoneNumbers.Add(temp);
                        }
                    }

                    if (entry.ViberNumber != null)
                    {
                        data.KonstantinivkaContacts.ViberNameRu.Add(entry.ViberNameRu);
                        data.KonstantinivkaContacts.ViberNameEn.Add(entry.ViberNameEn);
                        data.KonstantinivkaContacts.ViberNameUa.Add(entry.ViberNameUa);
                        data.KonstantinivkaContacts.ViberNumber.Add(entry.ViberNumber);
                    }

                    data.KonstantinivkaContacts.PhoneIdList.Add(entry.Id);
                    data.KonstantinivkaContacts.ViberIdList.Add(entry.Id);
                    data.KonstantinivkaContacts.PhoneNameEn.Add(entry.PhoneNameEn);
                    data.KonstantinivkaContacts.PhoneNameRu.Add(entry.PhoneNameRu);
                    data.KonstantinivkaContacts.PhoneNameUa.Add(entry.PhoneNameUa);
                }

                //data.KonstantinivkaContacts = db.KonstantinovkaInfoDb.Select(x => new ContactsPageVM
                //{
                //    AddressEn = x.AddressEn,
                //    AddressRu = x.AddressRu,
                //    AddressUa = x.AddressUa,
                //    PhoneNameEn = x.PhoneNameEn,
                //    PhoneNameRu = x.PhoneNameRu,
                //    PhoneNameUa = x.PhoneNameUa,
                //    PhoneNumber = x.PhoneNumber,
                //    ViberNameEn = x.ViberNameEn,
                //    ViberNameRu = x.ViberNameRu,
                //    ViberNameUa = x.ViberNameUa,
                //    ViberNumber = x.ViberNumber,
                //    WorkTimeEn = x.WorkTimeEn,
                //    WorkTimeRu = x.WorkTimeRu,
                //    WorkTimeUa = x.WorkTimeUa,
                //}).ToList();
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

                        //data.KievContacts = db.KievInfoDb.Select(x => new ContactsPageVM
                        //{
                        //    Address = x.AddressUa,
                        //    PhoneName = x.PhoneNameUa,
                        //    PhoneNumber = x.PhoneNumber,
                        //    ViberName = x.ViberNameUa,
                        //    ViberNumber = x.ViberNumber,
                        //    WorkTime = x.WorkTimeUa,
                        //}).ToList();

                        //data.KonstantinivkaContacts = db.KonstantinovkaInfoDb.Select(x => new ContactsPageVM
                        //{
                        //    Address = x.AddressUa,
                        //    PhoneName = x.PhoneNameUa,
                        //    PhoneNumber = x.PhoneNumber,
                        //    ViberName = x.ViberNameUa,
                        //    //ViberNumber = x.ViberNumber,
                        //    WorkTime = x.WorkTimeUa,
                        //}).ToList();

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

                        //data.KievContacts = db.KievInfoDb.Select(x => new ContactsPageVM
                        //{
                        //    Address = x.AddressEn,
                        //    PhoneName = x.PhoneNameEn,
                        //    PhoneNumber = x.PhoneNumber,
                        //    ViberName = x.ViberNameEn,
                        //    ViberNumber = x.ViberNumber,
                        //    WorkTime = x.WorkTimeEn,
                        //}).ToList();

                        //data.KonstantinivkaContacts = db.KonstantinovkaInfoDb.Select(x => new ContactsPageVM
                        //{
                        //    Address = x.AddressEn,
                        //    PhoneName = x.PhoneNameEn,
                        //    PhoneNumber = x.PhoneNumber,
                        //    ViberName = x.ViberNameEn,
                        //    //ViberNumber = x.ViberNumber,
                        //    WorkTime = x.WorkTimeEn,
                        //}).ToList();

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

                        //data.KievContacts = db.KievInfoDb.Select(x => new ContactsPageVM
                        //{
                        //    Address = x.AddressRu,
                        //    PhoneName = x.PhoneNameRu,
                        //    PhoneNumber = x.PhoneNumber,
                        //    ViberName = x.ViberNameRu,
                        //    ViberNumber = x.ViberNumber,
                        //    WorkTime = x.WorkTimeRu,
                        //}).ToList();

                        //data.KonstantinivkaContacts = db.KonstantinovkaInfoDb.Select(x => new ContactsPageVM
                        //{
                        //    Address = x.AddressRu,
                        //    PhoneName = x.PhoneNameRu,
                        //    PhoneNumber = x.PhoneNumber,
                        //    ViberName = x.ViberNameRu,
                        //    //ViberNumber = x.ViberNumber,
                        //    WorkTime = x.WorkTimeRu,
                        //}).ToList();

                        break;
                }
            }

            return data;
        }

        public static FeedbackVM ShowContactInfo()
        {
            FeedbackVM data = new FeedbackVM();

            data.Contacts = new ContactsInfoVM();

            data.Contacts.KievContacts = new ContactsPageVM();

            using (DataBaseContext db = new DataBaseContext())
            {
                var language = Cookie.CheckLanguageCookie();

                switch (language)
                {
                    case "uk":
                        data.Contacts.KievContacts = db.KievInfoDb.Select(x => new ContactsPageVM
                        {
                            Address = x.AddressUa,
                            WorkTime = x.WorkTimeUa,
                        }).FirstOrDefault();

                        data.Contacts.KievContacts.PhoneNumbers = new List<List<string>>();
                        data.Contacts.KievContacts.PhoneNameList = new List<string>();
                        data.Contacts.KievContacts.ViberNameList = new List<string>();
                        data.Contacts.KievContacts.ViberNumber = new List<string>();

                        var kievContactsAll = db.KievInfoDb.ToList();

                        foreach (var entry in kievContactsAll)
                        {
                            if (entry.PhoneNumber != null)
                            {
                                if (entry.PhoneNumber.Contains("|"))
                                {
                                    var temp = entry.PhoneNumber.Split('|').ToList();

                                    data.Contacts.KievContacts.PhoneNumbers.Add(temp);
                                }
                                else
                                {
                                    List<string> temp = new List<string>();

                                    temp.Add(entry.PhoneNumber);
                                    data.Contacts.KievContacts.PhoneNumbers.Add(temp);
                                }

                                data.Contacts.KievContacts.PhoneNameList.Add(entry.PhoneNameUa);
                            }

                            if (entry.ViberNumber != null)
                            {
                                data.Contacts.KievContacts.ViberNameList.Add(entry.ViberNameUa);
                                data.Contacts.KievContacts.ViberNumber.Add(entry.ViberNumber);
                            }
                        }

                        data.Contacts.KonstantinivkaContacts = db.KonstantinovkaInfoDb.Select(x => new ContactsPageVM
                        {
                            Address = x.AddressUa,
                            WorkTime = x.WorkTimeUa,
                        }).FirstOrDefault();

                        data.Contacts.KonstantinivkaContacts.PhoneNumbers = new List<List<string>>();
                        data.Contacts.KonstantinivkaContacts.PhoneNameList = new List<string>();
                        data.Contacts.KonstantinivkaContacts.ViberNameList = new List<string>();
                        data.Contacts.KonstantinivkaContacts.ViberNumber = new List<string>();

                        var konstantinovka = db.KonstantinovkaInfoDb.ToList();

                        foreach (var entry in konstantinovka)
                        {
                            if (entry.PhoneNumber != null)
                            {
                                if (entry.PhoneNumber.Contains("|"))
                                {
                                    var temp = entry.PhoneNumber.Split('|').ToList();

                                    data.Contacts.KonstantinivkaContacts.PhoneNumbers.Add(temp);
                                }
                                else
                                {
                                    List<string> temp = new List<string>();

                                    temp.Add(entry.PhoneNumber);
                                    data.Contacts.KonstantinivkaContacts.PhoneNumbers.Add(temp);
                                }

                                data.Contacts.KonstantinivkaContacts.PhoneNameList.Add(entry.PhoneNameUa);
                            }

                            if (entry.ViberNumber != null)
                            {
                                data.Contacts.KonstantinivkaContacts.ViberNameList.Add(entry.ViberNameUa);
                                data.Contacts.KonstantinivkaContacts.ViberNumber.Add(entry.ViberNumber);
                            }
                        }

                        break;
                    case "en":
                        data.Contacts.KievContacts = db.KonstantinovkaInfoDb.Select(x => new ContactsPageVM
                        {
                            Address = x.AddressEn,
                            WorkTime = x.WorkTimeEn,
                        }).FirstOrDefault();

                        data.Contacts.KievContacts.PhoneNumbers = new List<List<string>>();
                        data.Contacts.KievContacts.PhoneNameList = new List<string>();
                        data.Contacts.KievContacts.ViberNameList = new List<string>();
                        data.Contacts.KievContacts.ViberNumber = new List<string>();

                        konstantinovka = db.KonstantinovkaInfoDb.ToList();

                        foreach (var entry in konstantinovka)
                        {
                            if (entry.PhoneNumber != null)
                            {
                                if (entry.PhoneNumber.Contains("|"))
                                {
                                    var temp = entry.PhoneNumber.Split('|').ToList();

                                    data.Contacts.KievContacts.PhoneNumbers.Add(temp);
                                }
                                else
                                {
                                    List<string> temp = new List<string>();

                                    temp.Add(entry.PhoneNumber);
                                    data.Contacts.KievContacts.PhoneNumbers.Add(temp);
                                }

                                data.Contacts.KievContacts.PhoneNameList.Add(entry.PhoneNameEn);
                            }

                            if (entry.ViberNumber != null)
                            {
                                data.Contacts.KievContacts.ViberNameList.Add(entry.ViberNameEn);
                                data.Contacts.KievContacts.ViberNumber.Add(entry.ViberNumber);
                            }
                        }

                        data.Contacts.KonstantinivkaContacts = db.KonstantinovkaInfoDb.Select(x => new ContactsPageVM
                        {
                            Address = x.AddressEn,
                            WorkTime = x.WorkTimeEn,
                        }).FirstOrDefault();

                        data.Contacts.KonstantinivkaContacts.PhoneNumbers = new List<List<string>>();
                        data.Contacts.KonstantinivkaContacts.PhoneNameList = new List<string>();
                        data.Contacts.KonstantinivkaContacts.ViberNameList = new List<string>();
                        data.Contacts.KonstantinivkaContacts.ViberNumber = new List<string>();

                        konstantinovka = db.KonstantinovkaInfoDb.ToList();

                        foreach (var entry in konstantinovka)
                        {
                            if (entry.PhoneNumber != null)
                            {
                                if (entry.PhoneNumber.Contains("|"))
                                {
                                    var temp = entry.PhoneNumber.Split('|').ToList();

                                    data.Contacts.KonstantinivkaContacts.PhoneNumbers.Add(temp);
                                }
                                else
                                {
                                    List<string> temp = new List<string>();

                                    temp.Add(entry.PhoneNumber);
                                    data.Contacts.KonstantinivkaContacts.PhoneNumbers.Add(temp);
                                }

                                data.Contacts.KonstantinivkaContacts.PhoneNameList.Add(entry.PhoneNameEn);
                            }

                            if (entry.ViberNumber != null)
                            {
                                data.Contacts.KonstantinivkaContacts.ViberNameList.Add(entry.ViberNameEn);
                                data.Contacts.KonstantinivkaContacts.ViberNumber.Add(entry.ViberNumber);
                            }
                        }

                        break;
                    default:
                        data.Contacts.KievContacts = db.KievInfoDb.Select(x => new ContactsPageVM
                        {
                            Address = x.AddressRu,
                            WorkTime = x.WorkTimeRu,
                        }).FirstOrDefault();

                        data.Contacts.KievContacts.PhoneNumbers = new List<List<string>>();
                        data.Contacts.KievContacts.PhoneNameList = new List<string>();
                        data.Contacts.KievContacts.ViberNameList = new List<string>();
                        data.Contacts.KievContacts.ViberNumber = new List<string>();

                        kievContactsAll = db.KievInfoDb.ToList();

                        foreach (var entry in kievContactsAll)
                        {
                            if (entry.PhoneNumber != null)
                            {
                                if (entry.PhoneNumber.Contains("|"))
                                {
                                    var temp = entry.PhoneNumber.Split('|').ToList();

                                    data.Contacts.KievContacts.PhoneNumbers.Add(temp);
                                }
                                else
                                {
                                    List<string> temp = new List<string>();

                                    temp.Add(entry.PhoneNumber);
                                    data.Contacts.KievContacts.PhoneNumbers.Add(temp);
                                }

                                data.Contacts.KievContacts.PhoneNameList.Add(entry.PhoneNameRu);
                            }

                            if (entry.ViberNumber != null)
                            {
                                data.Contacts.KievContacts.ViberNameList.Add(entry.ViberNameRu);
                                data.Contacts.KievContacts.ViberNumber.Add(entry.ViberNumber);
                            }
                        }

                        data.Contacts.KonstantinivkaContacts = db.KievInfoDb.Select(x => new ContactsPageVM
                        {
                            Address = x.AddressRu,
                            WorkTime = x.WorkTimeRu,
                        }).FirstOrDefault();

                        data.Contacts.KonstantinivkaContacts.PhoneNumbers = new List<List<string>>();
                        data.Contacts.KonstantinivkaContacts.PhoneNameList = new List<string>();
                        data.Contacts.KonstantinivkaContacts.ViberNameList = new List<string>();
                        data.Contacts.KonstantinivkaContacts.ViberNumber = new List<string>();

                        kievContactsAll = db.KievInfoDb.ToList();

                        foreach (var entry in kievContactsAll)
                        {
                            if (entry.PhoneNumber != null)
                            {
                                if (entry.PhoneNumber.Contains("|"))
                                {
                                    var temp = entry.PhoneNumber.Split('|').ToList();

                                    data.Contacts.KonstantinivkaContacts.PhoneNumbers.Add(temp);
                                }
                                else
                                {
                                    List<string> temp = new List<string>();

                                    temp.Add(entry.PhoneNumber);
                                    data.Contacts.KonstantinivkaContacts.PhoneNumbers.Add(temp);
                                }

                                data.Contacts.KonstantinivkaContacts.PhoneNameList.Add(entry.PhoneNameRu);
                            }

                            if (entry.ViberNumber != null)
                            {
                                data.Contacts.KonstantinivkaContacts.ViberNameList.Add(entry.ViberNameRu);
                                data.Contacts.KonstantinivkaContacts.ViberNumber.Add(entry.ViberNumber);
                            }
                        }

                        break;
                }
            }

            return data;
        }
    }
}