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
    }
}