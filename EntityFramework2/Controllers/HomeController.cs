using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFramework2.Models;
using System.Data.Entity;
using EntityFramework2.Dao;
using Webdiyer.WebControls.Mvc;

namespace EntityFramework2.Controllers
{
    public class HomeController : Controller
    {
        //创建数据上下文对象
        ModelDbContext context = new ModelDbContext();
        ModifyProductDao proDao = new ModifyProductDao();
        int pageSize = 2;
        public ActionResult Index(int pageNumber=1)
        {
           //获取Product实体类对应的表的所有数据，当第一次操作时生成数据库
           //获取所有生成的MVC_TEST_Products表里面的数据
           //  List<Product> lst = context.Products.ToList();  //不加分页时  
            PagedList<Product> lst = context.Products.OrderBy(p => p.Pid).ToPagedList(pageNumber, pageSize);
            ViewBag.Cid = new SelectList(context.Categorys.ToList(), "Cid", "CName");
            return View(lst);//将获取的数据显示到View上
        }

        public ActionResult Add()
        {
            ViewBag.Cid = new SelectList(context.Categorys.ToList(), "Cid", "CName");
            return View();
        }

       
        public ActionResult AddProduct(Product pro)
        {
            if (proDao.AddProduct(pro))
            {
                //return RedirectToAction("Index");
                return Content("<script>alert('新增成功!');location.href='../Home/Index';</script>");
            }
            else
            {
                //return Content("<script>alert('新增失败');history.go(-1);</script>"); 提示框点击确定后页面返回原页面（其实就是后退一步历史记录。）
                return Content("<script>alert('新增失败!');location.href='../Home/Index';</script>");
            }
        }   
     
        public ActionResult Del(int id)   //以路由传参的方式传递过来参数，所以必须使用默认的id接收
        {
            if(proDao.DelProduct(id))
            {
                //return RedirectToAction("Index");
                return Content("<script>alert('删除成功!');location.href='../Home/Index';</script>");
             }
            else{
                return Content("<script>alert('删除失败!');location.href='../Home/Index';</script>");
              }
        }

       

        public ActionResult Edit(int id)
        {
            Product pro = context.Products.Find(id);
            ViewBag.Cid = new SelectList(context.Categorys.ToList(), "Cid", "CName",pro.Cid);//第三个参数为 默认选择隐藏项的值
            return View(pro);

        }

        public ActionResult EditProduct(Product pro)
        {
            if (proDao.EditProduct(pro))
            {
               // return RedirectToAction("Index");
                return Content("<script>alert('修改成功!');location.href='../Home/Index';</script>");
            }
            else
            {
                return Content("<script>alert('修改失败!');location.href='../Home/Index';</script>");
            }
        }

        //public ActionResult Search(string PName)
        //{
        //    List<Product> lst = context.Products.Where(p => p.PName.Contains(PName)).ToList();   //Contains 模糊查询
        //    return View("Index", lst);
        //}

        //pageSize每页显示多少条,pageNumber当前页数
        //在appSettings配置节点下，添加：<add key="pageSize" value="8"/>
        //int pageSize = int.Parse(ConfigurationManager.AppSettings["pageSize"]);
        public ActionResult Search(string PName, int? Cid, int pageNumber=1)
        {         
            PagedList<Product> lst = proDao.Search(PName, Cid, pageNumber, pageSize);
            return View("Index", lst);
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