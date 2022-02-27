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
    public class BaoCaosController : Controller
    {
        private FORUM_WEB_V2Entities db = new FORUM_WEB_V2Entities();

        // GET: Admin/BaoCaos
        public ActionResult Index()
        {
            var baoCao = db.BaoCao.Include(b => b.TaiKhoan);
            return View(baoCao.ToList());
        }

        // GET: Admin/BaoCaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaoCao baoCao = db.BaoCao.Find(id);
            if (baoCao == null)
            {
                return HttpNotFound();
            }
            return View(baoCao);
        }

        // GET: Admin/BaoCaos/Create
        public ActionResult Create()
        {
            ViewBag.NguoiBaoCao = new SelectList(db.TaiKhoan, "TenDangNhap", "MatKhau");
            return View();
        }

        // POST: Admin/BaoCaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_BaoCao,NguoiBaoCao,NoiDung")] BaoCao baoCao)
        {
            if (ModelState.IsValid)
            {
                db.BaoCao.Add(baoCao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NguoiBaoCao = new SelectList(db.TaiKhoan, "TenDangNhap", "MatKhau", baoCao.NguoiBaoCao);
            return View(baoCao);
        }

        // GET: Admin/BaoCaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaoCao baoCao = db.BaoCao.Find(id);
            if (baoCao == null)
            {
                return HttpNotFound();
            }
            ViewBag.NguoiBaoCao = new SelectList(db.TaiKhoan, "TenDangNhap", "MatKhau", baoCao.NguoiBaoCao);
            return View(baoCao);
        }

        // POST: Admin/BaoCaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_BaoCao,NguoiBaoCao,NoiDung")] BaoCao baoCao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baoCao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NguoiBaoCao = new SelectList(db.TaiKhoan, "TenDangNhap", "MatKhau", baoCao.NguoiBaoCao);
            return View(baoCao);
        }

        // GET: Admin/BaoCaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaoCao baoCao = db.BaoCao.Find(id);
            if (baoCao == null)
            {
                return HttpNotFound();
            }
            return View(baoCao);
        }

        // POST: Admin/BaoCaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaoCao baoCao = db.BaoCao.Find(id);
            db.BaoCao.Remove(baoCao);
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
