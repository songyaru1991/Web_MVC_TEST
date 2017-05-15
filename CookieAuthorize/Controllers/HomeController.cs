using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookieAuthorize.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login(string account, string password)
        {
            var cookieName = "mvcAuth";
            if (account == "mvc" && password == "123456")
            {
                if (Response.Cookies.AllKeys.Contains(cookieName))
                {
                    var cookieVal = Response.Cookies[cookieName].Value;
                    HttpContext.Application.Remove(cookieVal);

                    Response.Cookies.Remove(cookieName);
                }

                //登入成功产生一组token
                var token = Guid.NewGuid().ToString();

                //将token存放Application内(实务上应该存放进资料库)
                HttpContext.Application[token] = DateTime.UtcNow.AddHours(1);

                var hc = new HttpCookie(cookieName, token)
                {
                    Expires = DateTime.Now.AddHours(1),
                    HttpOnly = true
                };
                Response.Cookies.Add(hc);
            }
            return RedirectToAction("Index");
        }
    }
}