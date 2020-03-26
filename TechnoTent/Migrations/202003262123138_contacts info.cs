namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contactsinfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbContacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameRu = c.String(),
                        NameUa = c.String(),
                        NameEn = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DbFooterInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressRu = c.String(),
                        AddressUa = c.String(),
                        AddressEn = c.String(),
                        Phone1 = c.String(),
                        Phone2 = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DbHeaderInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameRu = c.String(),
                        NameUa = c.String(),
                        NameEn = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DbHeaderInfoes");
            DropTable("dbo.DbFooterInfoes");
            DropTable("dbo.DbContacts");
        }
    }
}
