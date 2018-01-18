using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Universite.Models
{
    public enum BasariNotlar
    {
        AA,BA,BB,CB,CC,DC,DD,FF

    }

    public class Kayit
    {
        public int KayitID { get; set; }

        public int DersID { get; set; }

        public int OgrenciID { get; set; }

        public BasariNotlar? BasariNotu { get; set; }

        public virtual Ders Ders { get; set; }

        public virtual Ogrenci Ogrenci { get; set; }
    }
}