using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FORUM_WEB_2._0.Models;
using FORUM_WEB_2._0.Common;
namespace FORUM_WEB_2._0.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            Models.FrameWorks.FORUM_WEB_V2Entities db = new Models.FrameWorks.FORUM_WEB_V2Entities();
            if (ModelState.IsValid)
            {
                var findUser = db.TaiKhoan.Where(x => x.TenDangNhap == model.TenDangNhap).FirstOrDefault();
                var userSession = new UserLogin();
                userSession.TenDangNhap = model.TenDangNhap;
                userSession.MatKhau = model.MatKhau;
                if (findUser != null)
                {
                    userSession.Avatar = findUser.Avatar;
                }
                var res = db.TaiKhoan.Where(x => x.TenDangNhap == model.TenDangNhap && x.MatKhau == model.MatKhau).Count();
                if (res > 0)
                {
                    Session.Add(CommonSession.USER_LOGIN, userSession);
                    return RedirectToAction("HomePage", "HomePage");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc tài khoản khum đúng!");
                }
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            Session[CommonSession.USER_LOGIN] = null;
            return RedirectToAction("Login", "Login");
        }
    }
}