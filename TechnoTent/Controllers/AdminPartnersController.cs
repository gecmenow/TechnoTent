using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnoTent.Models;
using TechnoTent.Models.ViewModel;

namespace TechnoTent.Controllers
{
    public class AdminPartnersController : Controller
    {
        // GET: AdminPartners
        public ActionResult Index()
        {
            var data = AdminPartners.GetImages();

            return View(data);
        }

        [HttpPost]
        public ActionResult AddImages(PartnersVM img)
        {
            if (ModelState.IsValid)
            {
                AdminPartners.AddImages(img);

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult MovePositionUp(int orderNumber)
        {
            AdminPartners.UpImageOrderNumber(orderNumber);

            var data = AdminPartners.GetImages();

            return PartialView(data);
        }

        public ActionResult MovePositionDown(int orderNumber)
        {
            AdminPartners.DownImageOrderNumber(orderNumber);

            var data = AdminPartners.GetImages();

            return PartialView(data);
        }

        public ActionResult DeleteImage(int imageId)
        {
            AdminPartners.DeleteImage(imageId);

            var data = AdminPartners.GetImages();

            return PartialView(data);
        }
    }
}