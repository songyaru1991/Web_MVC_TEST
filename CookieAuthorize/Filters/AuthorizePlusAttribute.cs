using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookieAuthorize.Filters
{
    public class AuthorizePlusAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var token = Convert.ToString(filterContext.HttpContext.Request.
                Cookies["mvcAuth"].Value);
            if (string.IsNullOrWhiteSpace(token))   //判断cookie是否有值
            {
                base.HandleUnauthorizedRequest(filterContext);
            }

            var loginTime = Convert.ToDateTime(filterContext.HttpContext.Application[token]);
            if (loginTime > DateTime.UtcNow)
            {
                //验证通过
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }

    }
}