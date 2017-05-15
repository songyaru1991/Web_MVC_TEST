using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFramework2.Models;

namespace EntityFramework2.Controllers
{
    public class MvcAjaxController : Controller
    {
        //
        // GET: /MvcAjax/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult show()
        {
            List<Product> lst=new List<Product>(){
                new Product{Pid=1,PName="花生"},
                new Product{Pid=2,PName="地瓜"}
            };
            return Json(lst);
        }

        public string getContent()
        {
            return "ok";
        }

        public ActionResult Add(string PName)
        {
            ViewBag.name = PName;
            return PartialView();// 返回分部视图
        }
        public ActionResult Route(string year,string month,string day)
        {
            List<string> lst = new List<string>();
            lst.Add(year);
            lst.Add(month);
            lst.Add(day);
            return View(lst);
        }
	}
}