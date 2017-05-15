using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HtmlMethod.Models;

namespace HtmlMethod.Controllers
{
    public class HomeController : Controller
    {
        ModelDbContext context = new ModelDbContext();
        public ActionResult Index()
        {
            List<Grade> lst = context.Grades.ToList();
            ViewBag.grade = new SelectList(lst, "Gid","GName");   //获取出来的值以下列列名的方式显示出来
            return View();
        }

        public string Edit(FormCollection col)  //参数方式传值或对象也可以，string UserName，string pwd
        {
            return col["UserName"] + col["pwd"] + col["sex"] + col["body"];
        }

        public ActionResult StudentPage()
        {
            return View();
        }

        public string AddStu(StudentWithCheck stu)
        {
            return stu.SName + stu.Sid + stu.Sex + stu.Address + stu.Email;
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