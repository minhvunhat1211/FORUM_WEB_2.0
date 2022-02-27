using FORUM_WEB_2._0.Areas.Admin.Data;
using FORUM_WEB_2._0.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FORUM_WEB_2._0.Areas.Admin.Controllers
{
    public class Admin_LoginController : Controller
    {
        public ActionResult Admin_Login()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session[CommonSession.ADMIN_LOGIN] = null;
            return RedirectToAction("Admin_Login", "Admin_Login");
        }
        [HttpPost]
        // GET: Admin/Admin_Login
        public ActionResult Admin_Login(Admin_LoginModel model)
        {
            Models.FrameWorks.FORUM_WEB_V2Entities db = new Models.FrameWorks.FORUM_WEB_V2Entities();
            if (ModelState.IsValid)
            {
                var findAdmin = db.TaiKhoan.Where(x => x.TenDangNhap == model.TenDangNhap).FirstOrDefault();
                var adminSession = new AdminLogin();
                adminSession.TenDangNhap = model.TenDangNhap;
                adminSession.MatKhau = model.MatKhau;
                if (findAdmin != null)
                {
                    adminSession.Avatar = findAdmin.Avatar;
                }
                var res = db.TaiKhoan.Where(x => x.TenDangNhap == model.TenDangNhap && x.MatKhau == model.MatKhau && x.Role == 1).Count();
                if (res > 0)
                {
                    Session.Add(CommonSession.ADMIN_LOGIN, adminSession);
                    return RedirectToAction("Index", "TaiKhoans");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc tài khoản khum đúng!");
                }
            }
            return View(model);
        }
    }
}