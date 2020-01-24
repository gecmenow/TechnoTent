namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbOrders", "PaymentStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DbOrders", "PaymentStatus");
        }
    }
}
