using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnoTent.Filters;
using TechnoTent.Models;
using TechnoTent.Models.ViewModel;

namespace TechnoTent.Controllers
{
    [AdminAuth]
    public class AdminReviewsController : Controller
    {
        // GET: AdminReviews
        public ActionResult Index(int? page)
        {
            var data = Review.GetReviews();

            int pageSize = 12;
            int pageNumber = (page ?? 1);

            return View(data.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public ActionResult Index(ReviewVM review)
        {
            AdminReviews.AnswerReview(review);

            return RedirectToAction("Index");
        }

        public ActionResult DeleteReview(int id)
        {
            AdminReviews.DeleteReview(id);

            return RedirectToAction("Index");
        }
    }
}