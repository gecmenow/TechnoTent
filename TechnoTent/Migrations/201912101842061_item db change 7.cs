namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class itemdbchange7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbItems", "DescriptionRu", c => c.String());
            AddColumn("dbo.DbItems", "DescriptionUa", c => c.String());
            AddColumn("dbo.DbItems", "DescriptionEn", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DbItems", "DescriptionEn");
            DropColumn("dbo.DbItems", "DescriptionUa");
            DropColumn("dbo.DbItems", "DescriptionRu");
        }
    }
}
