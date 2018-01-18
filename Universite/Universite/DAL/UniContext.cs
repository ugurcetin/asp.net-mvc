using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Universite.Models;

namespace Universite.DAL
{
    public class UniContext : DbContext
    {
        public UniContext() : base("UniContext")
        {
        }

        public DbSet<Ogrenci> Ogrenciler { get; set; }

        public DbSet<Kayit> Kayitlar { get; set; }

        public DbSet<Ders> Dersler { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();/* tabloların sonuna çoğul eki eklemiyor*/    
        }
    }
}