using StokProject.Models;
using StokProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StokProject.Controllers
{
    public class KategoriController : Controller
    {
        StokProjectDBEntities db = new StokProjectDBEntities();

        public ActionResult Index()
        {
            var kategoriler = db.Kategoriler.ToList();
            return View(kategoriler);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Kategoriler kategori)
        {
            if(ModelState.IsValid)
            {
                db.Kategoriler.Add(kategori);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategori);
        }

        public ActionResult Sil(int id)
        {
            var kategori = db.Kategoriler.Find(id);
            db.Kategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            var kategori = db.Kategoriler.Find(id);
            return View(kategori);
        }

        [HttpPost]
        public ActionResult Guncelle(Kategoriler kategori)
        {
            if(ModelState.IsValid)
            {
                var guncellenecekKategori = db.Kategoriler.Find(kategori.Id);
                guncellenecekKategori.Ad = kategori.Ad;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategori);
        }
    }
}