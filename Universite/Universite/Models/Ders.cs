using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Universite.Models
{
    public class Ders
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DersID { get; set; }

        public string DersAdi { get; set; }

        public int AKTS { get; set; }

        public virtual ICollection<Kayit> Kayitlar { get; set; }
    }
}