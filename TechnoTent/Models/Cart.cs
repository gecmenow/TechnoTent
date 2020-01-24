using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnoTent.Cookies;
using TechnoTent.Models.DataBase;
using TechnoTent.Models.ViewModel;

namespace TechnoTent.Models
{
    public class Cart
    {
        readonly static string sharedKey = "123";

        public static int AddToCart(string vendorCode, string itemCount)
        {
            int count = 0;

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                int userId = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                using (DataBaseContext db = new DataBaseContext())
                {
                    //получаем guid из бд по Userid
                    var user = db.CartDb.Where(u => u.UserId == userId).FirstOrDefault();

                    Guid guid = new Guid();

                    if (user != null)
                        //Если Guid есть, занчит добавляем новый товар с уже существующим Guid, иначе создаём новый Guid
                        guid = user.Guid;
                    else
                        guid = Guid.NewGuid();

                    var item = db.ItemsDb.Where(u => u.VendorCode == vendorCode).FirstOrDefault();

                    db.CartDb.Add(new DbCart
                    {
                        VendorCode = vendorCode,
                        ItemCount = itemCount,
                        UserId = userId,
                        Guid = guid,
                    });

                    db.SaveChanges();

                    var temp = db.CartDb.Where(u => u.UserId == userId).ToList();

                    foreach (var t in temp)
                        count++;

                    CartCookie.SetCartItemsCountCookie(count);

                    CartCookie.SetCartCookie(guid);
                }
            }
            else
            {
                string cartItems = null;
                //если куки не пусты добавляем товары из куки в строку + новый товар, 
                //иначе просто добавляем новый товар в строку
                if (CartCookie.GetNonUserCarFromCookie() != null)
                {
                    cartItems += CartCookie.GetNonUserCarFromCookie();

                    cartItems += String.Concat(vendorCode.ToString(), "/", itemCount, "|");
                }
                else
                    cartItems += String.Concat(vendorCode.ToString(), "/", itemCount, "|");

                //для определения кол-ва элементов в корзине
                var array = cartItems.Split('|').ToList();

                Dictionary<string, double> items = new Dictionary<string, double>();

                List<string> itemsFromCookie = new List<string>();
                //из массива отбираем лишь индекс товара, который равен входящему индексу
                foreach (var data in array)
                {
                    if (data != "")
                    {
                        var arr = data.Split('/').ToList();

                        foreach (var item in arr)
                            itemsFromCookie.Add(item);
                    }
                }

                for (int i = 0; i < itemsFromCookie.Count() - 1; i += 2)
                {
                    items.Add(itemsFromCookie[i],
                        Convert.ToDouble(itemsFromCookie[i + 1]));
                }

                foreach (var item in items)
                {
                    count++;
                }

                CartCookie.SetCartItemsCountCookie(count);

                //хешируем товар и его кол-во
                string hash = Hashing.Hash.EncryptStringAES(cartItems, sharedKey);
                //добавялем хешированнный товар в куки
                CartCookie.SetNonUserCartCookie(hash);   
            }

            return count;
        }

