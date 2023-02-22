using System;
using System.Collections.Generic;
using StokProject.Models.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StokProject.Controllers
{
    public class MusteriController : Controller
    {
        StokProjectDBEntities db = new StokProjectDBEntities();

        public ActionResult Index(string ara)
        {
            if (!string.IsNullOrEmpty(ara))
            {
                var filtreMusteriler = db.Musteriler.Where(m => m.Ad.Contains(ara)).ToList();
                return View(filtreMusteriler);
            }
            var musteriler = db.Musteriler.ToList();
            return View(musteriler);
        }

        [HttpGet]
        public ActionResult Ekle(string ara)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Musteriler musteri)
        {
            if(ModelState.IsValid)
            {
                db.Musteriler.Add(musteri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(musteri);
        }

        public ActionResult Sil(int id)
        {
            var musteri = db.Musteriler.Find(id);

            db.Musteriler.Remove(musteri);

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            var musteri = db.Musteriler.Find(id);
            return View(musteri);
        }

        [HttpPost]
        public ActionResult Guncelle(Musteriler musteri)
        {
            if(ModelState.IsValid)
            {
                var guncellenecekMusteri = db.Musteriler.Find(musteri.Id);

                guncellenecekMusteri.Ad = musteri.Ad;
                guncellenecekMusteri.Soyad = musteri.Soyad;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(musteri);
        }
    }
}