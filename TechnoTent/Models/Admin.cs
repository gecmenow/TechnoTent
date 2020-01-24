using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnoTent.Cookies;
using TechnoTent.Models.DataBase;
using TechnoTent.Models.ViewModel.Admin;

namespace TechnoTent.Models
{
    public class Admin
    {
        public static DbAdmin Login(DbAdmin admin)
        {
            DbAdmin user = new DbAdmin();
           
            try
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    user = db.AdminDb.Where(u => u.Login == admin.Login && u.Password == admin.Password).FirstOrDefault();
                }
            }

            catch(Exception e)
            { }

            return user;
        }

        public static AdminEditVM GetAdminData()
        {
            var data = new AdminEditVM();

            // поиск пользователя в бд
            using (DataBaseContext db = new DataBaseContext())
            {
                DbAdmin admin = db.AdminDb.FirstOrDefault();

                if (admin != null)
                {
                    data.Login = admin.Login;
                    data.Password = admin.Password;
                    data.NovaPoshtaKey = admin.NovaPoshtaKey;
                    data.InTimeKey = admin.InTimeKey;
                }
            }

            return data;
        }

        public static bool Edit(AdminEditVM adminEdit, int session)
        {
            bool result = false;

            // поиск пользователя в бд
            using (DataBaseContext db = new DataBaseContext())
            {
                DbAdmin admin = db.AdminDb.FirstOrDefault(u => u.UniqueNumber == session);

                if (admin != null)
                {
                    admin.Login = adminEdit.Login;
                    admin.Password = adminEdit.Password;
                    admin.NovaPoshtaKey = adminEdit.NovaPoshtaKey;
                    admin.InTimeKey = adminEdit.InTimeKey;

                    Random radndom = new Random();

                    admin.UniqueNumber = radndom.Next();

                    AdminCookie adminCookie = new AdminCookie();

                    adminCookie.SetAdminCookie(admin);

                    db.SaveChanges();

                    result = true;
                }
            }

            return result;
        }
    }
}