using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace TechnoTent.Cookies
{
    public class Cookie
    {
        [HandleProcessCorruptedStateExceptions]
        public static string CheckLanguageCookie()
        {
            var language = "ru";

            HttpCookie cookie = null;

            var temp = HttpContext.Current;

            if (temp != null)
            {
                try
                {
                    cookie = temp.Request.Cookies["lang"];
                }
                catch(Exception)
                { }
            }
            
            if (cookie != null)
                    language = cookie.Value;   // если куки уже установлено, то обновляем значение
            
            return language;
        }
    }
}