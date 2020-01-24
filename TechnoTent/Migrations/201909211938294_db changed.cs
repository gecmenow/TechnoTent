namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbchanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbItems", "VendorCode", c => c.String());
            AlterColumn("dbo.DbCarts", "ItemCount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DbCarts", "ItemCount", c => c.Int(nullable: false));
            DropColumn("dbo.DbItems", "VendorCode");
        }
    }
}
