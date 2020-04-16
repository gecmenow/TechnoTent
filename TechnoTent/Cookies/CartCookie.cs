using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnoTent.Models;

namespace TechnoTent.Cookies
{
    public class CartCookie
    {
        public static string GetCartFromCookie()
        {
            string data = HttpContext.Current.Request.Cookies["sc"].Value;

            return data;
        }

        public static void SetCartCookie(Guid guid)
        {
            HttpCookie cookie = new HttpCookie("sc");

            cookie.Value = guid.ToString();

            // Этот cookie-набор будет оставаться 
            // действительным в течение максимального значения
            cookie.Expires = DateTime.Now.AddYears(1);

            // Добавить куки в ответ
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static void SetCartItemsCountCookie(int count)
        {
            HttpCookie cookie = new HttpCookie("ic");

            cookie.Value = count.ToString();

            // Этот cookie-набор будет оставаться 
            // действительным в течение максимального значения
            cookie.Expires = DateTime.Now.AddYears(1);

            // Добавить куки в ответ
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static string GetNonUserCarFromCookie()
        {
            string data = null;

            string sharedKey = "123";

            if
                (HttpContext.Current.Request.Cookies["scnu"] != null)
            {
                try
                {
                    string value = HttpContext.Current.Request.Cookies["scnu"].Value;

                    data = Hashing.Hash.DecryptStringAES(value, sharedKey);
                }
                catch (Exception)
                { }
            }
            

            return data;
        }

        public static void SetNonUserCartCookie(string hash)
        {
            HttpCookie cookie = new HttpCookie("scnu");

            cookie.Value = hash;

            // Этот cookie-набор будет оставаться 
            // действительным в течение максимального значения
            cookie.Expires = DateTime.Now.AddYears(1);

            // Добавить куки в ответ
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static void ClearNonUserCartCookie()
        {
            HttpCookie cookie = new HttpCookie("scnu");

            // Этот cookie-набор будет оставаться 
            // действительным в течение максимального значения
            cookie.Expires = DateTime.Now.AddYears(-1);

            // Добавить куки в ответ
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}