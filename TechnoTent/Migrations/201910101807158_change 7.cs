namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbItems", "StockPriceUa", c => c.Double(nullable: false));
            AddColumn("dbo.DbItems", "StockPriceEn", c => c.Double(nullable: false));
            DropColumn("dbo.DbItems", "StockPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbItems", "StockPrice", c => c.Double(nullable: false));
            DropColumn("dbo.DbItems", "StockPriceEn");
            DropColumn("dbo.DbItems", "StockPriceUa");
        }
    }
}
