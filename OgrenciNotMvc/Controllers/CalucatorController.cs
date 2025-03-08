using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciNotMvc.Controllers
{
    public class CalucatorController : Controller
    {
        // GET: Calucator
        public ActionResult Index(int sayi1=0,int sayi2=0)
        {
            int toplam = sayi1 + sayi2;
            ViewBag.toplam = toplam;
            return View();
        }
    }
}