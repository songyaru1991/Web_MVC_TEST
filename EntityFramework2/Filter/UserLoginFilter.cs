using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFramework2.Filter
{
    public class UserLoginFilter : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (System.Web.HttpContext.Current.Session["userName"] == null)
            {
                filterContext.Result = new RedirectResult("/User/Login");
            }
        }
    }
}