using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.ViewModel
{
    public class ContactsInfoVM
    {
        public FooterInfoVM Footer { get; set; }
        public List<ContactsVM> Contacts { get; set; }
        public List<HeaderInfoVM> HeaderInfo { get; set; }

        public ContactsPageVM KievContacts { get; set; }
        public ContactsInfoVM KievContacts1 { get; set; }
        public ContactsPageVM KonstantinivkaContacts { get; set; }
    }
}