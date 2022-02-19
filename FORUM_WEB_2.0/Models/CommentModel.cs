using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FORUM_WEB_2._0.Models
{
    public class CommentModel
    {
        
        public string NoiDung { set; get; }
        public DateTime NgayBinhLuan { set; get; }
    }
}