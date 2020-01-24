namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class itemsdbchange4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbItems", "PriceUndefined", c => c.String());
            AddColumn("dbo.DbItems", "ItemStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DbItems", "ItemStatus");
            DropColumn("dbo.DbItems", "PriceUndefined");
        }
    }
}
