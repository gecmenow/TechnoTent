using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using TechnoTent.Filters;
using TechnoTent.Models;
using TechnoTent.Models.ViewModel.Admin;

namespace TechnoTent.Controllers
{
    [AdminAuth]
    public class AdminItemsController : Controller
    {
        // GET: AdminItems
        public ActionResult Index(int? page)
        {
            var data = AdminItems.GetAllItems();

            int pageSize = 12;
            int pageNumber = (page ?? 1);

            return View(data.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult GetItemsByCategory(int? page, string category)
        {
            var data = AdminItems.GetItemsByCategory(category);

            int pageSize = 12;
            int pageNumber = (page ?? 1);

            return View(data.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult AddItem()
        {
            var data = AdminItems.GetItemCategories();

            return View(data);
        }

        [HttpPost]
        public ActionResult AddItem(AdminItemVM item)
        {
            //if (ModelState.IsValid)
            //{
                AdminItems.AddItem(item);

                return RedirectToAction("Index");
            //}

            return View();
        }

        public ActionResult EditItem(string vendorCode)
        {
            var data = AdminItems.GetItemById(vendorCode);

            return View(data);
        }

        [HttpPost]
        public ActionResult EditItem(AdminItemVM item, IEnumerable<HttpPostedFileBase> uploads)
        {
            AdminItems.EditItem(item, uploads);

            return RedirectToAction("Index");
        }

        public ActionResult ChangeItemStatus(int id, bool status)
        {
            AdminItems.ChangeItemStatus(id, status);

            //var data = AdminItems.GetAllItems();

            return PartialView("decoy");
        }

        public ActionResult ChangeItemStockStatus(int id, bool status)
        {
            AdminItems.ChangeItemStockStatus(id, status);

            //var data = AdminItems.GetAllItems();

            return PartialView("decoy");
        }

        public ActionResult DeleteItem(int id)
        {
            AdminItems.DeleteItemById(id);

            var data = AdminItems.GetAllItems();

            return PartialView(data);
        }

        public ActionResult DeleteImage(string vendorCode, string imageName)
        {
            Image.DeleteImageByName(vendorCode, imageName);

            var data = AdminItems.GetItemById(vendorCode);

            return PartialView(data);
        }
    }
}