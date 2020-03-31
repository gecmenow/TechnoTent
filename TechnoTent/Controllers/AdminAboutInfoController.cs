using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnoTent.Models;
using TechnoTent.Models.ViewModel;

namespace TechnoTent.Controllers
{
    public class AdminAboutInfoController : Controller
    {
        // GET: AdminAboutInfo
        public ActionResult Index()
        {
            var data = AboutInfo.GetInfo();

            return View(data);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditInfo(CompanyVM info)
        {
            AboutInfo.EditInfo(info);

            return RedirectToAction("Index");
        }
    }
}