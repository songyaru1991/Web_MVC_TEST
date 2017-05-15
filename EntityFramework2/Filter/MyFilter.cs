using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFramework2.Filter
{
    public class MyFilter:ActionFilterAttribute,IAuthorizationFilter,IActionFilter,IResultFilter,IExceptionFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.Write("授权过滤器最先执行!");
        }

        //public void OnActionExecuted(ActionExecutedContext filterContext)
        //{
        //    filterContext.HttpContext.Response.Write("动作过滤器方法执行之后执行!");
        //}

        //public void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    filterContext.HttpContext.Response.Write("动作过滤器方法执行之前执行!");
        //}

        //public void OnResultExecuted(ResultExecutedContext filterContext)
        //{
        //    filterContext.HttpContext.Response.Write("结果过滤器方法在视图渲染之后执行!");
        //}

        //public void OnResultExecuting(ResultExecutingContext filterContext)
        //{
        //    filterContext.HttpContext.Response.Write("结果过滤器方法在视图渲染执行之前执行!");
        //}

        public void OnException(ExceptionContext filterContext)
        {
            filterContext.HttpContext.Response.Redirect("/Filter/Error");
        }

        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            throw new NotImplementedException();
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            throw new NotImplementedException();
        }

        void IResultFilter.OnResultExecuted(ResultExecutedContext filterContext)
        {
            throw new NotImplementedException();
        }

        void IResultFilter.OnResultExecuting(ResultExecutingContext filterContext)
        {
            throw new NotImplementedException();
        }
    }
}