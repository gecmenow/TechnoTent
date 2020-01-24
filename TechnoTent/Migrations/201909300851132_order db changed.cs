namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderdbchanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbOrders", "ItemsVendorCode", c => c.String());
            DropColumn("dbo.DbOrders", "ItemsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbOrders", "ItemsId", c => c.String());
            DropColumn("dbo.DbOrders", "ItemsVendorCode");
        }
    }
}
