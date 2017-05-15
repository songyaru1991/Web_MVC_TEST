using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EntityFramework2.Models
{
    // 生成数据库，操作数据库(对数据库进行增删改查)
    public class ModelDbContext:DbContext
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

            //多对多的关系时，会生成名为 ProductsOrders 的表,以下方法可以自定义生成表的名称
           //t.Orders为Product类型里的导航属性，a.Products为Order里的导航属性
           modelBuilder.Entity<Product>().HasMany(t => t.Orders).WithMany(a => a.Products).Map(a =>
           {
               a.ToTable("ProductOrder2");   //自定义的表名称
               a.MapLeftKey("Pid");   //对应Product表里的主键 为Pid
               a.MapRightKey("Oid");    //对应Order表里的主键 为Oid
           });

        }

        public DbSet<Product> Products { get; set; }//此属性可以操作Product实体类生成的表

        public DbSet<Category> Categorys { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<User> Users { get; set; }

    }
}