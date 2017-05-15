using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EntityFramework1.Models
{
    //数据上下文类，生成和操作数据库，对应Web.config文件中的name="ProductContext" 数据库配置
    public class ProductContext : DbContext
    {
        /*
         //若web.config的数据库连接配置中数据库连接名不想用类名称ProductContext，可以使用以下方法自定义
         public ProductContext()
             : base("conStr")   //使用base调用父类中的构造方法
         {
             Database.SetInitializer<ProductContext>(new DropCreateDatabaseIfModelChanges<ProductContext>());
         }
         */

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SMT");
        }

        public DbSet<Product> Products { get; set; }//此属性可以操作Product实体类生成的表
    }
}