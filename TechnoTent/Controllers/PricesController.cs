using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnoTent.Models;

namespace TechnoTent.Controllers
{
    public class PricesController : Controller
    {
        // GET: Prices
        public ActionResult Index()
        {
            var data = Prices.GetPrices();

            return View(data);
        }
    }
}