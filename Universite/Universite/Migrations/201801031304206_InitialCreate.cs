namespace Universite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ders",
                c => new
                    {
                        DersID = c.Int(nullable: false),
                        DersAdi = c.String(),
                        AKTS = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DersID);
            
            CreateTable(
                "dbo.Kayit",
                c => new
                    {
                        KayitID = c.Int(nullable: false, identity: true),
                        DersID = c.Int(nullable: false),
                        OgrenciID = c.Int(nullable: false),
                        BasariNotu = c.Int(),
                    })
                .PrimaryKey(t => t.KayitID)
                .ForeignKey("dbo.Ders", t => t.DersID, cascadeDelete: true)
                .ForeignKey("dbo.Ogrenci", t => t.OgrenciID, cascadeDelete: true)
                .Index(t => t.DersID)
                .Index(t => t.OgrenciID);
            
            CreateTable(
                "dbo.Ogrenci",
                c => new
                    {
                        OgrenciID = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        Soyad = c.String(),
                        DogumTarihi = c.DateTime(nullable: false),
                        EPosta = c.String(),
                    })
                .PrimaryKey(t => t.OgrenciID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kayit", "OgrenciID", "dbo.Ogrenci");
            DropForeignKey("dbo.Kayit", "DersID", "dbo.Ders");
            DropIndex("dbo.Kayit", new[] { "OgrenciID" });
            DropIndex("dbo.Kayit", new[] { "DersID" });
            DropTable("dbo.Ogrenci");
            DropTable("dbo.Kayit");
            DropTable("dbo.Ders");
        }
    }
}
