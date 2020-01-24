using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TechnoTent.Filters;
using TechnoTent.Models.ViewModel.Items;

namespace TechnoTent.Controllers
{
    [Culture]
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index(string categoryUrl)
        {
            return RedirectToAction("Index", "Items", new { categoryUrl });
        }
    }
}