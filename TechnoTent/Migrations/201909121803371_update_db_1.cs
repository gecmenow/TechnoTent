namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_db_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryNameUa = c.String(),
                        CategoryNameRu = c.String(),
                        CategoryNameEn = c.String(),
                        CategoryImage = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DbSubCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        SubCategoryNameUa = c.String(),
                        SubCategoryNameRu = c.String(),
                        SubCategoryNameEn = c.String(),
                        SubCategoryImage = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DbSubCategories");
            DropTable("dbo.DbCategories");
        }
    }
}
