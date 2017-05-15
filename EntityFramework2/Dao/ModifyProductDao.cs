using EntityFramework2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Webdiyer.WebControls.Mvc;

namespace EntityFramework2.Dao
{
    public class ModifyProductDao
    {
        ModelDbContext context = new ModelDbContext();

        public bool DelProduct(int id)
        {
            Product pro = context.Products.Find(id);   //.Find()方法参数必须是主键
            context.Products.Remove(pro);
            bool isDel = context.SaveChanges() > 0 ? true : false;
            return isDel;
        }

        public bool AddProduct(Product pro)
        {
            //添加到内存中
            context.Products.Add(pro);
            //保存到数据库中
            bool isAdd=context.SaveChanges() > 0 ? true : false;
            return isAdd; 
        }

        public bool EditProduct(Product pro)
        {
            context.Entry<Product>(pro).State = EntityState.Modified;
            bool isEdit = context.SaveChanges() > 0 ? true : false;
            return isEdit;  
        }

        public PagedList<Product> Search(string PName, int? Cid, int pageNumber, int pageSize)
        {            
            List<Product> productList = context.Products.Where(p => (string.IsNullOrEmpty(PName) ? true : p.PName.Contains(PName)) && (Cid == null ? true : p.Cid == Cid)).ToList();
            PagedList<Product> productPagedList = productList.OrderBy(p => p.Pid).ToPagedList(pageNumber, pageSize);
            return productPagedList;
        }
    }
}