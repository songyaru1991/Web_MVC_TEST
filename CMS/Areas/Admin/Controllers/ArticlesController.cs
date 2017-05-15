using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMS.Models;
using Microsoft.Security.Application;
using PagedList;

namespace CMS.Areas.Admin.Controllers
{
    public class ArticlesController : Controller
    {
        private CMSDatabaseEntities db = new CMSDatabaseEntities();

        // GET: /Admin/Articles/
        public ActionResult Index(string q,int page=1,int pageSize=3)
        { 
            var model=db.Article.AsQueryable();
            if (string.IsNullOrWhiteSpace(q) == false)
            {
                model = model.Where(d => d.Subject.Contains(q) || d.Summary.Contains(q));
            }

            var result = model.OrderBy(d => d.CreateDate).ToPagedList(page, pageSize);
            return View(result);
        }

        // GET: /Admin/Articles/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Article.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: /Admin/Articles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Articles/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Subject,Summary,ContentText,IsPublich,PublishDate,ViewCount,CreateUser,CreateDate,UpdateUser,UpdateDate")] Article article)
        {
            if (ModelState.IsValid)
            {
                article.ID = Guid.NewGuid();
                article.CreateDate = DateTime.Now;
                article.UpdateDate = DateTime.Now;
                //因為還沒做會員所以先給假的
                article.CreateUser = Guid.Empty;
                article.UpdateUser = Guid.Empty;

                //過濾XSS
                article.ContentText = Sanitizer.GetSafeHtmlFragment(article.ContentText);
                db.Article.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(article);
        }

        // GET: /Admin/Articles/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Article.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: /Admin/Articles/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Subject,Summary,ContentText,IsPublich,PublishDate,ViewCount,CreateUser,CreateDate,UpdateUser,UpdateDate")] Article article)
        {
            if (ModelState.IsValid)
            {
                //過濾XSS
                article.ContentText = Sanitizer.GetSafeHtmlFragment(article.ContentText);

                article.CreateDate = DateTime.Now;
                article.UpdateDate = DateTime.Now;
                //因為還沒做會員所以先給假的
                article.CreateUser = Guid.Empty;
                article.UpdateUser = Guid.Empty;

                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(article);
        }

        // GET: /Admin/Articles/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Article.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: /Admin/Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Article article = db.Article.Find(id);
            db.Article.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
