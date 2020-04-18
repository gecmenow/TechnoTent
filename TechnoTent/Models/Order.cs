using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnoTent.Cookies;
using TechnoTent.Models.DataBase;
using TechnoTent.Models.UserModels;
using TechnoTent.Models.ViewModel;

namespace TechnoTent.Models
{
    public class Order
    {
        public static OrderVM GetPreOrderInfo()
        {
            OrderVM order = new OrderVM();

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                int userId = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                using (DataBaseContext db = new DataBaseContext())
                {
                    var user = db.UserDb.Where(u => u.Id == userId).First();

                    order.UserEmail = user.Email;
                    order.UserId = user.Id;
                    order.UserName = user.Name;
                    order.UserPhone = user.Phone;
                }
            }
            var cart = Cart.ShowCart();

            order.TotalPrice = cart.TotalCost;

            return order;
        }

        //public static void AddOrder(OrderVM order, string itemVendorCode)
        //{
        //    string itemsCount = "1";
        //    string itemsPrice = "";
        //    int totalItemsCount = 1;

        //    var language = Cookie.CheckLanguageCookie();

        //    using (DataBaseContext db = new DataBaseContext())
        //    {
        //        string orderNumber = "000001";

        //        try
        //        {
        //            orderNumber = db.ItemsDb.OrderByDescending(u => u.VendorCode).First().VendorCode;

        //            int number = Convert.ToInt32(orderNumber) + 1;

        //            orderNumber = number.ToString();

        //            for (int i = orderNumber.Length; i < 6; i++)
        //                orderNumber = orderNumber.PadLeft(orderNumber.Length + 1, '0');
        //        }
        //        catch (Exception)
        //        { }

        //        db.OrderDb.Add(
        //            new DbOrder
        //            {
        //                OrderNumber = orderNumber,
        //                DeliveryCity = order.DeliveryCity,
        //                DeliveryMethod = order.DeliveryMethod,
        //                DeliveryOffice = order.DeliveryOffice,
        //                OrderStatus = "В обработке",
        //                PaymentStatus = "Не оплачено",
        //                ItemsVendorCode = itemVendorCode,
        //                ItemsPrice = itemsPrice,
        //                TotalPrice = 0,
        //                TotalitemsCount = totalItemsCount,
        //                ItemsCount = itemsCount,
        //                UserEmail = order.UserEmail,
        //                UserId = order.UserId,
        //                UserName = order.UserName,
        //                UserPhone = order.UserPhone,
        //                OrderLanguage = language,
        //                Date = DateTime.Now,
        //            });

        //        db.SaveChanges();
        //    }
        //}

        public static string AddOrder(OrderVM order)
        {
            var data = Cart.ShowCart();

            string itemsVendorCode = "";
            string itemsCount = "";
            string itemsPrice = "";
            int totalItemsCount = 0;

            foreach(var cart in data.CartItems)
            {
                itemsVendorCode += cart.VendorCode + "/";
                itemsCount += cart.ItemCount + "/";
                itemsPrice += cart.ItemPrice + "/";
                totalItemsCount += 1;

                Cart.RemoveFromCart(cart.VendorCode);
            }

            var language = Cookie.CheckLanguageCookie();

            string orderNumber = "000001";

            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    orderNumber = db.OrderDb.OrderByDescending(u=>u.OrderNumber).First().OrderNumber;

                    int number = Convert.ToInt32(orderNumber) + 1;

                    orderNumber = number.ToString();

                    for (int i = orderNumber.Length; i < 6; i++)
                        orderNumber = orderNumber.PadLeft(orderNumber.Length + 1, '0');
                }
                catch (Exception)
                { }

                db.OrderDb.Add(
                    new DbOrder
                    {
                        OrderNumber = orderNumber,
                        DeliveryCity = order.DeliveryCity,
                        DeliveryMethod = order.DeliveryMethod,
                        DeliveryOffice = order.DeliveryOffice,
                        OrderStatus = "В обработке",
                        PaymentStatus = "Не оплачено",
                        ItemsVendorCode = itemsVendorCode,
                        ItemsPrice = itemsPrice,
                        TotalPrice = data.TotalCost,
                        TotalitemsCount = totalItemsCount,
                        ItemsCount = itemsCount,
                        UserEmail = order.UserEmail,
                        UserId = order.UserId,
                        UserName = order.UserName,
                        UserPhone = order.UserPhone,
                        OrderLanguage = language,
                        Comment = order.Comment,
                        Date = DateTime.Now,
                    });

