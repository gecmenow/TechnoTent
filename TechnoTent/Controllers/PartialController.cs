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
    public class PartialController : Controller
    {
        [ChildActionOnly] // action cannot be requested directly via URL
        public ActionResult GetCategories()
        {
            var data = Category.GetMainCategories();

            return PartialView(data);
        }

        [ChildActionOnly] // action cannot be requested directly via URL
        public ActionResult GetCategoriesAndSubCategories()
        {
            var data = Category.GetCategories();

            return PartialView(data);
        }

        [ChildActionOnly] // action cannot be requested directly via URL
        public ActionResult GetCategoriesAndSubCategoriesForAdmin()
        {
            var data = Category.GetCategories();

            return PartialView(data);
        }

        [ChildActionOnly] // action cannot be requested directly via URL
        public ActionResult GetItemsCount()
        {
            var data = Cart.GetCartItemsCount();

            return PartialView(data);
        }

        [ChildActionOnly] // action cannot be requested directly via URL
        public ActionResult GetStocks()
        {
            var data = Stocks.GetStocks();

            return PartialView(data);
        }

        [ChildActionOnly] // action cannot be requested directly via URL
        public ActionResult GetNews()
        {
            var data = News.GetNews();

            return PartialView(data);
        }

        [ChildActionOnly] // action cannot be requested directly via URL
        public ActionResult GetExchange()
        {
            var data = Exchange.GetExchange();

            return PartialView(data);
        }

        [ChildActionOnly] // action cannot be requested directly via URL
        public ActionResult CheckLoggedIn()
        {
            var data = Models.User.CheckLoggedIn();

            return PartialView(data);
        }

        [ChildActionOnly] // action cannot be requested directly via URL
        public ActionResult HeaderContacts()
        {
            var data = MainContacts.ShowInfo();

            return PartialView(data);
        }

        [ChildActionOnly] // action cannot be requested directly via URL
        public ActionResult FooterContacts()
        {
            var data = MainContacts.ShowInfo();

            return PartialView(data);
        }

        [ChildActionOnly] // action cannot be requested directly via URL
        public ActionResult Contacts()
        {
            var data = MainContacts.ShowInfo();

            return PartialView(data);
        }
    }
}