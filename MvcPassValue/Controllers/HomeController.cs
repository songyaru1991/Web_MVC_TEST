using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPassValue.Models;

namespace MvcPassValue.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["key"]="您好！";
            ViewBag.vaue = "新年好,";
            TempData["key1"] = "鸡年大吉";//TempData传值能跨方法，ViewData方法不能跨方法
            /*例:
             * 
             *   TempData["key1"] = "鸡年大吉";
             *   return RedirectToAction("getValue"); //转到以下getValue()方法中去
              */
            return View();
        }

        //public string getValue()
        //{
        //    return TempData["key1"].ToString();
        //}

        //传递student对象到视图上
        public ActionResult ViewDataViewBag()
        {
            Student stu = new Student();
            stu.Sid = 1;
            stu.SName = "传递基本类型数据";
            stu.Age = 20;
            ViewData["stu"] = stu;
            ViewBag.stu = stu;
            return View();
        }

        //强类型传值
        public ActionResult ModelDemo()  //右击添加View时，添加带模型的视图，模型选择Student
        {
            Student stu = new Student();
            stu.Sid = 2;
            stu.SName = "传递强类型数据";

            return View(stu);//通过强类型传值,MddelDemo视图上的Model即表示传递过去的stu对象 ex:Model.Sname

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
    }
}