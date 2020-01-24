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
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult Index(string vendorCode)
        {
            var item = Item.GetItem(vendorCode);

            return View(item);
        }
    }
}