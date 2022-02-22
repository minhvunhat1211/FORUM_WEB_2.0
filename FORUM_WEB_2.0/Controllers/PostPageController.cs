using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FORUM_WEB_2._0.Models.FrameWorks;
using FORUM_WEB_2._0.Models;
using System.IO;

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
        public ActionResult PostComment(CommentModel model, int id, List<HttpPostedFileBase> image)
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
                string path = Server.MapPath("~/Asset/img/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                foreach (HttpPostedFileBase pFile in image)
                {
                    /*var f = Request.Files["image"];
                    string path = Server.MapPath("~/Asset/img/" + f.FileName);
                    f.SaveAs(path);*/

                    if (pFile != null)
                    {
                        string fileName = Path.GetFileName(pFile.FileName);
                        pFile.SaveAs(path + fileName);
                        var Img_Comment = new Img_BinhLuan()
                        {
                            ID_BinhLuan = comment.ID_BinhLuan,
                            TenAnh_Img_BinhLuan = pFile.FileName
                        };
                        db.Img_BinhLuan.Add(Img_Comment);
                    }
                }
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
        public ActionResult PostThread(ThreadModel model, int id, List<HttpPostedFileBase> postedFiles)
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
                string path = Server.MapPath("~/Asset/img/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                foreach (HttpPostedFileBase pFile in postedFiles)
                {
                    /*var f = Request.Files["image"];
                    string path = Server.MapPath("~/Asset/img/" + f.FileName);
                    f.SaveAs(path);*/

                    if (pFile != null)
                    {
                        string fileName = Path.GetFileName(pFile.FileName);
                        pFile.SaveAs(path + fileName);
                        var Img_Post = new Img_BaiDang()
                        {
                            ID_BaiDang = thread.ID_BaiDang,
                            TenAnh_Img_BaiDang = pFile.FileName
                        };
                        db.Img_BaiDang.Add(Img_Post);
                    }
                }

                db.BaiDang.Add(thread);
                db.SaveChanges();
                return RedirectToAction("ThreadPage", "ThreadPage", new { id = id });
            }
            return View();
        }
        public ActionResult Img_Post(int id)
        {
            var lst = new List<FORUM_WEB_2._0.Models.FrameWorks.Img_BaiDang>();
            lst = db.Img_BaiDang.Where(x => x.ID_BaiDang == id).ToList();
            return PartialView(lst);
        }
        public ActionResult Img_Comment(int id_comment)
        {
            var lst = new List<FORUM_WEB_2._0.Models.FrameWorks.Img_BinhLuan>();
            lst = db.Img_BinhLuan.Where(x => x.ID_BinhLuan == id_comment).ToList();
            return PartialView(lst);
        }
        public ActionResult Delete_Post(int id)
        {
            BaiDang baiDang = db.BaiDang.Find(id);
            db.BaiDang.Remove(baiDang);
            db.SaveChanges();
            return RedirectToAction("ThreadPage","ThreadPage", new { id = id });
        }
        public ActionResult Delete_Comment(int id_comment)
        {
            BinhLuan binhLuan = db.BinhLuan.Find(id_comment);
            db.BinhLuan.Remove(binhLuan);
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}