namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class itemsdbchange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DbCarts", "ItemCount", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DbCarts", "ItemCount", c => c.Double(nullable: false));
        }
    }
}
