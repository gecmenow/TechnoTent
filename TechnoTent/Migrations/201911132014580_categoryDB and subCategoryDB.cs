namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryDBandsubCategoryDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbSubCategories", "SubCategoryNameRu", c => c.String());
            AddColumn("dbo.DbSubCategories", "SubCategoryNameUa", c => c.String());
            AddColumn("dbo.DbSubCategories", "SubCategoryNameEn", c => c.String());
            DropColumn("dbo.DbSubCategories", "SubCategoryName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbSubCategories", "SubCategoryName", c => c.String());
            DropColumn("dbo.DbSubCategories", "SubCategoryNameEn");
            DropColumn("dbo.DbSubCategories", "SubCategoryNameUa");
            DropColumn("dbo.DbSubCategories", "SubCategoryNameRu");
        }
    }
}
