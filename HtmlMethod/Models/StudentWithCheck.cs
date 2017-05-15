using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HtmlMethod.Models
{
    public class StudentWithCheck
    {
        public int Sid { get; set; }

        [Required(ErrorMessage="姓名不能为空")]
        public string SName { get; set; }

        [Range(1,110,ErrorMessage="年龄只能在1~110之间")]
        public int Age { get; set; }

        public string  Sex { get; set; }

        [StringLength(10,ErrorMessage="输入地址过长")]
        public string Address { get; set; }

        [RegularExpression(@"[a-z,0-9,A-Z,_]+@\w+.((com|cn)|(net.cn|net))",ErrorMessage="email格式不正确!")]
        public string Email { get; set; }
    }
}