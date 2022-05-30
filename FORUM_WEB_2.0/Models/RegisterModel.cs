using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FORUM_WEB_2._0.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Bạn cần nhập tài khoản")]
        public string TenDangNhap { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập mật khẩu")]
        [MinLength(6, ErrorMessage = "Mật khẩu ít nhất 6 kí tự !")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$", ErrorMessage = "Mật khẩu phải có ít nhất một chữ cái viết hoa, một chữ cái viết thường, một số và một ký tự đặc biệt")]
        public string MatKhau { set; get; }
        [Required(ErrorMessage = "Tên hiển thị không được để trống !")]
        [RegularExpression(@"^[a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂẾưăạảấầẩẫậắằẳẵặẹẻẽềềểếỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ\s]+$", ErrorMessage ="fail")]
        public string TenHienThi { set; get; }
    }
}