namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateditemsdb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbItems", "WarrantyPeriod", c => c.String());
            AddColumn("dbo.DbItems", "PreparationTime", c => c.String());
            AddColumn("dbo.DbItems", "SpecificationeUa", c => c.String());
            AddColumn("dbo.DbItems", "SpecificationeRu", c => c.String());
            AddColumn("dbo.DbItems", "SpecificationeEn", c => c.String());
            DropColumn("dbo.DbItems", "WarrantyPeriodUa");
            DropColumn("dbo.DbItems", "WarrantyPeriodRu");
            DropColumn("dbo.DbItems", "WarrantyPeriodEn");
            DropColumn("dbo.DbItems", "PreparationTimeUa");
            DropColumn("dbo.DbItems", "PreparationTimeRu");
            DropColumn("dbo.DbItems", "PreparationTimeEn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbItems", "PreparationTimeEn", c => c.String());
            AddColumn("dbo.DbItems", "PreparationTimeRu", c => c.String());
            AddColumn("dbo.DbItems", "PreparationTimeUa", c => c.String());
            AddColumn("dbo.DbItems", "WarrantyPeriodEn", c => c.String());
            AddColumn("dbo.DbItems", "WarrantyPeriodRu", c => c.String());
            AddColumn("dbo.DbItems", "WarrantyPeriodUa", c => c.String());
            DropColumn("dbo.DbItems", "SpecificationeEn");
            DropColumn("dbo.DbItems", "SpecificationeRu");
            DropColumn("dbo.DbItems", "SpecificationeUa");
            DropColumn("dbo.DbItems", "PreparationTime");
            DropColumn("dbo.DbItems", "WarrantyPeriod");
        }
    }
}
