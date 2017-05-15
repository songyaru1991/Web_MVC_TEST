using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFramework2.Models;
using EntityFramework2.Filter;

namespace EntityFramework2.Controllers
{
    public class UserController : Controller
    {
        ModelDbContext context = new ModelDbContext();
        //
        // GET: /User/
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LoginIn(string userName, string pwd)
        {
            User user = context.Users.Where(p => p.UName == userName && p.Pwd == pwd).FirstOrDefault();

            if (user == null)
            {
                return Content("<script>alert('登录失败');location.href='/User/Login';</script>");
            }
            else
            {
                Session["userName"] = userName;
                return RedirectToAction("                                                       ");
            }
        }

        [UserLoginFilter]
        [UserInfoLogFilter]
        public ActionResult Index()
        {
            return View();
        }

	}
}