                db.SaveChanges();
            }

            return orderNumber;
        }

        public static OrderVM GetOrderById(string orderNumber)
        {
            OrderVM data = new OrderVM();

            using (DataBaseContext db = new DataBaseContext())
            {
                data = db.OrderDb.Where(u => u.OrderNumber == orderNumber).Select(u => new OrderVM
                {
                    Id = u.Id,
                    OrderNumber = u.OrderNumber,
                    UserName = u.UserName,
                    UserEmail = u.UserEmail,
                    UserPhone = u.UserPhone,
                    DeliveryCity = u.DeliveryCity,
                    DeliveryOffice = u.DeliveryOffice,
                    DeliveryMethod = u.DeliveryMethod,
                    PaymentMethod = u.PaymentMethod,
                    PaymentStatus = u.PaymentStatus,
                    TotalPrice = u.TotalPrice,
                    TotalItemsCount = u.TotalitemsCount,
                    ItemsCount = u.ItemsCount,
                    OrderStatus = u.OrderStatus,
                    Date = u.Date,
                    ItemsVendorCode = u.ItemsVendorCode,
                    ItemsPrice = u.ItemsPrice,
                    OrderLanguage = u.OrderLanguage,
                    Comment = u.Comment,
                }).FirstOrDefault();

                List<string> itemsPriceList = new List<string>();
                List<string> itemsCount = new List<string>();

                List<OrderItemsVM> orderItems = new List<OrderItemsVM>();

                data.ItemsVendorCodeList = data.ItemsVendorCode.Split('/').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                itemsPriceList = data.ItemsPrice.Split('/').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                itemsCount = data.ItemsCount.Split('/').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                //чек на язык
                for (int i = 0; i < data.ItemsVendorCodeList.Count(); i++)
                {
                    var itemVendoreCode = data.ItemsVendorCodeList[i];

                    var item = db.ItemsDb.Where(u => u.VendorCode == itemVendoreCode).FirstOrDefault();

                    double itemMinOrder = 0;

                    if (item.ProductBuyTypeMeter)
                        itemMinOrder = item.Width;
                    else
                        itemMinOrder = 1;

                    try
                    {
                        //чек на язык
                        orderItems.Add(new OrderItemsVM
                        {
                            ItemName = item.NameRu,
                            ItemImages = item.Image1,
                            ItemPrice = itemsPriceList[i],
                            ItemCount = itemsCount[i],
                            ItemVendorCode = data.ItemsVendorCodeList[i],
                            ItemMinOrder = itemMinOrder.ToString(),
                            ProductBuyTypeMeter = item.ProductBuyTypeMeter,
                        });
                    }
                    catch (Exception e)
                    { }

                    data.Items = orderItems;
                }
            }

            return data;
        }

        public static List<OrderVM> GetOrders(int id)
        {
            List<OrderVM> orders = new List<OrderVM>();

            using (DataBaseContext db = new DataBaseContext())
            {
                orders = db.OrderDb.Where(u => u.UserId == id).Select(u => new OrderVM
                {
                    OrderNumber = u.OrderNumber,
                    UserName = u.UserName,
                    UserEmail = u.UserEmail,
                    UserPhone = u.UserPhone,
                    DeliveryCity = u.DeliveryCity,
                    DeliveryOffice = u.DeliveryOffice,
                    DeliveryMethod = u.DeliveryMethod,
                    PaymentMethod = u.PaymentMethod,
                    TotalPrice = u.TotalPrice,
                    TotalItemsCount = u.TotalitemsCount,
                    ItemsCount = u.ItemsCount,
                    OrderStatus = u.OrderStatus,
                    Date = u.Date,
                    ItemsVendorCode = u.ItemsVendorCode,
                    ItemsPrice = u.ItemsPrice,
                    Comment = u.Comment,
                }).ToList();

                List<string> itemsPriceList = new List<string>();
                List<string> itemsCount = new List<string>();

                foreach (var item in orders)
                {
                    List<OrderItemsVM> orderItems = new List<OrderItemsVM>();

                    item.ItemsVendorCodeList = item.ItemsVendorCode.Split('/').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                    itemsPriceList = item.ItemsPrice.Split('/').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                    itemsCount = item.ItemsPrice.Split('/').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                    //чек на язык
                    for (int i = 0; i < item.ItemsVendorCodeList.Count(); i++)
                    {
                        var itemVendoreCode = item.ItemsVendorCodeList[i];
                        //чек на язык
                        orderItems.Add(new OrderItemsVM
                        {
                            ItemName = db.ItemsDb.Where(u => u.VendorCode == itemVendoreCode).FirstOrDefault().NameEn,
                            ItemImages = db.ItemsDb.Where(u => u.VendorCode == itemVendoreCode).FirstOrDefault().Image1,
                            ItemPrice = itemsPriceList[i],
                            ItemCount = itemsCount[i],
                        });

                        item.Items = orderItems;

                        //item.ItemsNameList.Add(db.ItemsDb.Where(u => u.VendorCode == vendorCode).FirstOrDefault().NameEn);
                        //item.ItemsImagesList.Add(db.ItemsDb.Where(u => u.VendorCode == itemsList).FirstOrDefault().Image1);
                    }  
                }

                //orders = db.OrderDb.Where(u => u.UserId == id)
                //    .Select(u => new OrderVM
                //    {
                //        OrderNumber = u.OrderNumber,
                //        UserName = u.UserName,
                //        UserEmail = u.UserEmail,
                //        UserPhone = u.UserPhone,
                //        DeliveryCity = u.DeliveryCity,
                //        DeliveryOffice = u.DeliveryOffice,
                //        DeliveryMethod = u.DeliveryMethod,
                //        PaymentMethod = u.PaymentMethod,
                //        TotalPrice = u.TotalPrice,
                //        OrderStatus = u.OrderStatus,
                //        Date = u.Date,
                //    }).ToList();
            }

            return orders;
        }
    }
}