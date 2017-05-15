using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HtmlMethod.Models
{
    [Table("MVC_TEST_GRADE")]
    public class Grade
    {
        [Key]
        public int Gid { get; set; }

        [StringLength(50)]
        public string GName { get; set; }

    }
}