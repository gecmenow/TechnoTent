namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbOrders", "ItemsCount", c => c.Double(nullable: false));
            AddColumn("dbo.DbOrders", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DbOrders", "OrderNumber", c => c.String());
            DropColumn("dbo.DbOrders", "ItemsName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbOrders", "ItemsName", c => c.String());
            AlterColumn("dbo.DbOrders", "OrderNumber", c => c.Guid(nullable: false));
            DropColumn("dbo.DbOrders", "Date");
            DropColumn("dbo.DbOrders", "ItemsCount");
        }
    }
}
