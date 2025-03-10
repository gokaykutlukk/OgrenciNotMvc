using OgrenciNotMvc.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}