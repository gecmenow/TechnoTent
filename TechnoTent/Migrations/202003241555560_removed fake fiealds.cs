namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedfakefiealds : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DbItems", "SpecificationeUa");
            DropColumn("dbo.DbItems", "SpecificationeRu");
            DropColumn("dbo.DbItems", "SpecificationeEn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbItems", "SpecificationeEn", c => c.String());
            AddColumn("dbo.DbItems", "SpecificationeRu", c => c.String());
            AddColumn("dbo.DbItems", "SpecificationeUa", c => c.String());
        }
    }
}
