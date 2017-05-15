using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework1.Models
{
    public class Product   //Product实体类会生成一个名为Product的表
    {
        [Key]
        public int Pid { get; set; } //[Key]表示生成主键,另外:名称为id 或类名+id（ProductId）时也会默认生成主键

        [Required]                   //表示此项为必填项（非空）
        [StringLength(50)]
        public string PName { get; set; }

        public int? Price { get; set; } //?表示此字段可以为空

        [NotMapped]                  //表示 此属性不在数据库中生成字段
        public int count { get; set; }
    }
}