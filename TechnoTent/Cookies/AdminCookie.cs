using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnoTent.Hashing;
using TechnoTent.Models.DataBase;

namespace TechnoTent.Cookies
{
    public class AdminCookie
    {
        readonly string sharedKey = "123";

        readonly string adminSession = "tt_admin_session";

        public void SetAdminCookie(DbAdmin admin)
        {
            string adminId = Hash.EncryptStringAES(admin.UniqueNumber.ToString(), sharedKey);

            HttpCookie cookie = new HttpCookie(adminSession)
            {
                Value = adminId
            };

            // Этот cookie-набор будет оставаться 
            // действительным в течение одного года
            cookie.Expires = DateTime.Now.AddDays(7);

            // Добавить куки в ответ
            HttpContext.Current.Response.Cookies.Add(cookie); 
        }

        public void UnsetAdminCookie()
        {
            HttpCookie cookie = new HttpCookie(adminSession)
            {
                Expires = DateTime.Now.AddYears(-1)
            };

            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public int GetAdminSession()
        {
            string data = HttpContext.Current.Request.Cookies[adminSession].Value;

            string decryptedId = Hash.DecryptStringAES(data, sharedKey);

            int adminUniqueNumber = Convert.ToInt32(decryptedId);

            int uniqueNumber = 0;

            using (DataBaseContext db = new DataBaseContext())
            {
                uniqueNumber = db.AdminDb.Where(v => v.UniqueNumber == adminUniqueNumber).Select(v => v.UniqueNumber).First();
            }

            return uniqueNumber;
        }

        public bool IsAdmin()
        {
            bool status = false;

            try
            {
                string data = HttpContext.Current.Request.Cookies[adminSession].Value;

                string decryptedId = Hash.DecryptStringAES(data, sharedKey);

                int adminUniqueNumber = Convert.ToInt32(decryptedId);

                using (DataBaseContext db = new DataBaseContext())
                {
                    int uniqueNumber = db.AdminDb.Where(v => v.UniqueNumber == adminUniqueNumber).Select(v => v.UniqueNumber).First();

                    if (adminUniqueNumber == uniqueNumber)
                        status = true;
                }
            }
            catch (Exception)
            {
                status = false;
            }

            return status;
        }
    }
}