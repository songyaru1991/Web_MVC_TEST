using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework2.Models
{
    [Table("MVC_TEST_Category2")]
    public class Category
    {
        [Key]
        public int Cid { get; set; }
        public string CName { get; set; }

        //以下和在Product.cs文件中加上  public virtual Category Cat { get; set; } 功能相同，也可两中都加
        public virtual List<Product> Products { get; set; }
    }
}