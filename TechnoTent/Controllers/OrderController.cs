using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TechnoTent.Filters;
using TechnoTent.Models;
using TechnoTent.Models.InTimeAPI;
using TechnoTent.Models.NovaPoshtaAPI;
using TechnoTent.Models.ViewModel;

namespace TechnoTent.Controllers
{
    [Culture]
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        { 
            var data = Order.GetPreOrderInfo();

            return View(data);
        }

        [HttpPost]
        public ActionResult Index(OrderVM orderVM)
        {
            if (User.Identity.IsAuthenticated)
            {
                var sessionId = Convert.ToInt32(User.Identity.Name);

                orderVM.UserId = sessionId;
            }

            Order.AddOrder(orderVM);

            Cart.ClearCart();

            Cookies.OrderCookie.SetOrderCookie();

            return Redirect(Url.Content("~/"));
        }

        public async Task<ViewResult> GetNPCities(string city)
        {
            OrderVM orderVM = new OrderVM
            {
                NovaPoshtaCities = await NovaPoshtaCity.SendRequestToAPIAsync(city)
            };

            return View(orderVM);
        }

        public async Task<ViewResult> GetNPCityPostOffice(string cityId)
        {
            OrderVM orderVM = new OrderVM
            {
                NovaPoshtaCitiePostOffice = await NovaPoshtaPostOffice.SendRequestToAPIAsync(cityId)
            };

            return View(orderVM);
        }

        public async Task<ViewResult> GetInTimeCities(string city)
        {
            OrderVM orderVM = new OrderVM
            {
                InTimeCiites = await InTimeCity.SendRequestToAPIAsync(city)
            };

            return View(orderVM);
        }

        public async Task<ViewResult> GetInTimeCityPostOffice(string cityId)
        {
            OrderVM orderVM = new OrderVM
            {
                InTimeCitiePostOffice = await InTimePostOffice.SendRequestToAPIAsync(cityId)
            };

            return View(orderVM);
        }
    }
}