namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class itemdbchanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbAdmins", "NovaPoshtaKey", c => c.String());
            AddColumn("dbo.DbAdmins", "InTimeKey", c => c.String());
            AddColumn("dbo.DbItems", "ProductBuyType", c => c.String());
            AddColumn("dbo.DbItems", "IsStock", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DbItems", "IsStock");
            DropColumn("dbo.DbItems", "ProductBuyType");
            DropColumn("dbo.DbAdmins", "InTimeKey");
            DropColumn("dbo.DbAdmins", "NovaPoshtaKey");
        }
    }
}
