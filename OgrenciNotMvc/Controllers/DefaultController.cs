using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;




namespace OgrenciNotMvc.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbMvcOkulEntities db = new DbMvcOkulEntities(); //nesne oluşturduk tabqloya erişmek için
        public ActionResult Index()
        {
            var values = db.TBLDERSLER.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult YeniDers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniDers(TBLDERSLER p)
        {
            db.TBLDERSLER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var ders = db.TBLDERSLER.Find(id);
            db.TBLDERSLER.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetDers(int id)
        {
            var ders = db.TBLDERSLER.Find(id);
            return View("GetDers", ders);
        }
        public ActionResult Update(TBLDERSLER ders)
        {
            var drs = db.TBLDERSLER.Find(ders.DERSID);
            drs.DERSAD = ders.DERSAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}