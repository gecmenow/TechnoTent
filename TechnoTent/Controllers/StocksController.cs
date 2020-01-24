using PagedList;
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
    public class StocksController : Controller
    {
        // GET: Stocks
        public ActionResult Index(int? page)
        {
            var stocks = Stocks.GetStocks();

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(stocks.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult GetStocksById(int id)
        {
            var stocks = Stocks.GetStocksById(id);

            return View(stocks);
        }
    }
}