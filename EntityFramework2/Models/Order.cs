using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework2.Models
{
   [Table("MVC_TEST_Order2")]
    public class Order
    {
        [Key]
        public int Oid { get; set; }

        public string OName { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}