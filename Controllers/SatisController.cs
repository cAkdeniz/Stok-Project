using StokProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StokProject.Controllers
{
    public class SatisController : Controller
    {
        StokProjectDBEntities db = new StokProjectDBEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SatisYap(Satislar satis)
        {
            db.Satislar.Add(satis);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}