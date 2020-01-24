namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbItems", "inStock", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DbItems", "inStock");
        }
    }
}
