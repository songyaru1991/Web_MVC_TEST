//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace CMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Article
    {
        public System.Guid ID { get; set; }
        public string Subject { get; set; }
        public string Summary { get; set; }
        public string ContentText { get; set; }
        public bool IsPublich { get; set; }
        public System.DateTime PublishDate { get; set; }
        public int ViewCount { get; set; }
        public System.Guid CreateUser { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<System.Guid> UpdateUser { get; set; }
        public System.DateTime UpdateDate { get; set; }
    }
}
