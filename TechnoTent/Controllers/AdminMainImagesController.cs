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
    public class AdminMainImagesController : Controller
    {
        // GET: AdminMainImages
        public ActionResult Index()
        {
            var data = AdminMainImages.GetImages();

            return View(data);
        }
        //public ActionResult AddImages()
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult AddImages(MainImagesVM img)
        {
            if (ModelState.IsValid)
            {
                AdminMainImages.AddImages(img);

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult MovePositionUp(int orderNumber)
        {
            AdminMainImages.UpImageOrderNumber(orderNumber);

            var data = AdminMainImages.GetImages();

            return PartialView(data);
        }

        public ActionResult MovePositionDown(int orderNumber)
        {
            AdminMainImages.DownImageOrderNumber(orderNumber);

            var data = AdminMainImages.GetImages();

            return PartialView(data);
        }

        public ActionResult DeleteImage(int imageId)
        {
            AdminMainImages.DeleteImage(imageId);

            var data = AdminMainImages.GetImages();

            return PartialView(data);
        }
    }
}