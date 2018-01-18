namespace Universite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OgrenciNoEkleme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ogrenci", "OgrenciNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ogrenci", "OgrenciNo");
        }
    }
}