        public static CartVM RemoveFromCart(string vendorCode)
        {
            CartVM cartVm = new CartVM();

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var userId = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                using (DataBaseContext db = new DataBaseContext())
                {
                    var cart = db.CartDb.Where(u => u.UserId == userId
                                            && u.VendorCode == vendorCode).FirstOrDefault();

                    db.CartDb.Remove(cart);

                    db.SaveChanges();
                }
            }
            else
            {
                String cartItems = CartCookie.GetNonUserCarFromCookie();
                //раскладываем строку на массив символов
                int index = -1;

                index = cartItems.LastIndexOf(vendorCode);
                //ПЕРЕДЕЛАТЬ
                int length = (cartItems.IndexOf("|", index) - index) + 1;

                //int endIndex = cartItems.IndexOf("|", index) + 1;

                if (index != -1)
                {
                    cartItems = cartItems.Remove(index, length);

                    if (cartItems == "")
                        CartCookie.ClearNonUserCartCookie();
                    else
                    {
                        //хешируем товар и его кол-во
                        string hash = Hashing.Hash.EncryptStringAES(cartItems, sharedKey);
                        //добавялем хешированнный товар в куки
                        CartCookie.SetNonUserCartCookie(hash);
                    }
                }

                List<CartItemVM> cartItemsList = new List<CartItemVM>();

                if (cartItems != null)
                {
                    var array = cartItems.Split('|').ToList();

                    Dictionary<string, double> items = new Dictionary<string, double>();

                    List<string> itemsFromCookie = new List<string>();
                    //из массива отбираем лишь индекс товара, который равен входящему индексу
                    //для этого шаг перебора = 4
                    foreach (var data in array)
                    {
                        if (data != "")
                        {
                            var arr = data.Split('/').ToList();

                            foreach (var item in arr)
                                itemsFromCookie.Add(item);
                        }
                    }

                    for (int i = 0; i < itemsFromCookie.Count() - 1; i += 2)
                    {
                        items.Add(itemsFromCookie[i], Convert.ToDouble(itemsFromCookie[i + 1]));
                    }

                    double totalPrice = 0;

                    var language = Cookie.CheckLanguageCookie();

                    foreach (var data in items)
                    {
                        using (DataBaseContext db = new DataBaseContext())
                        {
                            var item = db.ItemsDb.Where(u => u.VendorCode == data.Key).FirstOrDefault();

                            if(!item.IndividualOrders)
                            {
                                switch (language)
                                {
                                    case "uk":
                                        if (item.IsStock)
                                            cartItemsList.Add(new CartItemVM
                                            {
                                                VendorCode = item.VendorCode,
                                                Name = item.NameUa,
                                                NameUrl = UrlHelper.GenerateSeoFriendlyURL(item.NameEn),
                                                Image = item.Image1,
                                                Text = item.Description,
                                                ItemPrice = item.StockPriceUa,
                                                ItemCount = data.Value.ToString(),
                                                ItemTotalPrice = item.StockPriceUa * data.Value,
                                                IndividualOrder = item.IndividualOrders,
                                            });
                                        else
                                            cartItemsList.Add(new CartItemVM
                                            {
                                                VendorCode = item.VendorCode,
                                                Name = item.NameUa,
                                                NameUrl = UrlHelper.GenerateSeoFriendlyURL(item.NameEn),
                                                Image = item.Image1,
                                                Text = item.Description,
                                                ItemPrice = item.PriceUa,
                                                ItemCount = data.Value.ToString(),
                                                ItemTotalPrice = item.PriceUa * data.Value,
                                                IndividualOrder = item.IndividualOrders,
                                            });

                                        totalPrice = item.PriceUa * data.Value;
                                        break;
                                    case "en":
                                        if (item.IsStock)
                                        {
                                            cartItemsList.Add(new CartItemVM
                                            {
                                                VendorCode = item.VendorCode,
                                                Name = item.NameUa,
                                                NameUrl = UrlHelper.GenerateSeoFriendlyURL(item.NameEn),
                                                Image = item.Image1,
                                                Text = item.Description,
                                                ItemPrice = item.StockPriceEn,
                                                ItemCount = data.Value.ToString(),
                                                ItemTotalPrice = item.StockPriceEn * data.Value,
                                                IndividualOrder = item.IndividualOrders,
                                            });

                                            totalPrice = item.StockPriceEn * data.Value;
                                        }

                                        else
                                        {
                                            cartItemsList.Add(new CartItemVM
                                            {
                                                VendorCode = item.VendorCode,
                                                Name = item.NameUa,
                                                NameUrl = UrlHelper.GenerateSeoFriendlyURL(item.NameEn),
                                                Image = item.Image1,
                                                Text = item.Description,
                                                ItemPrice = item.PriceEn,
                                                ItemCount = data.Value.ToString(),
                                                ItemTotalPrice = item.PriceEn * data.Value,
                                                IndividualOrder = item.IndividualOrders,
                                            });

                                            totalPrice = item.PriceEn * data.Value;
                                        }

                                        break;

                                    default:
                                        if (item.IsStock)
                                        {
                                            cartItemsList.Add(new CartItemVM
                                            {
                                                VendorCode = item.VendorCode,
                                                Name = item.NameUa,
                                                NameUrl = UrlHelper.GenerateSeoFriendlyURL(item.NameEn),
                                                Image = item.Image1,
                                                Text = item.Description,
                                                ItemPrice = item.StockPriceUa,
                                                ItemCount = data.Value.ToString(),
                                                ItemTotalPrice = item.PriceUa * data.Value,
                                                IndividualOrder = item.IndividualOrders,
                                            });

                                            totalPrice = item.StockPriceUa * data.Value;
                                        }

                                        else
                                        {
                                            cartItemsList.Add(new CartItemVM
                                            {
                                                VendorCode = item.VendorCode,
                                                Name = item.NameUa,
                                                NameUrl = UrlHelper.GenerateSeoFriendlyURL(item.NameEn),
                                                Image = item.Image1,
                                                Text = item.Description,
                                                ItemPrice = item.PriceUa,
                                                ItemCount = data.Value.ToString(),
                                                ItemTotalPrice = item.PriceUa * data.Value,
                                                IndividualOrder = item.IndividualOrders,
                                            });

                                            totalPrice = item.PriceUa * data.Value;
                                        }
                                        break;
                                }
                            }
                            else
                                cartItemsList.Add(new CartItemVM
                                {
                                    VendorCode = item.VendorCode,
                                    Name = item.NameUa,
                                    NameUrl = UrlHelper.GenerateSeoFriendlyURL(item.NameEn),
                                    Image = item.Image1,
                                    Text = item.Description,
                                    ItemPrice = item.StockPriceUa,
                                    ItemCount = data.Value.ToString(),
                                    MinOrderQuantity = item.Width,
                                    IndividualOrder = item.IndividualOrders,
                                });

                            cartVm.CartItems = cartItemsList;
                            cartVm.TotalCost += totalPrice;
                        }
                    }
                }
            }

