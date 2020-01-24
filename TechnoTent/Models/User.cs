using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnoTent.Models.DataBase;
using TechnoTent.Models.UserModels;
using TechnoTent.Models.ViewModel;

namespace TechnoTent.Models
{
    public class User
    {
        public static int AddUser(Registration register)
        {
            int session = 0;

            // поиск пользователя в бд
            using (DataBaseContext db = new DataBaseContext())
            {
                DbUser user = db.UserDb.FirstOrDefault(u => u.Email == register.Email);

                if (user == null)
                {
                    db.UserDb.Add(new DbUser
                    {
                        Name = register.Name,
                        Email = register.Email,
                        Password = register.Password
                    });

                    db.SaveChanges();

                    session = db.UserDb.FirstOrDefault(u => u.Email == register.Email).Id;
                }
            }

            return session;
        }

        public static int LoginUser(Login login)
        {
            int session = 0;

            // поиск пользователя в бд
            using (DataBaseContext db = new DataBaseContext())
            {
                DbUser user = db.UserDb.FirstOrDefault(u => u.Email == login.Email && u.Password == login.Password);

                if (user != null)
                    session = user.Id;
            }

            return session;
        }

        public static EditUser GetEditUserInfo(string session)
        {
            EditUser edit = new EditUser();

            int id = Convert.ToInt32(session);

            using (DataBaseContext db = new DataBaseContext())
            {
                var user = db.UserDb.FirstOrDefault(u => u.Id == id);

                edit.Email = user.Email;
                edit.Name = user.Name;
                edit.OldPassword = user.Password;
                edit.Phone = user.Phone;
            }

            return edit;
        }

        public static void EditUser(EditUser edit, string session)
        {
            int id = Convert.ToInt32(session);

            // поиск пользователя в бд
            using (DataBaseContext db = new DataBaseContext())
            {
                DbUser user = db.UserDb.FirstOrDefault(u => u.Id == id);

                if (user != null)
                {
                    user.Email = edit.Email;
                    user.Name = edit.Name;
                    user.Phone = edit.Phone;

                    if (edit.NewPassword != null)
                        user.Password = edit.NewPassword;
                    else
                        user.Password = edit.OldPassword;

                    db.SaveChanges();
                }
            }
        }

        public static bool CheckUserExist(string email)
        {
            bool status = false;

            using (DataBaseContext db = new DataBaseContext())
            {
                var user = db.UserDb.Where(u => u.Email == email).FirstOrDefault();

                if (user != null)
                    status = true;
            }

            return status;
        }

        public static UserModel GetuserInfroByEmail(string email)
        {
            UserModel name = new UserModel();

            using (DataBaseContext db = new DataBaseContext())
            {
                var user = db.UserDb.Where(u => u.Email == email).FirstOrDefault();

                name.Name = user.Name;
                name.Password = user.Password;
            }

            return name;
        }

        public static string GetUserPassword(string email)
        {
            string password = "";

            using (DataBaseContext db = new DataBaseContext())
            {
                password = db.UserDb.Where(u => u.Email == email).FirstOrDefault().Password;
            }

            return password;
        }

        public static void GetBoughtItems(int userId)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var user = db.UserDb.Where(u => u.Id == userId).ToList();
            }
        }

        public static UserModel CheckLoggedIn()
        {
            UserModel name = new UserModel();

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                int id = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                using(DataBaseContext db = new DataBaseContext())
                {
                    name.Name = db.UserDb.Where(u => u.Id == id).FirstOrDefault().Name;
                }   
            }

            return name;
        }
    }
}