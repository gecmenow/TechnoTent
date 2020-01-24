using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnoTent.Models.DataBase;

namespace TechnoTent.Cookies
{
    public class UserCookie
    {
        public void SetUserCookie(string email)
        {
            int userId = 0;

            HttpCookie cookie = new HttpCookie("uid");

            // поиск пользователя в бд
            using (DataBaseContext db = new DataBaseContext())
            {
                userId = db.UserDb.FirstOrDefault(u => u.Email == email).Id;
            }

            try
            {
                string cookieVal = HttpContext.Current.Request.Cookies["uid"].Value;

                cookie.Expires = DateTime.MaxValue;

            }
            catch (Exception)
            {
                cookie.Value = userId.ToString();

                // Этот cookie-набор будет оставаться 
                // действительным в течение максимального значения
                cookie.Expires = DateTime.Now.AddYears(100);

                // Добавить куки в ответ
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        public bool CheckUserCookie()
        {
            bool flag;

            try
            {
                string cookieVal = HttpContext.Current.Request.Cookies["uid"].Value;

                flag = true;
            }
            catch (Exception)
            {
                flag = false;
            }

            return flag;
        }
    }
}