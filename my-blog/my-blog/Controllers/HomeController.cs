using my_blog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace my_blog.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        //Son 5 makalenin ana sayfaya yükleneceği Action
        public ActionResult SonBesMakale()
        {
            //Veritabanından yeni bir nesne oluşturuyoruz.
            MyBlogContext db = new MyBlogContext();

            //Veritabanından sorgulamayı Linq ile yapıyoruz.
            //Tarih sırasına göre son makaleleri OrderByDescending ile çekip Take ile de 5 tane almasını istiyoruz.
            List<Makale> makaleListe = db.Makales.OrderByDescending(i => i.Tarih).Take(5).ToList();

            //Normal içeriklerde View döndürürken, burada ise PartialView döndürüyoruz.
            //Ayrıca makaleListe nesnesini de View'de kullanacağımız şekilde model olarak aktarıyoruz.
            return PartialView(makaleListe);
        }

        public ActionResult SonBesYorum()
        {
            MyBlogContext db = new MyBlogContext();

            List<Yorum> yorumListe = db.Yorums.OrderByDescending(i => i.Tarih).Take(5).ToList();

            return PartialView(yorumListe);
        }

        public ActionResult EnCokOnEtiket()
        {
            MyBlogContext db = new MyBlogContext();

           //Etiketleri sorgularken, kaç adet makaleye bağlandığını bulup, ona göre yüksekten,
           //aşağı doğru sıralanmasını sağlıyoruz. Gelen sonuçtan 10 adet alıp, listeye ekliyoruz.
           List<Etiket> etiketListe = (from i in db.Etikets orderby i.Makales.Count() descending select i).Take(10).ToList();

            return PartialView(etiketListe);
        }

        public ActionResult TumMakaleler()
        {
            MyBlogContext db = new MyBlogContext();

            //Tüm makalelerimizi, tarih sırasına göre, büyükten küçüğe olmak üzere çekiyoruz.
            List<Makale> makaleListe = (from i in db.Makales orderby i.Tarih descending select i).ToList();

            return View(makaleListe);
        }

        public ActionResult TumYorumlar()
        {
            MyBlogContext db = new MyBlogContext();

            List<Yorum> yorumListe = (from i in db.Yorums orderby i.Tarih descending select i).ToList();

            return View(yorumListe);
        }

        public ActionResult EtiketinMakaleleri(int etiketId)
        {
            MyBlogContext db = new MyBlogContext();

            var geciciListe = (from i in db.Etikets where i.EtiketId == etiketId select i.Makales).ToList();

            //Burada veri içiçe liste halinde geldiği için, içerideki listeyi [0] indexi ile alıp gönderiyoruz.
            return View(geciciListe[0]);
        }

        public ActionResult MakaleDetay(int makaleId)
        {
            MyBlogContext db = new MyBlogContext();

            //Burada verilen id numarasına göre seçili makaleyi alıyoruz.
            Makale makale = (from i in db.Makales where i.MakaleId == makaleId select i).SingleOrDefault();

            return View(makale);
        }

        public ActionResult YorumMakalesi(int yorumId)
        {
            MyBlogContext db = new MyBlogContext();

            //Burada verilen yorumId numarasına göre ait olduğu makaleyi alıyoruz.
            Makale makale = (from i in db.Yorums where i.YorumId == yorumId select i.Makale).SingleOrDefault();

            return View(makale);
        }
    }
}