namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editeditemsdb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbItems", "OrderCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DbItems", "OrderCount");
        }
    }
}
