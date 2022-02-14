using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FORUM_WEB_2._0.Models.FrameWorks;
using FORUM_WEB_2._0.Models;
namespace FORUM_WEB_2._0.Controllers
{
    public class PostPageController : Controller
    {
        int id;
        Models.FrameWorks.FORUM_WEB_V2Entities db = new Models.FrameWorks.FORUM_WEB_V2Entities();
        // GET: PostPage
        public ActionResult PostPage(int id)
        {
            this.id = id;
            var post = db.BaiDang.Where(x => x.ID_BaiDang == id).FirstOrDefault();
            return View(post);
        }
        public ActionResult Comment(int id)
        {
            var lst = new List<FORUM_WEB_2._0.Models.FrameWorks.BinhLuan>();
            lst = db.BinhLuan.Where(x => x.ID_BaiDang == id).ToList();
            return PartialView(lst);
        }
        public ActionResult PostComment()
        {

            return PartialView();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult PostComment(CommentModel model, int id)
        {
            if (ModelState.IsValid)
            {
                var session = (UserLogin)Session[FORUM_WEB_2._0.Common.CommonSession.USER_LOGIN];
                var comment = new BinhLuan()
                {
                    NoiDung = model.NoiDung,
                    TenDangNhap = session.TenDangNhap,
                    NgayBinhLuan = DateTime.Now,
                    ID_BaiDang = id
                };
                db.BinhLuan.Add(comment);
                db.SaveChanges();
                return Redirect(Request.UrlReferrer.ToString());
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult PostThread()
        {
            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult PostThread(ThreadModel model, int id)
        {
            if (ModelState.IsValid)
            {
                var session = (UserLogin)Session[FORUM_WEB_2._0.Common.CommonSession.USER_LOGIN];
                var thread = new BaiDang()
                {
                    TieuDe = model.TieuDe,
                    NoiDung = model.NoiDung,
                    ID_ChuDe = id,
                    TenDangNhap = session.TenDangNhap,
                    NgayDangBai = DateTime.Now
                };
                db.BaiDang.Add(thread);
                db.SaveChanges();
                return RedirectToAction("ThreadPage", "ThreadPage", new { id = id });
            }
            return View();
        }
    }
}