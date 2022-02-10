using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FORUM_WEB_2._0.Models;
using FORUM_WEB_2._0.Models.FrameWorks;
namespace FORUM_WEB_2._0.Controllers
{
    public class ProfilePageController : Controller
    {
        // GET: ProfilePage
        public ActionResult ProfileUser(string tenDangNhap)
        {
            Models.FrameWorks.FORUM_WEB_V2Entities db = new Models.FrameWorks.FORUM_WEB_V2Entities();
            var user = db.TaiKhoan.Where(x => x.TenDangNhap == tenDangNhap).FirstOrDefault();
            return View(user);
        }
        [HttpPost]
        public ActionResult ProfileUser(UserModel model, string tenDangNhap)
        {
            Models.FrameWorks.FORUM_WEB_V2Entities db = new Models.FrameWorks.FORUM_WEB_V2Entities();
            var session = (UserLogin)Session[FORUM_WEB_2._0.Common.CommonSession.USER_LOGIN];
            var f = Request.Files["image"];
            var update = db.TaiKhoan.FirstOrDefault(x => x.TenDangNhap == session.TenDangNhap);
            if (f.FileName != "")
            {
                string path = Server.MapPath("~/Asset/img/" + f.FileName);
                f.SaveAs(path);
                update.Avatar = f.FileName;
            }
            update.TenHienThi = model.TenHienThi;
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}