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
    public class BinhLuansController : Controller
    {
        private FORUM_WEB_V2Entities db = new FORUM_WEB_V2Entities();

        // GET: Admin/BinhLuans
        public ActionResult Index()
        {
            var binhLuan = db.BinhLuan.Include(b => b.BaiDang).Include(b => b.TaiKhoan);
            return View(binhLuan.ToList());
        }

        // GET: Admin/BinhLuans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BinhLuan binhLuan = db.BinhLuan.Find(id);
            if (binhLuan == null)
            {
                return HttpNotFound();
            }
            return View(binhLuan);
        }

        // GET: Admin/BinhLuans/Create
        public ActionResult Create()
        {
            ViewBag.ID_BaiDang = new SelectList(db.BaiDang, "ID_BaiDang", "TieuDe");
            ViewBag.TenDangNhap = new SelectList(db.TaiKhoan, "TenDangNhap", "MatKhau");
            return View();
        }

        // POST: Admin/BinhLuans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_BinhLuan,ID_BaiDang,NoiDung,NgayBinhLuan,TenDangNhap")] BinhLuan binhLuan)
        {
            if (ModelState.IsValid)
            {
                db.BinhLuan.Add(binhLuan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_BaiDang = new SelectList(db.BaiDang, "ID_BaiDang", "TieuDe", binhLuan.ID_BaiDang);
            ViewBag.TenDangNhap = new SelectList(db.TaiKhoan, "TenDangNhap", "MatKhau", binhLuan.TenDangNhap);
            return View(binhLuan);
        }

        // GET: Admin/BinhLuans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BinhLuan binhLuan = db.BinhLuan.Find(id);
            if (binhLuan == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_BaiDang = new SelectList(db.BaiDang, "ID_BaiDang", "TieuDe", binhLuan.ID_BaiDang);
            ViewBag.TenDangNhap = new SelectList(db.TaiKhoan, "TenDangNhap", "MatKhau", binhLuan.TenDangNhap);
            return View(binhLuan);
        }

        // POST: Admin/BinhLuans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_BinhLuan,ID_BaiDang,NoiDung,NgayBinhLuan,TenDangNhap")] BinhLuan binhLuan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(binhLuan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_BaiDang = new SelectList(db.BaiDang, "ID_BaiDang", "TieuDe", binhLuan.ID_BaiDang);
            ViewBag.TenDangNhap = new SelectList(db.TaiKhoan, "TenDangNhap", "MatKhau", binhLuan.TenDangNhap);
            return View(binhLuan);
        }

        // GET: Admin/BinhLuans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BinhLuan binhLuan = db.BinhLuan.Find(id);
            if (binhLuan == null)
            {
                return HttpNotFound();
            }
            return View(binhLuan);
        }

        // POST: Admin/BinhLuans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BinhLuan binhLuan = db.BinhLuan.Find(id);
            db.BinhLuan.Remove(binhLuan);
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
