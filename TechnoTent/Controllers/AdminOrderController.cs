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
    public class AdminOrderController : Controller
    {
        // GET: AdminOrder
        public ActionResult Index(int? page)
        {
            var data = AdminOrders.GetOrders();

            int pageSize = 12;
            int pageNumber = (page ?? 1);

            return View(data.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult AddItemToOrder(int orderId, string vendorCode)
        {
            AdminOrders.AddItemToOrder(orderId, vendorCode);

            var data = AdminOrders.GetOrder(orderId);

            return View(data);
        }

        public ActionResult EditOrder(int id)
        {
            var data = AdminOrders.GetOrder(id);

            return View(data);
        }

        [HttpPost]
        public ActionResult EditOrder(OrderVM order)
        {
            AdminOrders.EditOrder(order);

            var data = AdminOrders.GetOrder(order.Id);

            return View(data);
        }

        public ActionResult ChangeItemStatus(int id, string status)
        {
            AdminOrders.ChangeItemStatus(id, status);

            //var data = AdminItems.GetAllItems();

            return PartialView("decoy");
        }

        public ActionResult DelteOrderItem(int orderId, string vendorCode)
        {
            AdminOrders.DelteOrderItem(orderId, vendorCode);

            var data = AdminOrders.GetOrder(orderId);

            return View(data);
        }

        public ActionResult RemoveOrder(int orderId, int? page)
        {
            AdminOrders.DelteOrder(orderId);

            var data = AdminOrders.GetOrders();

            int pageSize = 12;
            int pageNumber = (page ?? 1);

            return PartialView(data.ToPagedList(pageNumber, pageSize));
        }
    }
}