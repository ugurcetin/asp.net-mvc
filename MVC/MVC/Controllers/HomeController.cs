using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            int saat = DateTime.Now.Hour;
            ViewBag.Mesaj = saat < 12 ? "Günaydın" : "Tünaydın";
            return View();
        }
        [HttpGet]

        public ActionResult LCVForm()
        {
            return View();
        }

        [HttpPost]

        public ActionResult LCVForm(davet davet)
        {
            if (ModelState.IsValid)
            {
                //maille organizatöre gönder
                //veri tabanına kaydet
                return View("Tesekkur", davet);
            }
            else
            {
                //hata mesajlarını yazdıracağız
                return View();
            }
        }
    }
}