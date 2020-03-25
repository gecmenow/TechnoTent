using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnoTent.Cookies;
using TechnoTent.Models.DataBase;
using TechnoTent.Models.ViewModel;

namespace TechnoTent.Models
{
    public class AdminOrders
    {
        public static List<OrderVM> GetOrders()
        {
            List<OrderVM> data = new List<OrderVM>();

            using (DataBaseContext db = new DataBaseContext())
            {
                data = db.OrderDb.Select(u => new OrderVM
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
                    TotalPrice = u.TotalPrice,
                    TotalItemsCount = u.TotalitemsCount,
                    ItemsCount = u.ItemsCount,
                    OrderStatus = u.OrderStatus,
                    Date = u.Date,
                    ItemsVendorCode = u.ItemsVendorCode,
                    ItemsPrice = u.ItemsPrice,
                    OrderLanguage = u.OrderLanguage,
                }).ToList();

                List<string> itemsPriceList = new List<string>();
                List<string> itemsCount = new List<string>();

                List<OrderItemsVM> orderItems = new List<OrderItemsVM>();

                foreach (var order in data)
                {
                    order.ItemsVendorCodeList = order.ItemsVendorCode.Split('/').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                    itemsPriceList = order.ItemsPrice.Split('/').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                    itemsCount = order.ItemsPrice.Split('/').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

                    if (order.ItemsVendorCodeList.Count() != 0)
                    {
                        //чек на язык
                        for (int i = 0; i < order.ItemsVendorCodeList.Count(); i++)
                        {
                            var itemVendoreCode = order.ItemsVendorCodeList[i];
                            try
                            {
                                //чек на язык
                                orderItems.Add(new OrderItemsVM
                                {
                                    ItemName = db.ItemsDb.Where(u => u.VendorCode == itemVendoreCode).FirstOrDefault().NameRu,
                                    ItemImages = db.ItemsDb.Where(u => u.VendorCode == itemVendoreCode).FirstOrDefault().Image1,
                                    ItemPrice = itemsPriceList[i],
                                    ItemCount = itemsCount[i],
                                });

                                order.Items = orderItems;
                            }
                            catch(Exception)
                            { }
                        }
                    }
                }
            }

            return data;
        }

        public static OrderVM GetOrder(int id)
        {
            OrderVM data = new OrderVM();

            using (DataBaseContext db = new DataBaseContext())
            {
                data = db.OrderDb.Where(u => u.Id == id).Select(u => new OrderVM
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
                    catch(Exception e)
                    { }

                    data.Items = orderItems;
                }
            }

            return data;
        }

        public static void AddItemToOrder(int orderId, string vendorCode)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var data = db.OrderDb.Where(u => u.Id == orderId).FirstOrDefault();

                data.ItemsVendorCode += vendorCode + "/";

                var item = db.ItemsDb.Where(u => u.VendorCode == vendorCode).First();

                double itemCount = 0;

                if (item.ProductBuyTypeMeter != false)
                {
                    itemCount = 1;

                    data.ItemsCount += itemCount + "/";
                }
                else
                { 
                    itemCount = item.Width;

                    data.ItemsCount += itemCount + "/";
                }

                if (data.OrderLanguage != "en")
                {
                    data.ItemsPrice += item.PriceEn + "/";
                    data.TotalPrice += (item.PriceEn * itemCount);
                }
                else
                {
                    data.ItemsPrice += item.PriceEn + "/";
                    data.TotalPrice += (item.PriceEn * itemCount);
                }

                db.SaveChanges();
            }
        }

        public static void EditOrder(OrderVM order)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var data = db.OrderDb.Where(u => u.Id == order.Id).FirstOrDefault();

                data.Id = order.Id;
                data.OrderNumber = order.OrderNumber;
                data.UserName = order.UserName;
                data.UserEmail = order.UserEmail;
                data.UserPhone = order.UserPhone;
                data.DeliveryCity = order.DeliveryCity;
                data.DeliveryOffice = order.DeliveryOffice;
                data.DeliveryMethod = order.DeliveryMethod;
                data.PaymentMethod = order.PaymentMethod;
                data.OrderStatus = order.OrderStatus;
                data.PaymentStatus = order.PaymentStatus;
                data.Date = DateTime.Now;

                data.ItemsCount = "";
                data.ItemsVendorCode = "";
                data.TotalPrice = 0;

                List<OrderItemsVM> orderItems = new List<OrderItemsVM>();

                foreach (var item in order.Items)
                {
                    data.ItemsVendorCode += item.ItemVendorCode + "/";
                    
                    data.ItemsCount += item.ItemCount + "/";

                    var product = db.ItemsDb.Where(u => u.VendorCode == item.ItemVendorCode).First();

                    if (data.OrderLanguage != "en" || data.OrderLanguage != null)
                        data.TotalPrice += (product.PriceUa * Convert.ToDouble(item.ItemCount));
                    else
                        data.TotalPrice += (product.PriceEn * Convert.ToDouble(item.ItemCount));
                }

                var totalItemsCount = data.ItemsCount.Split('/').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

                data.TotalitemsCount = totalItemsCount.Count();

                db.SaveChanges();
            }
        }

        public static void ChangeItemStatus(int id, string status)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var data =
                     (from entry in db.OrderDb
                      where entry.Id == id
                      select entry).FirstOrDefault();

                data.OrderStatus = status;

                db.SaveChanges();
            }
        }

        public static void DelteOrderItem(int orderId, string vendorCode)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var data = db.OrderDb.Where(u => u.Id == orderId).FirstOrDefault();

                var ItemsVendorCodeList = data.ItemsVendorCode.Split('/').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                var itemsPriceList = data.ItemsPrice.Split('/').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                var itemsCount = data.ItemsPrice.Split('/').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

                for (int i = 0; i < ItemsVendorCodeList.Count(); i++)
                {
                    if (ItemsVendorCodeList[i] == vendorCode)
                    {
                        ItemsVendorCodeList.RemoveAt(i);
                        itemsPriceList.RemoveAt(i);
                        itemsCount.RemoveAt(i);
                    }
                }

                data.ItemsVendorCode = String.Join("/", ItemsVendorCodeList.ToArray()) + "/";
                data.ItemsPrice = String.Join("/", itemsPriceList.ToArray()) + "/";
                data.ItemsCount = String.Join("/", itemsCount.ToArray()) + "/";

                db.SaveChanges();
            }
        }

        public static void DelteOrder(int orderId)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var data = db.OrderDb.Where(u => u.Id == orderId).FirstOrDefault();

                db.OrderDb.Remove(data);

                db.SaveChanges();
            }
        }
    }
}