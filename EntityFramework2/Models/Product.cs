using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework2.Models
{
    //在数据库中生成的表名默认为类名加s,即Products
    //若想生成别的表名则加上[Table("P")]
    [Table("MVC_TEST_Product2")]
    public class Product
    {
        [Key]
        public int Pid { get; set; } //[Key]表示生成主键,另外:名称为id 或类名+id（ProductId）时也会默认生成主键

        [Required]                   //表示此项为必填项（非空）
        [StringLength(50)]
        public string PName { get; set; }

        public int? Price { get; set; } //?表示此字段可以为空

        [NotMapped]                  //表示 此属性不在数据库中生成字段
        public int count { get; set; }

    // 产品类型和产品为 一对多的关系

        // [ForeignKey("Cat")]  //若Category表的主键作为此Product的外键时，不采用Cid字段名，则加上此属性，cat为Category表的导航名
        public int Cid { get; set; }    //生成数据库时Category表的主键作为Product表的外键

        //virtual表示延迟加载
        //以下和在Category.cs文件中加上  public virtual List<Product> Products { get; set; } 功能相同，也可两中都加
        public virtual Category Cat { get; set; }   //导航属性,加上Category可以自动建立product和Category表之间的关系

    // 产品订单和产品为 多对多的关系
        //多对多的关系时，会生成名为 ProductsOrders 的表，若想自己命名生成表的名称，则早ProducContext.cs中重写OnModelCreating方法
        public virtual List<Order> Orders { get; set; }
    }
}