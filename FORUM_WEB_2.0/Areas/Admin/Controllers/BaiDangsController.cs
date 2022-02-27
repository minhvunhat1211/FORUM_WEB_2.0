using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FORUM_WEB_2._0.Models.FrameWorks;

namespace FORUM_WEB_2._0.Areas.Admin.Controllers
{
    public class BaiDangsController : Controller
    {
        private FORUM_WEB_V2Entities db = new FORUM_WEB_V2Entities();

        // GET: Admin/BaiDangs
        public ActionResult Index()
        {
            var baiDang = db.BaiDang.Include(b => b.ChuDe).Include(b => b.TaiKhoan).Include(b => b.Top_BinhLuan);
            return View(baiDang.ToList());
        }

        // GET: Admin/BaiDangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiDang baiDang = db.BaiDang.Find(id);
            if (baiDang == null)
            {
                return HttpNotFound();
            }
            return View(baiDang);
        }

        // GET: Admin/BaiDangs/Create
        public ActionResult Create()
        {
            ViewBag.ID_ChuDe = new SelectList(db.ChuDe, "ID_ChuDe", "TenChuDe");
            ViewBag.TenDangNhap = new SelectList(db.TaiKhoan, "TenDangNhap", "MatKhau");
            ViewBag.ID_BaiDang = new SelectList(db.Top_BinhLuan, "ID_BaiDang", "ID_BaiDang");
            return View();
        }

        // POST: Admin/BaiDangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_BaiDang,TieuDe,NoiDung,NgayDangBai,ID_ChuDe,TenDangNhap")] BaiDang baiDang)
        {
            if (ModelState.IsValid)
            {
                db.BaiDang.Add(baiDang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ChuDe = new SelectList(db.ChuDe, "ID_ChuDe", "TenChuDe", baiDang.ID_ChuDe);
            ViewBag.TenDangNhap = new SelectList(db.TaiKhoan, "TenDangNhap", "MatKhau", baiDang.TenDangNhap);
            ViewBag.ID_BaiDang = new SelectList(db.Top_BinhLuan, "ID_BaiDang", "ID_BaiDang", baiDang.ID_BaiDang);
            return View(baiDang);
        }

        // GET: Admin/BaiDangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiDang baiDang = db.BaiDang.Find(id);
            if (baiDang == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ChuDe = new SelectList(db.ChuDe, "ID_ChuDe", "TenChuDe", baiDang.ID_ChuDe);
            ViewBag.TenDangNhap = new SelectList(db.TaiKhoan, "TenDangNhap", "MatKhau", baiDang.TenDangNhap);
            ViewBag.ID_BaiDang = new SelectList(db.Top_BinhLuan, "ID_BaiDang", "ID_BaiDang", baiDang.ID_BaiDang);
            return View(baiDang);
        }

        // POST: Admin/BaiDangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_BaiDang,TieuDe,NoiDung,NgayDangBai,ID_ChuDe,TenDangNhap")] BaiDang baiDang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baiDang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ChuDe = new SelectList(db.ChuDe, "ID_ChuDe", "TenChuDe", baiDang.ID_ChuDe);
            ViewBag.TenDangNhap = new SelectList(db.TaiKhoan, "TenDangNhap", "MatKhau", baiDang.TenDangNhap);
            ViewBag.ID_BaiDang = new SelectList(db.Top_BinhLuan, "ID_BaiDang", "ID_BaiDang", baiDang.ID_BaiDang);
            return View(baiDang);
        }

        // GET: Admin/BaiDangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiDang baiDang = db.BaiDang.Find(id);
            if (baiDang == null)
            {
                return HttpNotFound();
            }
            return View(baiDang);
        }

        // POST: Admin/BaiDangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaiDang baiDang = db.BaiDang.Find(id);
            db.BaiDang.Remove(baiDang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
