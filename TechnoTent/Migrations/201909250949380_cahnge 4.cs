namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cahnge4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbSubCategories", "SubCategoryName", c => c.String());
            DropColumn("dbo.DbSubCategories", "SubCategoryNameUa");
            DropColumn("dbo.DbSubCategories", "SubCategoryNameRu");
            DropColumn("dbo.DbSubCategories", "SubCategoryNameEn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbSubCategories", "SubCategoryNameEn", c => c.String());
            AddColumn("dbo.DbSubCategories", "SubCategoryNameRu", c => c.String());
            AddColumn("dbo.DbSubCategories", "SubCategoryNameUa", c => c.String());
            DropColumn("dbo.DbSubCategories", "SubCategoryName");
        }
    }
}
