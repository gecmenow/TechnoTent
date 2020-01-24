namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderdbchanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbOrders", "OrderLanguage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DbOrders", "OrderLanguage");
        }
    }
}
