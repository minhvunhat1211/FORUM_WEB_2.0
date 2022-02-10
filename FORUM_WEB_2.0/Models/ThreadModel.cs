using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FORUM_WEB_2._0.Models
{
    public class ThreadModel
    {
        [Required(ErrorMessage = "Bạn cần nhập tiêu đề")]
        public string TieuDe { set; get; }
        [Required(ErrorMessage = "Bạn cần nội dung")]
        /*[AllowHtml]*/
        public string NoiDung { set; get; }
        public DateTime NgayDangBai { set; get; }
    }
}