using StokProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StokProject.Controllers
{
    public class UrunController : Controller
    {
        StokProjectDBEntities db = new StokProjectDBEntities();

        public ActionResult Index()
        {
            var urunler = db.Urunler.ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            List<SelectListItem> kategoriler = (from i in db.Kategoriler.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = i.Ad,
                                                    Value = i.Id.ToString()
                                                }).ToList();

            ViewBag.Kategoriler = kategoriler;
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Urunler urun)
        {
            if(ModelState.IsValid)
            {
                var kategori = db.Kategoriler.Where(x => x.Id == urun.KategoriId).FirstOrDefault();
                urun.Kategoriler = kategori;
                db.Urunler.Add(urun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            List<SelectListItem> kategoriler = (from i in db.Kategoriler.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = i.Ad,
                                                    Value = i.Id.ToString()
                                                }).ToList();

            ViewBag.Kategoriler = kategoriler;
            return View(urun);
        }

        public ActionResult Sil(int id)
        {
            var urun = db.Urunler.Find(id);
            db.Urunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            var urun = db.Urunler.Find(id);
            List<SelectListItem> kategoriler = (from i in db.Kategoriler.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = i.Ad,
                                                    Value = i.Id.ToString()
                                                }).ToList();

            ViewBag.Kategoriler = kategoriler;
            return View(urun);
        }

        [HttpPost]
        public ActionResult Guncelle(Urunler urun)
        {
            if(ModelState.IsValid)
            {
                var guncellenecekUrun = db.Urunler.Find(urun.Id);
                guncellenecekUrun.Fiyat = urun.Fiyat;
                guncellenecekUrun.Stok = urun.Stok;
                guncellenecekUrun.KategoriId = urun.KategoriId;
                guncellenecekUrun.Marka = urun.Marka;
                guncellenecekUrun.Ad = urun.Ad;

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            List<SelectListItem> kategoriler = (from i in db.Kategoriler.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = i.Ad,
                                                    Value = i.Id.ToString()
                                                }).ToList();

            ViewBag.Kategoriler = kategoriler;

            return View(urun);
        }
    }
}