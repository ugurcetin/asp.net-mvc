using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationLinq
{
    class Employee
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

    class LinqOrnek
    {
        public void Aggrate1()
        {
            int[] sayilar = { 4, 8, 8, 3, 9, 0, 7, 8, 2 };

            int toplam = sayilar.Aggregate(0, (total, next) => total + next);

            Console.WriteLine("Sayıların Toplamı : {0}", toplam);
        }

        public void Aggrate2()
        {
            int[] sayilar = { 4, 8, 8, 3, 9, 0, 7, 8, 2 };

            int çiftSayi = sayilar.Aggregate(0, (total, next) => next % 2 == 0 ? total + 1 : total);

            Console.WriteLine("çift sayıların sayısı  {0}", çiftSayi);
        }

        public void Aggrate3()
        {
            string cumle = "bugün 23 nisan neşe doluyor insan";

            string[] kelimeler = cumle.Split(' ');

            string tersCumle = kelimeler.Aggregate((guncel, sonraki) => sonraki + " " + guncel);

            Console.WriteLine(tersCumle);
        }
    }
}
