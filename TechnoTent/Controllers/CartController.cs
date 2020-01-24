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
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            var data = Cart.ShowCart();

            return View(data);
        }

        public ActionResult AddToCart(string vendorCode, string count)
        {
            if (!Cart.CheckItemInCart(vendorCode))
            {
                Cart.AddToCart(vendorCode, count);

                ViewBag.Count = Cart.GetCartItemsCount().ItemsCount;

                return PartialView("Decoy");
            }
            else
                return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(string vendorCode)
        {
            CartVM data = new CartVM();

            data = Cart.RemoveFromCart(vendorCode);

            if(User.Identity.IsAuthenticated)
                data = Cart.ShowCart();

            return PartialView(data);
        }

        public ActionResult EditItemCount(string vendorCode, double count)
        {
            Cart.EditItemCount(vendorCode, count);

            //var data = Cart.ShowCart();

            return PartialView("Decoy");
        }

        public ActionResult ItemCount()
        {
            var data = Cart.GetCartItemsCount();

            return PartialView(data);
        }
    }
}