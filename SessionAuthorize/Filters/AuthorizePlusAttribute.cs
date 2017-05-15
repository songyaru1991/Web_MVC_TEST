using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionAuthorize.Filters
{
    public class AuthorizePlusAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (Convert.ToBoolean(filterContext.HttpContext.Session["auth"]))
            {
                //验证成功
            }
            else
            {
                //验证失败，返回401

                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}