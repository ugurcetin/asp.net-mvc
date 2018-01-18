using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using my_blog.Data;

namespace my_blog.Controllers
{
    public class UyelikController : Controller
    {
        // GET: Uyelik
        public ActionResult Index()
        {
            return View();
        }

        //Formumuzun geliş metodu Post
        //Dikkat ederseniz aynı isimli, iki adet Action var.
        //Üsttekinin metodu boş olduğu için Get oluyor.
        //Alttakinin üzerinde [HttpPost] olduğu için metodu Post oluyor.
        //Burada eğer sayfa içinden bir form gönderimi yapılmışsa, Post olan Action çağrılır.
        //Normal adres üzerinden sayfaya talepte bulunulursa, Get metodlu olan çağrılır.
        [HttpPost]
        public ActionResult YeniUyelik(Uye model, string textBoxDogum, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (String.IsNullOrEmpty(textBoxDogum))
            {
                //Burada Uye modelimizde olmayan bir elemanla çalıştığımız için, kendimiz elle hata
                //mesajını, sayfadaki hata listesine (@Html.ValidationSummary()) ekliyoruz.
                ModelState.AddModelError("textBoxDogum", "Doğum tarihi boş geçilemez");

                //Hata oluşması halinde sayfayı tekrar yüklüyoruz.
                //Böylelikle otomatik olarak hatalar sayfada gösteriliyor.
                return View();
            }
            int yil = int.Parse(textBoxDogum.Substring(6));
            if (yil > 2002)
            {
                ModelState.AddModelError("textBoxDogum", "Yaşınız 12 den küçük olamaz");
                return View();
            }
            Uye uye = new Uye();
            if (file != null)
            {
                //Sunucuya dosya kaydedilirken, sunucunun dosya sistemini, yolunu bilemeyeceğimiz için
                //Server.MapPath() ile sitemizin ana dizinine gelmiş oluruz. Devamında da sitemizdeki
                //yolu tanımlarız.
                file.SaveAs(Server.MapPath("~/Images/") + file.FileName);
                uye.ResimYol = "/Images/" + file.FileName;
            }
            uye.Ad = model.Ad;
            uye.EPosta = model.EPosta;
            uye.Soyad = model.Soyad;
            uye.UyeOlmaTarih = DateTime.Now;
            uye.WebSite = model.WebSite;
            uye.Sifre = model.Sifre;
            using (MyBlogContext db = new MyBlogContext())
            {
                db.Uyes.Add(uye);
                db.SaveChanges();

                //İşlemimiz başarıyla biterse, başarılı olduğuna dair bir sayfaya yönlendiriyoruz.
                return RedirectToAction("UyelikBasarili");
            }
        }

        public ActionResult UyelikBasarili()
        {
            return View();
        }
    }
}