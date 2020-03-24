using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnoTent.Cookies;
using TechnoTent.Filters;
using TechnoTent.Models;
using TechnoTent.Models.DataBase;
using TechnoTent.Models.ViewModel.Admin;

namespace TechnoTent.Controllers
{
    public class AdminController : Controller
    {
        [AdminAuth]
        // GET: Admin
        public ActionResult Index()
        {
            var data = Admin.GetAdminData();

            return View(data);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(DbAdmin admin)
        {
            if (ModelState.IsValid)
            {
                admin = Admin.Login(admin);

                if (admin != null)
                {
                    AdminCookie adminCookie = new AdminCookie();

                    adminCookie.SetAdminCookie(admin);
                }
                else
                    ModelState.AddModelError("", "Логин или пароль неправильный!");
            }

            return RedirectToAction("Index");
        }

        [AdminAuth]
        [HttpPost]
        public ActionResult Edit(AdminEditVM adminEdit)
        {
            if (ModelState.IsValid)
            {
                AdminCookie adminCookie = new AdminCookie();

                if (adminCookie.IsAdmin())
                {
                    int session = adminCookie.GetAdminSession();

                    if (Admin.Edit(adminEdit, session))
                        return RedirectToAction("Index");
                }
            }

            return View(adminEdit);
        }

        [AdminAuth]
        public ActionResult Logout()
        {
            AdminCookie adminCookie = new AdminCookie();

            if (adminCookie.IsAdmin())
                adminCookie.UnsetAdminCookie();

            return Redirect(Url.Content("~/"));
        }

    }
}