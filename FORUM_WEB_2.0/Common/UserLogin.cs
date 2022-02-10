using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FORUM_WEB_2._0
{
    [Serializable]
    public class UserLogin {
        public string TenDangNhap { set; get; }
        public string MatKhau { set; get; }
        public string Avatar { set; get; }

    }
}