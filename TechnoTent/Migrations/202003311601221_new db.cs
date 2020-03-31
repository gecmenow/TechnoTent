namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbContactsKievInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressUa = c.String(),
                        AddressRu = c.String(),
                        AddressEn = c.String(),
                        PhoneNameUa = c.String(),
                        PhoneNameRu = c.String(),
                        PhoneNameEn = c.String(),
                        PhoneNumber = c.String(),
                        ViberNameUa = c.String(),
                        ViberNameRu = c.String(),
                        ViberNameEn = c.String(),
                        ViberNumber = c.String(),
                        WorkTimeUa = c.String(),
                        WorkTimeEn = c.String(),
                        WorkTimeRu = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DbKonstantinovkaContactsInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressUa = c.String(),
                        AddressRu = c.String(),
                        AddressEn = c.String(),
                        PhoneNameUa = c.String(),
                        PhoneNameRu = c.String(),
                        PhoneNameEn = c.String(),
                        PhoneNumber = c.String(),
                        ViberNameUa = c.String(),
                        ViberNameRu = c.String(),
                        ViberNameEn = c.String(),
                        ViberNumber = c.String(),
                        WorkTimeUa = c.String(),
                        WorkTimeEn = c.String(),
                        WorkTimeRu = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DbKonstantinovkaContactsInfoes");
            DropTable("dbo.DbContactsKievInfoes");
        }
    }
}
