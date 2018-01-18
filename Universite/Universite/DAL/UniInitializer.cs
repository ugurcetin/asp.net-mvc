using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Universite.Models;

namespace Universite.DAL
{
    public class UniInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<UniContext>
    {
        protected override void Seed(UniContext context)
        {
            var Ogrenciler = new List<Ogrenci>
            {
                new Ogrenci {Ad="Uğur",Soyad="Çetin",DogumTarihi=DateTime.Parse("17-01-1995"),EPosta="ugurcet@ogr.sakarya.edu.tr" },
                new Ogrenci {Ad="Burak",Soyad="Köken",DogumTarihi=DateTime.Parse("29-06-1995"),EPosta="burakkoken@ogr.sakarya.edu.tr" },
                new Ogrenci {Ad="Emre",Soyad="Ertürk",DogumTarihi=DateTime.Parse("15-04-1995"),EPosta="emreerturk@ogr.sakarya.edu.tr" },
                new Ogrenci {Ad="Kerem",Soyad="Yılmaz",DogumTarihi=DateTime.Parse("29-07-1995"),EPosta="keryilmaz1@ogr.sakarya.edu.tr" }
            };
            Ogrenciler.ForEach(s => context.Ogrenciler.Add(s));
            context.SaveChanges();

            var Dersler = new List<Ders>
            {
                new Ders {DersID=203,DersAdi="Mantık Devreleri",AKTS=5},
                new Ders {DersID=204,DersAdi="Web Programlama",AKTS=5},
                new Ders {DersID=303,DersAdi="Veri İletişimi",AKTS=6},
                new Ders {DersID=304,DersAdi="Bilgisayar Ağları",AKTS=5}
            };
            Dersler.ForEach(s => context.Dersler.Add(s));
            context.SaveChanges();

            var Kayitlar = new List<Kayit>
            {
                new Kayit {DersID=203,OgrenciID=1,BasariNotu=BasariNotlar.BA},
                new Kayit {DersID=204,OgrenciID=1,BasariNotu=BasariNotlar.AA},
                new Kayit {DersID=303,OgrenciID=1,BasariNotu=BasariNotlar.CC},
                new Kayit {DersID=304,OgrenciID=1,BasariNotu=BasariNotlar.CB},
                new Kayit {DersID=203,OgrenciID=2,BasariNotu=BasariNotlar.BB},
                new Kayit {DersID=204,OgrenciID=2,BasariNotu=BasariNotlar.DD},
                new Kayit {DersID=303,OgrenciID=2,BasariNotu=BasariNotlar.CB},
                new Kayit {DersID=304,OgrenciID=2,BasariNotu=BasariNotlar.AA}

            };
            Kayitlar.ForEach(s => context.Kayitlar.Add(s));
            context.SaveChanges();
        }
    }
}