using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using TechnoTent.Cookies;

namespace TechnoTent.Filters
{
    public class AdminAuthAttribute : FilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            AdminCookie admin = new AdminCookie();

            var user = admin.IsAdmin();
            if (user == false)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            AdminCookie admin = new AdminCookie();

            var user = admin.IsAdmin();
            if (user == false)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary {
                    { "controller", "Admin" }, { "action", "Login" }
                   });
            }
        }
    }
}