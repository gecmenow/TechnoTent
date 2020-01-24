using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnoTent.Cookies;
using TechnoTent.Models.DataBase;

namespace TechnoTent.Models
{
    public class Loging
    {
        public static void CheckCookieCart(int userId)
        {
            List<string> dbCart = new List<string>();

            using (DataBaseContext db = new DataBaseContext())
            {
                var cart = db.CartDb.Where(u => u.UserId == userId).Select(u => u.VendorCode);

                foreach (var data in cart)
                    dbCart.Add(data);
            }

            String cartItems = CartCookie.GetNonUserCarFromCookie();

            if (cartItems != null)
            {
                //раскладываем строку в список
                var array = cartItems.Split('|').ToList();

                List<string> itemsFromCookie = new List<string>();
                List<string> itemsVendorsFromCookie = new List<string>();
                //из массива отбираем лишь индекс товара, который равен входящему индексу
                foreach (var data in array)
                {
                    if (data != "")
                    {
                        var arr = data.Split('/').ToList();

                        for (int i = 0; i < arr.Count(); i++)
                        {
                            itemsFromCookie.Add(arr[i]);
                        }

                        for (int i = 0; i < arr.Count(); i += 2)
                        {
                            itemsVendorsFromCookie.Add(arr[i]);
                        }
                    }
                }

                Dictionary<string, string> items = new Dictionary<string, string>();

                for (int i = 0; i < itemsFromCookie.Count() - 1; i++)
                {
                    items.Add(itemsFromCookie[i],
                        itemsFromCookie[i + 1]);
                }

                List<string> different = new List<string>();

                different = itemsVendorsFromCookie.Except(dbCart).ToList();

                if (different.Count != 0)
                {
                    Guid guid = new Guid();

                    using (DataBaseContext db = new DataBaseContext())
                    {
                        //получаем guid из бд по Userid
                        var user = db.CartDb.Where(u => u.UserId == userId).FirstOrDefault();

                        if (user != null)
                            //Если Guid есть, занчит добавляем новый товар с уже существующим Guid, иначе создаём новый Guid
                            guid = user.Guid;
                        else
                            guid = Guid.NewGuid();

                        foreach (var id in different)
                        {
                            db.CartDb.Add(new DbCart
                            {
                                ItemCount = items[id].ToString(),
                                VendorCode = id,
                                UserId = userId,
                                Guid = guid,
                            });

                            db.SaveChanges();
                        }
                    }
                }
            }
        }
    }
}