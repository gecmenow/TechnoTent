namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class itemchangeddb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbItems", "Brand", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DbItems", "Brand");
        }
    }
}
