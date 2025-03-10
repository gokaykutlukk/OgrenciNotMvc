﻿using OgrenciNotMvc.Models.EntityFramework;
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
    }
}