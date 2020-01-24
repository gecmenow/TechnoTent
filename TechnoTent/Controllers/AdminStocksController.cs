using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnoTent.Filters;
using TechnoTent.Models;
using TechnoTent.Models.ViewModel.Admin;

namespace TechnoTent.Controllers
{
    [AdminAuth]
    public class AdminStocksController : Controller
    {
        // GET: AdminStocks
        public ActionResult Index(int? page)
        {
            var data = AdminStocks.GetStocks();

            int pageSize = 12;
            int pageNumber = (page ?? 1);

            return View(data.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult AddStocks()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AddStocks(AdminStocksVM stocks, HttpPostedFileBase upload)
        {
            AdminStocks.AddStocks(stocks, upload);

            return RedirectToAction("Index");
        }

        public ActionResult EditStocks(int id)
        {
            var data = AdminStocks.GetStocksById(id);

            return View(data);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditStocks(AdminStocksVM stocks, HttpPostedFileBase upload)
        {
            AdminStocks.EditStocks(stocks, upload);

            return RedirectToAction("Index");
        }

        public ActionResult RemoveStocks(int id)
        {
            AdminStocks.RemoveStocks(id);

            var data = AdminStocks.GetStocks();

            return PartialView(data);
        }
    }
}