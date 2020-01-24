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
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index(int? page)
        {
            var news = News.GetNews();

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(news.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult GetNewsById(int id)
        {
            var news = News.GetNewsById(id);

            return View(news);
        }
    }
}