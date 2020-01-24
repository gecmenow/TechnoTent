namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcategoryIdinitemsDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbItems", "CategoryId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DbItems", "CategoryId");
        }
    }
}
