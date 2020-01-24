namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class itemdbchangeproductbuytype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbItems", "ProductBuyTypeMeter", c => c.Boolean(nullable: false));
            DropColumn("dbo.DbItems", "ProductBuyType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbItems", "ProductBuyType", c => c.String());
            DropColumn("dbo.DbItems", "ProductBuyTypeMeter");
        }
    }
}
