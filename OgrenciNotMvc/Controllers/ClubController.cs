using OgrenciNotMvc.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace OgrenciNotMvc.Controllers
{
    public class ClubController : Controller
    {
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        // GET: Club
        public ActionResult Index()
        {
            var values = db.TBLKULUPLER.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewClub()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewClub(TBLKULUPLER p)
        {
            db.TBLKULUPLER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var club = db.TBLKULUPLER.Find(id);
            db.TBLKULUPLER.Remove(club);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetClub(int id)
        {
            var club = db.TBLKULUPLER.Find(id);
            return View("GetClub", club);
        }
        public ActionResult Update(TBLKULUPLER club)
        {
            var clb = db.TBLKULUPLER.Find(club.KULUPID);
            clb.KULUPAD = club.KULUPAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}