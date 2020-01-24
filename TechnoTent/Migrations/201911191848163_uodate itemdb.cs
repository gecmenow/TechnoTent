namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uodateitemdb : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DbItems", "Brand");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbItems", "Brand", c => c.String());
        }
    }
}
