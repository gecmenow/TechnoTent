using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnoTent.Cookies
{
    public class Cookie
    {
        public static string CheckLanguageCookie()
        {
            var language = "ru";

            try
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["lang"];

                if (cookie != null)
                    language = cookie.Value;   // если куки уже установлено, то обновляем значение
            }
            catch(Exception)
            {

            }

            return language;
        }
    }
}