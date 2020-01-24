using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TechnoTent.Filters;
using TechnoTent.Mailing;
using TechnoTent.Models;
using TechnoTent.Models.DataBase;
using TechnoTent.Models.UserModels;
using TechnoTent.Models.ViewModel;

namespace TechnoTent.Controllers
{
    [Culture]
    public class UserController : Controller
    {
        public ActionResult Authentication()
        {
            if(User.Identity.IsAuthenticated)
                return Redirect(Url.Content("~/"));
            else
                return View();
        }

        //public ActionResult Registration()
        //{
        //    return View();
        //}
        //public ActionResult Login()
        //{
        //    return View();
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                int sessionId = 0;

                sessionId = Models.User.LoginUser(login);

                if (sessionId != 0)
                {
                    FormsAuthentication.SetAuthCookie(sessionId.ToString(), login.RememberMe);

                    Loging.CheckCookieCart(sessionId);

                    return Redirect(Url.Content("~/"));
                }
                else
                    ModelState.AddModelError("", Resources.Resource.login_email_pass_err);//Логин или пароль неправильный
            }

            Authentication authentication = new Authentication
            {
                Login = login
            };

            return View(authentication);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(Authentication register)
        {
            if (ModelState.IsValid)
            {
                int session = 0;

                session = Models.User.AddUser(register.Registration);

                if (session != 0)
                {
                    FormsAuthentication.SetAuthCookie(session.ToString(), true);
                    return Redirect(Url.Content("~/"));
                }
                else
                    ModelState.AddModelError("", Resources.Resource.registration_email_err); //вывести сообщение об ошибке, что существует пользователь с таким имейлом
            }

            Authentication authentication = new Authentication
            {
                Registration = register.Registration
            };

            return View(authentication);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return Redirect(Url.Content("~/"));
        }

        [MyAuth]
        public ActionResult Edit()
        {
            EditUser editUser = new EditUser();

            var session = User.Identity.Name;

            editUser = Models.User.GetEditUserInfo(session);

            return View(editUser);
        }

        [MyAuth]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditUser edit)
        {
            var session = User.Identity.Name;

            if (ModelState.IsValid)
                Models.User.EditUser(edit, session);

            var editUser = Models.User.GetEditUserInfo(session);

            return View(editUser);
        }

        [MyAuth]
        public ActionResult Orders()
        {
            var session = Convert.ToInt32(User.Identity.Name);

            var orders = Order.GetOrders(session);

            return View(orders);
        }

        public ActionResult RestorePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RestorePasswordMessage(string email)
        {
            if (email != "")
            {
                if (Models.User.CheckUserExist(email))
                {
                    UserMail.RestorePassword(email);
                    RestorePassword restorePassword = new RestorePassword();
                    restorePassword.Email = email;
                    return View(restorePassword);
                }
                else
                    ModelState.AddModelError("", Resources.Resource.rest_pass_msg); //
            }
            else
                ModelState.AddModelError("", Resources.Resource.rest_pass_msg_email); //

            return RedirectToAction("RestorePassword");
        }
    }
}