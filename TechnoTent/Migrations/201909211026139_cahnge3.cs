namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cahnge3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbCarts", "ItemPrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DbCarts", "ItemPrice");
        }
    }
}
