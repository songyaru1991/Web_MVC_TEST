using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework2.Models
{
   [Table("MVC_TEST_User2")]
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string UName { get; set; }

        public string Pwd { get; set; }
    }
}