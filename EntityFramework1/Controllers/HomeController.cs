using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFramework1.Models;
using System.Data.Entity;

namespace EntityFramework1.Controllers
{
    public class HomeController : Controller
    {
        ProductContext context = new ProductContext();

        public ActionResult Index()
        {
            //获取Product表里面所有的数据，此时context数据库上下午对象会在数据库中创建名为Product的表
            List<Product> list = context.Products.ToList();

            return View(list);
        }

        public ActionResult Add()
        {
            return View();
        }

        //单表添加   只有Products表时的添加方法
        public ActionResult AddProduct(Product pro)
        {
            //添加到内存中
            context.Products.Add(pro);
            //保存到数据库中
            context.SaveChanges();
            return RedirectToAction("Index");  //跳转到Index方法
        }

        //单表删除
        public ActionResult Del(int id)
        {
            Product pro = context.Products.Find(id);   //.Find()方法参数必须是主键
            context.Products.Remove(pro);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Product pro = context.Products.Find(id);
            return View(pro);

        }

        public ActionResult EditProduct(Product pro)
        {
            context.Entry<Product>(pro).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");  //跳转到Index方法
        }

        public ActionResult Search(string PName)
        {
            List<Product> lst = context.Products.Where(p => p.PName.Contains(PName)).ToList();   //Contains 模糊查询
            return View("Index",lst);
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