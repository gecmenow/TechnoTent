using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnoTent.Cookies
{
    public class OrderCookie
    {
        public static void SetOrderCookie()
        {
            // Создать объект cookie-набора
            HttpCookie cookie = new HttpCookie("successfulOrder");
            // Установить значения в нем
            cookie.Value = "true";

            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}