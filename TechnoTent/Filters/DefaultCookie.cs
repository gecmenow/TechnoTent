using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnoTent.Filters
{
    public class DefaultCookie
    {
        public static void SetDefaultCookie()
        {
            try
            {
                string cookieVal = HttpContext.Current.Request.Cookies["lang"].Value;
            }
            catch (Exception)
            {
                HttpCookie cookie = new HttpCookie("lang");
                // Установить значения в нем
                cookie.Value = "ru";

                // Добавить куки в ответ
                HttpContext.Current.Response.Cookies.Add(cookie);

                // Этот cookie-набор будет оставаться 
                // действительным в течение одного года
                cookie.Expires = DateTime.Now.AddMonths(1);
            }
        }
    }
}