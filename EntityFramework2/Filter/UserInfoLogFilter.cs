using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace EntityFramework2.Filter
{
    public class UserInfoLogFilter : FilterAttribute, IActionFilter
    {
        /// <summary>
        /// 在执行方法之前调用,记录访问者 访问时间，访问IP
        /// </summary>
        /// <param name="filterContext"></param>

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
          //定义日志文件路径
            string filePath = filterContext.HttpContext.Server.MapPath(@"~\log.txt");
            var request = filterContext.HttpContext.Request;
            //定义日志信息IP 信息 访问URl
            string info= string.Format("{0}\t{1}\t{2}", request.UserHostAddress,DateTime.Now.ToString(),request.RawUrl);

            //写入日志信息
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(info);
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
           
        }
    }
}