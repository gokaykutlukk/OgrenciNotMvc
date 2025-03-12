using OgrenciNotMvc.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models;

namespace OgrenciNotMvc.Controllers
{
    public class NotController : Controller
    {
        DbMvcOkulEntities db = new DbMvcOkulEntities();

        // GET: Not
        public ActionResult Index()
        {
            var values = db.TBLNOTLAR.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewNote()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewNote(TBLNOTLAR p)
        {
            db.TBLNOTLAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        { var note = db.TBLNOTLAR.Find(id);
            db.TBLNOTLAR.Remove(note);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetNote(int id)
        {
            var note = db.TBLNOTLAR.Find(id);
            return View("GetNote", note);
        }
        [HttpPost]
        public ActionResult GetNote(TBLNOTLAR p,int SINAV1, int SINAV2, int SINAV3, int PROJE,Class1 model)
        {
          
            if (model.islem == "Hesapla")
            {
                int ORTALAMA=(SINAV1 + SINAV2 + SINAV3 + PROJE) / 4;
                ViewBag.ort = ORTALAMA;
            }

            if (model.islem == "Not Güncelle")
            {
                
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
     
        
    }
}