using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FORUM_WEB_2._0.Areas.Admin.Data
{
    public class Admin_LoginModel
    {
        [Required(ErrorMessage = "Bạn cần nhập tài khoản")]
        public string TenDangNhap { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập mật khẩu")]
        public string MatKhau { set; get; }
        public string Avatar { set; get; }
    }
}