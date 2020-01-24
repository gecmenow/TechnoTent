namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateorderdb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbOrders", "TotalitemsCount", c => c.Int(nullable: false));
            AlterColumn("dbo.DbOrders", "ItemsCount", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DbOrders", "ItemsCount", c => c.Double(nullable: false));
            DropColumn("dbo.DbOrders", "TotalitemsCount");
        }
    }
}
