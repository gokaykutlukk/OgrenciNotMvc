using OgrenciNotMvc.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciNotMvc.Controllers
{
    public class StudentController : Controller
    {
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        // GET: Student
        public ActionResult Index()
        {
            var values = db.TBLOGRENCILER.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewStudent()
        {
            List<SelectListItem> degerler=(from i in db.TBLKULUPLER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.KULUPAD,
                                               Value = i.KULUPID.ToString()
                                           }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult NewStudent(TBLOGRENCILER p)
        {
            var klp = db.TBLKULUPLER.Where(m => m.KULUPID == p.TBLKULUPLER.KULUPID).FirstOrDefault();
            p.TBLKULUPLER = klp;
            db.TBLOGRENCILER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var student = db.TBLOGRENCILER.Find(id);
            db.TBLOGRENCILER.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetStudent(int id)
        {
            var student = db.TBLOGRENCILER.Find(id);
            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("GetStudent", student);
        }
        public ActionResult Update(TBLOGRENCILER student)
        {
            var std = db.TBLOGRENCILER.Find(student.OGRENCIID);
            std.OGRAD = student.OGRAD;
            std.OGRSOYAD = student.OGRSOYAD;
            std.OGRFOTOGRAF = student.OGRFOTOGRAF;
            std.OGRCINSIYET = student.OGRCINSIYET;
            std.OGRKULUP = student.OGRKULUP;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}