using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnoTent.Models;
using TechnoTent.Models.ViewModel;

namespace TechnoTent.Controllers
{
    public class AdminPricesController : Controller
    {
        // GET: AdminPrices
        public ActionResult Index()
        {
            var data = Prices.GetPrices();

            return View(data);
        }

        public ActionResult AddPrices(PricesVM prices, HttpPostedFileBase upload)
        {
            Prices.AddPrices(prices, upload);

            return RedirectToAction("Index");
        }

        public ActionResult DeletePrices(int id)
        {
            Prices.DeletePrice(id);

            var data = Prices.GetPrices();

            return PartialView(data);
        }
    }
}