namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateitemsdb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbItems", "ManufacturerUa", c => c.String());
            AddColumn("dbo.DbItems", "ManufacturerRu", c => c.String());
            AddColumn("dbo.DbItems", "ManufacturerEn", c => c.String());
            AddColumn("dbo.DbItems", "CountryOfOriginUa", c => c.String());
            AddColumn("dbo.DbItems", "CountryOfOriginRu", c => c.String());
            AddColumn("dbo.DbItems", "CountryOfOriginEn", c => c.String());
            AddColumn("dbo.DbItems", "SeasonUa", c => c.String());
            AddColumn("dbo.DbItems", "SeasonRu", c => c.String());
            AddColumn("dbo.DbItems", "SeasonEn", c => c.String());
            AddColumn("dbo.DbItems", "MaterialUa", c => c.String());
            AddColumn("dbo.DbItems", "MaterialRu", c => c.String());
            AddColumn("dbo.DbItems", "MaterialEn", c => c.String());
            AddColumn("dbo.DbItems", "DensityUa", c => c.String());
            AddColumn("dbo.DbItems", "DensityRu", c => c.String());
            AddColumn("dbo.DbItems", "DensityEn", c => c.String());
            AddColumn("dbo.DbItems", "SizeUa", c => c.String());
            AddColumn("dbo.DbItems", "SizeRu", c => c.String());
            AddColumn("dbo.DbItems", "SizeEn", c => c.String());
            AddColumn("dbo.DbItems", "WarrantyPeriodUa", c => c.String());
            AddColumn("dbo.DbItems", "WarrantyPeriodRu", c => c.String());
            AddColumn("dbo.DbItems", "WarrantyPeriodEn", c => c.String());
            AddColumn("dbo.DbItems", "PreparationTimeUa", c => c.String());
            AddColumn("dbo.DbItems", "PreparationTimeRu", c => c.String());
            AddColumn("dbo.DbItems", "PreparationTimeEn", c => c.String());
            AddColumn("dbo.DbItems", "SparesTypeUa", c => c.String());
            AddColumn("dbo.DbItems", "SparesTypeRu", c => c.String());
            AddColumn("dbo.DbItems", "SparesTypeEn", c => c.String());
            AddColumn("dbo.DbItems", "TextileProductTypeUa", c => c.String());
            AddColumn("dbo.DbItems", "TextileProductTypeRu", c => c.String());
            AddColumn("dbo.DbItems", "TextileProductTypeEn", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DbItems", "TextileProductTypeEn");
            DropColumn("dbo.DbItems", "TextileProductTypeRu");
            DropColumn("dbo.DbItems", "TextileProductTypeUa");
            DropColumn("dbo.DbItems", "SparesTypeEn");
            DropColumn("dbo.DbItems", "SparesTypeRu");
            DropColumn("dbo.DbItems", "SparesTypeUa");
            DropColumn("dbo.DbItems", "PreparationTimeEn");
            DropColumn("dbo.DbItems", "PreparationTimeRu");
            DropColumn("dbo.DbItems", "PreparationTimeUa");
            DropColumn("dbo.DbItems", "WarrantyPeriodEn");
            DropColumn("dbo.DbItems", "WarrantyPeriodRu");
            DropColumn("dbo.DbItems", "WarrantyPeriodUa");
            DropColumn("dbo.DbItems", "SizeEn");
            DropColumn("dbo.DbItems", "SizeRu");
            DropColumn("dbo.DbItems", "SizeUa");
            DropColumn("dbo.DbItems", "DensityEn");
            DropColumn("dbo.DbItems", "DensityRu");
            DropColumn("dbo.DbItems", "DensityUa");
            DropColumn("dbo.DbItems", "MaterialEn");
            DropColumn("dbo.DbItems", "MaterialRu");
            DropColumn("dbo.DbItems", "MaterialUa");
            DropColumn("dbo.DbItems", "SeasonEn");
            DropColumn("dbo.DbItems", "SeasonRu");
            DropColumn("dbo.DbItems", "SeasonUa");
            DropColumn("dbo.DbItems", "CountryOfOriginEn");
            DropColumn("dbo.DbItems", "CountryOfOriginRu");
            DropColumn("dbo.DbItems", "CountryOfOriginUa");
            DropColumn("dbo.DbItems", "ManufacturerEn");
            DropColumn("dbo.DbItems", "ManufacturerRu");
            DropColumn("dbo.DbItems", "ManufacturerUa");
        }
    }
}
