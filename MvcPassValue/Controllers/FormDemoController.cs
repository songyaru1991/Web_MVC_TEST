using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPassValue.Models;

namespace MvcPassValue.Controllers
{
    public class FormDemoController : Controller
    {
        //
        // GET: /FormDemo/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 使用request获取表单的值
        /// </summary>
        /// <returns></returns>
        public string getStudent()
        {
            string sName = Request["Sname"];
            string sex = Request["sex"];
            string inte = Request["inte"];

            return "姓名:" + sName + "性别:" + sex + "兴趣:" + inte;
        }

        /// <summary>
        /// 通过参数获取表单提交的数据
        /// </summary>
        /// <param name="SName"></param>
        /// <param name="sex"></param>
        /// <returns></returns>
        public string getStudentDemo1(string SName, string sex)
        {
            return "姓名:" + SName + "性别:" + sex + "兴趣:" + Request["inte"];
        }

        /// <summary>
        /// 通过对象的方式获取表单的数据（View中标签的name和Mode中属性名称一样）
        /// </summary>
        /// <returns></returns>
        public string getStudentDemo2(Student stu)
        {
            stu.inte = Request["inte"];  //获取复选框选中的值
            return "姓名:" + stu.SName + "性别:" + stu.sex + "兴趣:" + stu.inte;
        }


        public string getStudentDemo3(FormCollection col)
        {
            return "姓名:" + col["SName"] + "性别:" + col["sex"] + "兴趣:" + col["inte"];
        }
    }
}