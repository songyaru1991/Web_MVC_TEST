using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFramework2.Filter;

namespace EntityFramework2.Controllers
{
    [MyFilter]
    public class FilterController : Controller
    {
        //
        // GET: /Filter/
        public ActionResult Index()
        {
            Response.Write("Index方法执行");
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        public string Show(string a)
        {
            return a.ToString();
        }
	}
}