            return cartVm;
        }

        public static void EditItemCount(string vendorCode, double itemCount)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var userId = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                using (DataBaseContext db = new DataBaseContext())
                {
                    var cart = db.CartDb.Where(u => u.UserId == userId
                                            && u.VendorCode == vendorCode).FirstOrDefault();

                    cart.ItemCount = itemCount.ToString();

                    db.SaveChanges();
                }
            }
            else
            {
                String cartItems = CartCookie.GetNonUserCarFromCookie();
                //раскладываем строку на массив символов

                int index = -1;
                /*
                var arr = cartItems.ToString();

                
                for (int i = 0; i < arr.Count(); i++)
                    if (arr[i].ToString() == vendorCode)
                        index = i;
                */

                index = cartItems.LastIndexOf(vendorCode);

                //int lastIndex = index + vendorCode.Length - 1;

                int length = cartItems.IndexOf("|", index) - index;

                if (index != -1)
                {
                    string oldText = cartItems.Substring(index, length);

                    string newText = String.Concat(vendorCode, "/", itemCount);

                    cartItems = cartItems.Replace(oldText, newText);

                    string hash = Hashing.Hash.EncryptStringAES(cartItems, sharedKey);

                    CartCookie.SetNonUserCartCookie(hash);
                }
            }
        }

        public static CartVM ShowCart()
        {
            List<CartItemVM> cartItems = new List<CartItemVM>();

            CartVM cartVm = new CartVM();

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var userId = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                using (DataBaseContext db = new DataBaseContext())
                {
                    var cart = db.CartDb.Where(u => u.UserId == userId);

                    double totalPrice = 0;

                    if (cart != null)
                    {
                        var language = Cookie.CheckLanguageCookie();

                        switch (language)
                        {
                            case "uk":
                                foreach (var data in cart)
                                {
                                    var item = db.ItemsDb.Where(u => u.VendorCode == data.VendorCode).FirstOrDefault();
                                    
                                    if(!item.IndividualOrders)
                                    {
                                        if (item.IsStock)
                                        {
                                            cartItems.Add(new CartItemVM
                                            {
                                                VendorCode = item.VendorCode,
                                                Name = item.NameUa,
                                                NameUrl = UrlHelper.GenerateSeoFriendlyURL(item.NameEn),
                                                Image = item.Image1,
                                                Text = item.Description,
                                                ItemCount = data.ItemCount,
                                                ItemPrice = item.PriceUa,
                                                ItemTotalPrice = item.PriceUa * Convert.ToDouble(data.ItemCount),
                                                MinOrderQuantity = item.Width,
                                                IndividualOrder = item.IndividualOrders,
                                            });

                                            totalPrice = item.PriceUa * Convert.ToDouble(data.ItemCount);
                                        }
                                        else
                                        {
                                            cartItems.Add(new CartItemVM
                                            {
                                                VendorCode = item.VendorCode,
                                                Name = item.NameUa,
                                                NameUrl = UrlHelper.GenerateSeoFriendlyURL(item.NameEn),
                                                Image = item.Image1,
                                                Text = item.Description,
                                                ItemCount = data.ItemCount,
                                                ItemPrice = item.PriceUa,
                                                ItemTotalPrice = item.PriceUa * Convert.ToDouble(data.ItemCount),
                                                MinOrderQuantity = item.Width,
                                                IndividualOrder = item.IndividualOrders,
                                            });

                                            totalPrice = item.PriceUa * Convert.ToDouble(data.ItemCount);
                                        }
                                    }

                                    else
                                    {
                                        cartItems.Add(new CartItemVM
                                        {
                                            VendorCode = item.VendorCode,
                                            Name = item.NameUa,
                                            NameUrl = UrlHelper.GenerateSeoFriendlyURL(item.NameEn),
                                            Image = item.Image1,
                                            Text = item.Description,
                                            ItemCount = data.ItemCount,
                                            ItemPrice = item.PriceUa,
                                            MinOrderQuantity = item.Width,
                                            IndividualOrder = item.IndividualOrders,
                                        });
                                    }

                                    cartVm.CartItems = cartItems;
                                    cartVm.TotalCost += totalPrice;
                                }
                                break;
                            case "en":
                                foreach (var data in cart)
                                {
                                    var item = db.ItemsDb.Where(u => u.VendorCode == data.VendorCode).FirstOrDefault();

                                    if (!item.IndividualOrders)
                                    {
                                        if (item.IsStock)
                                        {
                                            cartItems.Add(new CartItemVM
                                            {
                                                VendorCode = item.VendorCode,
                                                Name = item.NameEn,
                                                NameUrl = UrlHelper.GenerateSeoFriendlyURL(item.NameEn),
                                                Image = item.Image1,
                                                Text = item.Description,
                                                ItemCount = data.ItemCount,
                                                ItemPrice = item.PriceEn,
                                                ItemTotalPrice = item.PriceEn * Convert.ToDouble(data.ItemCount),
                                                MinOrderQuantity = item.Width,
                                                IndividualOrder = item.IndividualOrders,
                                            });

                                            totalPrice = item.PriceUa * Convert.ToDouble(data.ItemCount);
                                        }
                                        else
                                        {
                                            cartItems.Add(new CartItemVM
                                            {
                                                VendorCode = item.VendorCode,
                                                Name = item.NameEn,
                                                NameUrl = UrlHelper.GenerateSeoFriendlyURL(item.NameEn),
                                                Image = item.Image1,
                                                Text = item.Description,
                                                ItemCount = data.ItemCount,
                                                ItemPrice = item.PriceEn,
                                                ItemTotalPrice = item.PriceEn * Convert.ToDouble(data.ItemCount),
                                                MinOrderQuantity = item.Width,
                                                IndividualOrder = item.IndividualOrders,
                                            });

                                            totalPrice = item.PriceEn * Convert.ToDouble(data.ItemCount);
                                        }
                                    }
                                    else
                                    {
                                        cartItems.Add(new CartItemVM
                                        {
                                            VendorCode = item.VendorCode,
                                            Name = item.NameUa,
                                            NameUrl = UrlHelper.GenerateSeoFriendlyURL(item.NameEn),
                                            Image = item.Image1,
                                            Text = item.Description,
                                            ItemCount = data.ItemCount,
                                            ItemPrice = item.PriceUa,
                                            MinOrderQuantity = item.Width,
                                            IndividualOrder = item.IndividualOrders,
                                        });
                                    }

                                    cartVm.CartItems = cartItems;
                                    cartVm.TotalCost += totalPrice;
                                }
                                break;
                            default:
                                foreach (var data in cart)
                                {
                                    var item = db.ItemsDb.Where(u => u.VendorCode == data.VendorCode).FirstOrDefault();

                                    if (!item.IndividualOrders)
                                    {
                                        if (item.IsStock)
                                        {
                                            cartItems.Add(new CartItemVM
                                            {
                                                VendorCode = item.VendorCode,
                                                Name = item.NameRu,
                                                NameUrl = UrlHelper.GenerateSeoFriendlyURL(item.NameEn),
                                                Image = item.Image1,
                                                Text = item.Description,
                                                ItemCount = data.ItemCount,
                                                ItemPrice = item.PriceUa,
                                                ItemTotalPrice = item.PriceUa * Convert.ToDouble(data.ItemCount),
                                                MinOrderQuantity = item.Width,
                                                IndividualOrder = item.IndividualOrders,
                                            });

                                            totalPrice = item.PriceUa * Convert.ToDouble(data.ItemCount);
                                        }
                                        else
                                        {
                                            cartItems.Add(new CartItemVM
                                            {
                                                VendorCode = item.VendorCode,
                                                Name = item.NameRu,
                                                NameUrl = UrlHelper.GenerateSeoFriendlyURL(item.NameEn),
                                                Image = item.Image1,
                                                Text = item.Description,
                                                ItemCount = data.ItemCount,
                                                ItemPrice = item.PriceUa,
                                                ItemTotalPrice = item.PriceUa * Convert.ToDouble(data.ItemCount),
                                                MinOrderQuantity = item.Width,
                                                IndividualOrder = item.IndividualOrders,
                                            });

                                            totalPrice = item.PriceUa * Convert.ToDouble(data.ItemCount);
                                        }
                                    }
                                    else
                                    {
                                        cartItems.Add(new CartItemVM
                                        {
                                            VendorCode = item.VendorCode,
                                            Name = item.NameUa,
                                            NameUrl = UrlHelper.GenerateSeoFriendlyURL(item.NameEn),
                                            Image = item.Image1,
                                            Text = item.Description,
                                            ItemCount = data.ItemCount,
                                            ItemPrice = item.PriceUa,
                                            MinOrderQuantity = item.Width,
                                            IndividualOrder = item.IndividualOrders,
                                        });
                                    }

                                    cartVm.CartItems = cartItems;
                                    cartVm.TotalCost += totalPrice;
                                }
                                break;
                        }
                    }
                }
            }
            else
            {
                String nonLoggedUserCart = CartCookie.GetNonUserCarFromCookie();

                if (nonLoggedUserCart != null)
                {
                    var array = nonLoggedUserCart.Split('|').ToList();

                    Dictionary<string, string> items = new Dictionary<string, string>();

                    List<string> itemsFromCookie = new List<string>();
                    //из массива отбираем лишь индекс товара, который равен входящему индексу
                    //для этого шаг перебора = 4
                    foreach (var data in array)
                    {
                        if (data != "")
                        {
                            var arr = data.Split('/').ToList();

                            foreach (var item in arr)
                                itemsFromCookie.Add(item);
                        }
                    }

                    for (int i = 0; i < itemsFromCookie.Count() - 1; i += 2)
                    {
                        items.Add(itemsFromCookie[i], itemsFromCookie[i + 1]);
                    }

                    double totalPrice = 0;

                    foreach (var data in items)
                    {
                        using (DataBaseContext db = new DataBaseContext())
                        {
                            var item = db.ItemsDb.Where(u => u.VendorCode == data.Key).FirstOrDefault();

                            if (!item.IndividualOrders)
                            {
                                var language = Cookie.CheckLanguageCookie();

                                switch (language)
                                {
                                    case "uk":
                                        if (item.IsStock)
                                            cartItems.Add(new CartItemVM
                                            {
                                                VendorCode = item.VendorCode,
                                                Name = item.NameUa,
                                                NameUrl = UrlHelper.GenerateSeoFriendlyURL(item.NameEn),
                                                Image = item.Image1,
                                                Text = item.Description,
                                                ItemPrice = item.StockPriceUa,
                                                ItemCount = data.Value,
                                                ItemTotalPrice = item.StockPriceUa * Convert.ToDouble(data.Value),
                                                MinOrderQuantity = item.Width,
                                                IndividualOrder = item.IndividualOrders,
                                            });
                                        else
                                            cartItems.Add(new CartItemVM
                                            {
                                                VendorCode = item.VendorCode,
                                                Name = item.NameUa,
                                                NameUrl = UrlHelper.GenerateSeoFriendlyURL(item.NameEn),
                                                Image = item.Image1,
                                                Text = item.Description,
                                                ItemPrice = item.PriceUa,
                                                ItemCount = data.Value,
                                                ItemTotalPrice = item.PriceUa * Convert.ToDouble(data.Value),
                                                MinOrderQuantity = item.Width,
                                                IndividualOrder = item.IndividualOrders,
                                            });

                                        totalPrice = item.PriceUa * Convert.ToDouble(data.Value);
                                        break;
                                    case "en":
                                        if (item.IsStock)
                                        {
                                            cartItems.Add(new CartItemVM
                                            {
                                                VendorCode = item.VendorCode,
                                                Name = item.NameUa,
                                                NameUrl = UrlHelper.GenerateSeoFriendlyURL(item.NameEn),
                                                Image = item.Image1,
                                                Text = item.Description,
                                                ItemPrice = item.StockPriceEn,
                                                ItemCount = data.Value,
                                                ItemTotalPrice = item.StockPriceEn * Convert.ToDouble(data.Value),
                                                MinOrderQuantity = item.Width,
                                                IndividualOrder = item.IndividualOrders,
                                            });

                                            totalPrice = item.StockPriceEn * Convert.ToDouble(data.Value);
                                        }

                                        else
                                        {
                                            cartItems.Add(new CartItemVM
                                            {
                                                VendorCode = item.VendorCode,
                                                Name = item.NameUa,
                                                NameUrl = UrlHelper.GenerateSeoFriendlyURL(item.NameEn),
                                                Image = item.Image1,
                                                Text = item.Description,
                                                ItemPrice = item.PriceEn,
                                                ItemCount = data.Value,
                                                ItemTotalPrice = item.PriceEn * Convert.ToDouble(data.Value),
                                                MinOrderQuantity = item.Width,
                                                IndividualOrder = item.IndividualOrders,
                                            });

                                            totalPrice = item.PriceEn * Convert.ToDouble(data.Value);
                                        }

                                        break;

                                    default:
                                        if (item.IsStock)
                                        {
                                            cartItems.Add(new CartItemVM
                                            {
                                                VendorCode = item.VendorCode,
                                                Name = item.NameUa,
                                                NameUrl = UrlHelper.GenerateSeoFriendlyURL(item.NameEn),
                                                Image = item.Image1,
                                                Text = item.Description,
                                                ItemPrice = item.StockPriceUa,
                                                ItemCount = data.Value,
                                                ItemTotalPrice = item.StockPriceUa * Convert.ToDouble(data.Value),
                                                MinOrderQuantity = item.Width,
                                                IndividualOrder = item.IndividualOrders,
                                            });

                                            totalPrice = item.StockPriceUa * Convert.ToDouble(data.Value);
                                        }

                                        else
                                        {
                                            cartItems.Add(new CartItemVM
                                            {
                                                VendorCode = item.VendorCode,
                                                Name = item.NameUa,
                                                NameUrl = UrlHelper.GenerateSeoFriendlyURL(item.NameEn),
                                                Image = item.Image1,
                                                Text = item.Description,
                                                ItemPrice = item.PriceUa,
                                                ItemCount = data.Value,
                                                ItemTotalPrice = item.PriceUa * Convert.ToDouble(data.Value),
                                                MinOrderQuantity = item.Width,
                                                IndividualOrder = item.IndividualOrders,
                                            });

                                            totalPrice = item.PriceUa * Convert.ToDouble(data.Value);
                                        }
                                        break;
                                }
                            }
                            else
                                cartItems.Add(new CartItemVM
                                {
                                    VendorCode = item.VendorCode,
                                    Name = item.NameUa,
                                    NameUrl = UrlHelper.GenerateSeoFriendlyURL(item.NameEn),
                                    Image = item.Image1,
                                    Text = item.Description,
                                    ItemPrice = item.StockPriceUa,
                                    ItemCount = data.Value,
                                    MinOrderQuantity = item.Width,
                                    IndividualOrder = item.IndividualOrders,
                                });

                            cartVm.CartItems = cartItems;
                            cartVm.TotalCost += totalPrice;
                        }
                    }
                }
            }

            return cartVm;
        }

        public static bool CheckItemInCart(string vendorCode)
        {
            bool result = false;

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var userId = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                using (DataBaseContext db = new DataBaseContext())
                {
                    var cart = db.CartDb.Where(u => u.UserId == userId
                                            && u.VendorCode == vendorCode).FirstOrDefault();
                    if (cart != null)
                        result = true;
                }
            }
            else
            {
                String cartItems = CartCookie.GetNonUserCarFromCookie();

                if (cartItems != null)
                {
                    //раскладываем строку на список
                    var array = cartItems.Split('|').ToList();

                    Dictionary<string, double> items = new Dictionary<string, double>();

                    List<string> itemsFromCookie = new List<string>();
                    //из массива отбираем лишь индекс товара, который равен входящему индексу
                    //для этого шаг перебора = 4
                    foreach (var data in array)
                    {
                        if (data != "")
                        {
                            var arr = data.Split('/').ToList();

                            foreach (var item in arr)
                                itemsFromCookie.Add(item);
                        }
                    }

                    for (int i = 0; i < itemsFromCookie.Count() - 1; i += 2)
                    {
                        items.Add(itemsFromCookie[i],
                            Convert.ToDouble(itemsFromCookie[i + 1]));
                    }

                    foreach (var data in items)
                        if (data.Key == vendorCode)
                            result = true;
                }
            }

            return result;
        }

        public static CartVM GetCartItemsCount()
        {
            List<CartItemVM> cartItems = new List<CartItemVM>();

            CartVM cartVm = new CartVM();

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var userId = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                using (DataBaseContext db = new DataBaseContext())
                {
                    var cart = db.CartDb.Where(u => u.UserId == userId);

                    if (cart != null)
                    {
                        foreach (var data in cart)
                        {
                            var item = db.ItemsDb.Where(u => u.VendorCode == data.VendorCode).FirstOrDefault();

                            cartItems.Add(new CartItemVM
                            {
                                ItemCount = data.ItemCount,
                            });
                        }
                    }
                }
            }
            else
            {
                String nonLoggedUserCart = CartCookie.GetNonUserCarFromCookie();

                if (nonLoggedUserCart != null)
                {
                    var array = nonLoggedUserCart.Split('|').ToList();

                    Dictionary<string, string> items = new Dictionary<string, string>();

                    List<string> itemsFromCookie = new List<string>();
                    //из массива отбираем лишь индекс товара, который равен входящему индексу
                    foreach (var data in array)
                    {
                        if (data != "")
                        {
                            var arr = data.Split('/').ToList();

                            foreach (var item in arr)
                                itemsFromCookie.Add(item);
                        }
                    }

                    for (int i = 0; i < itemsFromCookie.Count() - 1; i += 2)
                        items.Add(itemsFromCookie[i],itemsFromCookie[i + 1]);

                    foreach (var data in items)
                    {
                        using (DataBaseContext db = new DataBaseContext())
                        {
                            var item = db.ItemsDb.Where(u => u.VendorCode == data.Key).FirstOrDefault();

                            cartItems.Add(new CartItemVM
                            {
                                ItemCount = data.Value,
                            });
                        }
                    }
                }
            }

            CartVM count = new CartVM();

            count.ItemsCount = 0;

            foreach (var items in cartItems)
            {
                count.ItemsCount++;
            }

            return count;
        }

        public static void ClearCart()
        {
            CartVM cartVm = new CartVM();

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var userId = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                using (DataBaseContext db = new DataBaseContext())
                {
                    var cart = db.CartDb.Where(u => u.UserId == userId);

                    foreach (var data in cart)
                        db.CartDb.Remove(data);

                    db.SaveChanges();
                }
            }
            CartCookie.ClearNonUserCartCookie();
        }
    }
}