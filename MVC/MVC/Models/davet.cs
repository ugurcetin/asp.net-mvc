using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class davet
    {
        [Required (ErrorMessage ="Lütfen AD SOYAD bilginizi giriniz")]
        public string AdSoyad { get; set; }

        [Required(ErrorMessage = "Lütfen EPOSTA bilginizi giriniz")]
        [RegularExpression (".+\\@.+\\..+" , ErrorMessage = "Lütfen geçerli bir EPOSTA bilgisi giriniz")]
        public string EPosta { get; set; }

        [Required(ErrorMessage = "Lütfen TELEFON bilginizi giriniz")]
        public string Telefon { get; set; }

        public bool? KatilacakMi { get; set; }



    }
}