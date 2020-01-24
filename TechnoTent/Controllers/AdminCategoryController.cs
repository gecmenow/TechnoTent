using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnoTent.Models;
using TechnoTent.Models.ViewModel.Admin;

namespace TechnoTent.Controllers
{
    public class AdminCategoryController : Controller
    {
        // GET: AdminCategory
        public ActionResult Index()
        {
            var data = AdminCategoryAndSub.GetCategoryAndSub();

            return View(data);
        }

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(AdminCategoryVM adminCategoryVM, HttpPostedFileBase upload)
        {
            AdminCategoryAndSub.AddCategory(adminCategoryVM, upload);

            return RedirectToAction("Index");
        }

        public ActionResult EditCategory(int categoryId)
        {
            var data = AdminCategoryAndSub.GetCategory(categoryId);

            return View(data);
        }

        [HttpPost]
        public ActionResult EditCategory(AdminCategoryVM adminCategoryVM, HttpPostedFileBase upload)
        {
            AdminCategoryAndSub.EditCategory(adminCategoryVM, upload);

            return RedirectToAction("Index");
        }

        public ActionResult AddSubCategory()
        {
            var data = AdminCategoryAndSub.GetCategories();

            return View(data);
        }

        [HttpPost]
        public ActionResult AddSubCategory(AdminSubCategoryVM adminSubCategoryVM)
        {
            AdminCategoryAndSub.AddSubCategory(adminSubCategoryVM);

            return RedirectToAction("Index");
        }

        public ActionResult EditSubCategory(int subCategoryId)
        {
            var data = AdminCategoryAndSub.GetSubCategory(subCategoryId);

            return View(data);
        }

        [HttpPost]
        public ActionResult EditSubCategory(AdminSubCategoryVM adminSubCategoryVM)
        {
            AdminCategoryAndSub.EditSubCategory(adminSubCategoryVM);

            return RedirectToAction("Index");
        }

        public ActionResult RemoveCategory(int categoryId)
        {
            AdminCategoryAndSub.RemoveCategory(categoryId);

            var data = AdminCategoryAndSub.GetCategoryAndSub();

            return PartialView(data);
        }

        public ActionResult RemoveSubCategory(int subCategoryId)
        {
            AdminCategoryAndSub.RemoveSubCategory(subCategoryId);

            var data = AdminCategoryAndSub.GetCategoryAndSub();

            return PartialView(data);
        }
    }
}