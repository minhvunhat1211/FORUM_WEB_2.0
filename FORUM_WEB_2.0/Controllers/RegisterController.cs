using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FORUM_WEB_2._0.Models;
using FORUM_WEB_2._0.Models.FrameWorks;
namespace FORUM_WEB_2._0.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            Models.FrameWorks.FORUM_WEB_V2Entities db = new Models.FrameWorks.FORUM_WEB_V2Entities();
            if (ModelState.IsValid)
            {
                var check = db.TaiKhoan.Count(x => x.TenDangNhap == model.TenDangNhap);
                if (check >= 1)
                {
                    ModelState.AddModelError("", "Tên tài khoản đã tồn tại!");
                    return View(model);
                }
                var user = new TaiKhoan()
                {
                    TenDangNhap = model.TenDangNhap,
                    MatKhau = model.MatKhau,
                    Role = 1,
                    Avatar = "photo-1637548739071-7c24bbcab218.png",
                    NgayGiaNhap = DateTime.Now,
                    TenHienThi = model.TenHienThi
                };
                ModelState.AddModelError("", "Đăng kí thành công !");
                db.TaiKhoan.Add(user);
                db.SaveChanges();
            }
            return View(model);
        }
    }
}