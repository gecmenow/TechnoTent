namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cartdbchanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbCarts", "VendorCode", c => c.String());
            DropColumn("dbo.DbCarts", "ItemId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbCarts", "ItemId", c => c.Int(nullable: false));
            DropColumn("dbo.DbCarts", "VendorCode");
        }
    }
}
