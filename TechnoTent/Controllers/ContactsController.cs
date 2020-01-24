using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnoTent.Filters;
using TechnoTent.Mailing;
using TechnoTent.Models;
using TechnoTent.Models.ViewModel;

namespace TechnoTent.Controllers
{
    [Culture]
    public class ContactsController : Controller
    {
        // GET: Contacts
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FeedbackVM feedbackVM)
        {
            if (ModelState.IsValid)
            {
                Feedback.AddFeedback(feedbackVM);

                //FeedbackMail.SendMail(feedbackVM);

                return RedirectToAction("Index");
            }

            return View(feedbackVM);
        }
    }
}