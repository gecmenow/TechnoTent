using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnoTent.Models;
using TechnoTent.Models.ViewModel;

namespace TechnoTent.Controllers
{
    public class AdminMainContactsController : Controller
    {
        // GET: AdminMainContacts
        public ActionResult Index()
        {
            var data = MainContacts.AdminShowInfo();

            return View(data);
        }

        public ActionResult EditHeaderInfo(ContactsInfoVM info)
        {
            MainContacts.EditHeaderContacts(info);

            return RedirectToAction("Index");
        }

        public ActionResult EditFooterInfo(ContactsInfoVM info)
        {
            MainContacts.EditFooterContacts(info);

            return RedirectToAction("Index");
        }

        public ActionResult EditContactsInfo(ContactsInfoVM info)
        {
            MainContacts.EditContactsContacts(info);

            return RedirectToAction("Index");
        }

        public ActionResult EditContactsKievInfo(ContactsInfoVM info)
        {
            MainContacts.EditContactsKievInfo(info);

            return RedirectToAction("Index");
        }
        public ActionResult EditContactsKonstantinovkaInfo(ContactsInfoVM info)
        {
            MainContacts.EditContactsKonstantinovkaInfo(info);

            return RedirectToAction("Index");
        }
    }
}