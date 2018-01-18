using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Universite.Models
{
    public class Ogrenci
    {
        public int OgrenciID { get; set; }

        public string Ad { get; set; }

        public string Soyad { get; set; }

        [DisplayFormat(DataFormatString="{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name="Doğum Tarihi")]
        public DateTime DogumTarihi { get; set; }

        public string EPosta { get; set; }

        public string OgrenciNo { get; set; }

        public virtual ICollection<Kayit> Kayitlar { get; set; }
    }
}