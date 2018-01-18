using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Universite.DAL;
using Universite.Models;
using PagedList;

namespace Universite.Controllers
{
    public class OgrenciController : Controller
    {
        private UniContext db = new UniContext();

        // GET: Ogrenci
        public ActionResult Index(string siralama, string arama, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = siralama;
            ViewBag.NameSortParm = String.IsNullOrEmpty(siralama) ? "soyadi_azalan" : "";
            ViewBag.DateSortParm = siralama == "tarih_artan" ? "tarih_azalan" : "tarih_artan";

            if(arama !=null)
            {
                page = 1;
            }
            else { arama = currentFilter; }
            ViewBag.CurrentFilter = arama;

            var ogrenciler = from s in db.Ogrenciler select s;

            //arama
            if(!String.IsNullOrEmpty(arama))
            {
                ogrenciler = ogrenciler.Where(s => s.Soyad.ToUpper().Contains(arama.ToUpper())
                    ||
                    s.Ad.ToUpper().Contains(arama.ToUpper()));
            }

            //sıralama
            switch(siralama)
            {
                case "soyadi_azalan":
                    ogrenciler = ogrenciler.OrderByDescending(s => s.Soyad);
                    break;
                case "tarih_artan":
                    ogrenciler = ogrenciler.OrderBy(s => s.DogumTarihi);
                    break;
                case "tarih_azalan":
                    ogrenciler = ogrenciler.OrderByDescending(s => s.DogumTarihi);
                    break;
                default:
                    ogrenciler = ogrenciler.OrderBy(s => s.Soyad);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(ogrenciler.ToPagedList(pageNumber, pageSize));
        }

        // GET: Ogrenci/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenci ogrenci = db.Ogrenciler.Find(id);
            if (ogrenci == null)
            {
                return HttpNotFound();
            }
            return View(ogrenci);
        }

        // GET: Ogrenci/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ogrenci/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OgrenciID,Ad,Soyad,DogumTarihi,EPosta")] Ogrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                db.Ogrenciler.Add(ogrenci);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ogrenci);
        }

        // GET: Ogrenci/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenci ogrenci = db.Ogrenciler.Find(id);
            if (ogrenci == null)
            {
                return HttpNotFound();
            }
            return View(ogrenci);
        }

        // POST: Ogrenci/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OgrenciID,Ad,Soyad,DogumTarihi,EPosta")] Ogrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogrenci).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ogrenci);
        }

        // GET: Ogrenci/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenci ogrenci = db.Ogrenciler.Find(id);
            if (ogrenci == null)
            {
                return HttpNotFound();
            }
            return View(ogrenci);
        }

        // POST: Ogrenci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ogrenci ogrenci = db.Ogrenciler.Find(id);
            db.Ogrenciler.Remove(ogrenci);
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
