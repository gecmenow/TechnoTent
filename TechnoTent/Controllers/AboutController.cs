using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnoTent.Filters;
using TechnoTent.Models;

namespace TechnoTent.Controllers
{
    [Culture]
    public class AboutController : Controller
    {
        // GET: Adout
        public ActionResult Index()
        {
            var data = Company.GetInfo();

            return View(data);
        }
    }
}