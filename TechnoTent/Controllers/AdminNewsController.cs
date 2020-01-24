using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnoTent.Filters;
using TechnoTent.Models;
using TechnoTent.Models.DataBase;
using TechnoTent.Models.ViewModel.Admin;

namespace TechnoTent.Controllers
{
    [AdminAuth]
    public class AdminNewsController : Controller
    {
        // GET: AdminNews
        public ActionResult Index(int? page)
        {
            var data = AdminNews.GetNews();

            int pageSize = 12;
            int pageNumber = (page ?? 1);

            return View(data.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult AddNews()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AddNews(AdminNewsVM news, HttpPostedFileBase upload)
        {
            AdminNews.AddNews(news, upload);

            return RedirectToAction("Index");
        }

        public ActionResult EditNews(int id)
        {
            var data = AdminNews.GetNewsById(id);

            return View(data);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditNews(AdminNewsVM news, HttpPostedFileBase upload)
        {
            AdminNews.EditNews(news, upload);

            return RedirectToAction("Index");
        }

        public ActionResult RemoveNews(int id)
        {
            AdminNews.RemoveNews(id);

            var data = AdminNews.GetNews();

            return PartialView(data);
        }
    }
}