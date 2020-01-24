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
    [Culture]
    public class ReviewsController : Controller
    {
        // GET: Reviews
        public ActionResult Index(int? page)
        {
            var data = Review.GetReviews();

            int pageSize = 12;
            int pageNumber = (page ?? 1);

            return View(data.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public ActionResult Index(ReviewVM reviewVM)
        {
            if (User.Identity.IsAuthenticated)
            {
                var session = User.Identity.Name;

                if (ModelState.IsValid)
                    Review.AddReview(reviewVM, session);

                return RedirectToAction("Index");
            }

            return View(reviewVM);
        }

        public bool CheckLoggedIn()
        {
            bool status = false;

            if (User.Identity.IsAuthenticated)
                status = true;

            return status;

        }
    }
}