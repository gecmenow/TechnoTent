namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateditemdb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbItems", "CategoryNameUa", c => c.String());
            AddColumn("dbo.DbItems", "CategoryNameRu", c => c.String());
            AddColumn("dbo.DbItems", "CategoryNameEn", c => c.String());
            AddColumn("dbo.DbItems", "SubCategoryNameUa", c => c.String());
            AddColumn("dbo.DbItems", "SubCategoryNameRu", c => c.String());
            AddColumn("dbo.DbItems", "SubCategoryNameEn", c => c.String());
            AddColumn("dbo.DbItems", "NameUa", c => c.String());
            AddColumn("dbo.DbItems", "NameRu", c => c.String());
            AddColumn("dbo.DbItems", "NameEn", c => c.String());
            AddColumn("dbo.DbItems", "PriceUa", c => c.Double(nullable: false));
            AddColumn("dbo.DbItems", "PriceEn", c => c.Double(nullable: false));
            AddColumn("dbo.DbItems", "Image1", c => c.String());
            AddColumn("dbo.DbItems", "Image2", c => c.String());
            AddColumn("dbo.DbItems", "Image3", c => c.String());
            AddColumn("dbo.DbItems", "Image4", c => c.String());
            AddColumn("dbo.DbItems", "CoveringUa", c => c.String());
            AddColumn("dbo.DbItems", "CoveringRu", c => c.String());
            AddColumn("dbo.DbItems", "CoveringEn", c => c.String());
            AddColumn("dbo.DbItems", "SpecificationUa", c => c.String());
            AddColumn("dbo.DbItems", "SpecificationRu", c => c.String());
            AddColumn("dbo.DbItems", "SpecificationEn", c => c.String());
            AddColumn("dbo.DbItems", "ThreadUa", c => c.String());
            AddColumn("dbo.DbItems", "ThreadRu", c => c.String());
            AddColumn("dbo.DbItems", "ThreadEn", c => c.String());
            AddColumn("dbo.DbItems", "TotalWeight", c => c.String());
            AddColumn("dbo.DbItems", "Width", c => c.String());
            AddColumn("dbo.DbItems", "Winding", c => c.String());
            AddColumn("dbo.DbItems", "Strength", c => c.String());
            AddColumn("dbo.DbItems", "BreakingStrength", c => c.String());
            AddColumn("dbo.DbItems", "AdhesionStrengthUa", c => c.String());
            AddColumn("dbo.DbItems", "AdhesionStrengthRu", c => c.String());
            AddColumn("dbo.DbItems", "AdhesionStrengthEn", c => c.String());
            AddColumn("dbo.DbItems", "Temperature", c => c.String());
            AddColumn("dbo.DbItems", "ColorUa", c => c.String());
            AddColumn("dbo.DbItems", "ColorRu", c => c.String());
            AddColumn("dbo.DbItems", "ColorEn", c => c.String());
            AddColumn("dbo.DbItems", "Description", c => c.String());
            DropColumn("dbo.DbItems", "Name");
            DropColumn("dbo.DbItems", "Image");
            DropColumn("dbo.DbItems", "Text");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbItems", "Text", c => c.String());
            AddColumn("dbo.DbItems", "Image", c => c.String());
            AddColumn("dbo.DbItems", "Name", c => c.String());
            DropColumn("dbo.DbItems", "Description");
            DropColumn("dbo.DbItems", "ColorEn");
            DropColumn("dbo.DbItems", "ColorRu");
            DropColumn("dbo.DbItems", "ColorUa");
            DropColumn("dbo.DbItems", "Temperature");
            DropColumn("dbo.DbItems", "AdhesionStrengthEn");
            DropColumn("dbo.DbItems", "AdhesionStrengthRu");
            DropColumn("dbo.DbItems", "AdhesionStrengthUa");
            DropColumn("dbo.DbItems", "BreakingStrength");
            DropColumn("dbo.DbItems", "Strength");
            DropColumn("dbo.DbItems", "Winding");
            DropColumn("dbo.DbItems", "Width");
            DropColumn("dbo.DbItems", "TotalWeight");
            DropColumn("dbo.DbItems", "ThreadEn");
            DropColumn("dbo.DbItems", "ThreadRu");
            DropColumn("dbo.DbItems", "ThreadUa");
            DropColumn("dbo.DbItems", "SpecificationEn");
            DropColumn("dbo.DbItems", "SpecificationRu");
            DropColumn("dbo.DbItems", "SpecificationUa");
            DropColumn("dbo.DbItems", "CoveringEn");
            DropColumn("dbo.DbItems", "CoveringRu");
            DropColumn("dbo.DbItems", "CoveringUa");
            DropColumn("dbo.DbItems", "Image4");
            DropColumn("dbo.DbItems", "Image3");
            DropColumn("dbo.DbItems", "Image2");
            DropColumn("dbo.DbItems", "Image1");
            DropColumn("dbo.DbItems", "PriceEn");
            DropColumn("dbo.DbItems", "PriceUa");
            DropColumn("dbo.DbItems", "NameEn");
            DropColumn("dbo.DbItems", "NameRu");
            DropColumn("dbo.DbItems", "NameUa");
            DropColumn("dbo.DbItems", "SubCategoryNameEn");
            DropColumn("dbo.DbItems", "SubCategoryNameRu");
            DropColumn("dbo.DbItems", "SubCategoryNameUa");
            DropColumn("dbo.DbItems", "CategoryNameEn");
            DropColumn("dbo.DbItems", "CategoryNameRu");
            DropColumn("dbo.DbItems", "CategoryNameUa");
        }
    }
}
