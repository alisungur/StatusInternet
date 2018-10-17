namespace InternetDurum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Yaz : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblInternet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GelenNet = c.String(),
                        GidenNet = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblInternet");
        }
    }
}
