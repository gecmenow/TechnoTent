using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnoTent.Filters;
using TechnoTent.Models;
using TechnoTent.Models.ViewModel;

namespace TechnoTent.Controllers
{
    [Culture]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var data = Home.GetImages();

            return View(data);
        }

        public ActionResult BackCall(BackCallVM backCall)
        {
            Mailing.BackCall.SendMail(backCall);

            return RedirectToAction("Index");
        }
    }
}