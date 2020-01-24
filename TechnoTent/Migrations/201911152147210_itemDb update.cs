namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class itemDbupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbItems", "IndividualOrders", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DbItems", "IndividualOrders");
        }
    }
}
