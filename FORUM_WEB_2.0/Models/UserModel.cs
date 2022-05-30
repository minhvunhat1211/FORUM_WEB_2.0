using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FORUM_WEB_2._0.Models
{
    public class UserModel
    {
        public string TenDangNhap { set; get; }
        public string MatKhau { set; get; }
        public string Avatar { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập tên hiển thị")]
        
        public string TenHienThi { set; get; }
        public int SoLuongBaiDang { get; set; }
        public DateTime NgayGiaNhap { get; set; }
    }
}