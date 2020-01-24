namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderchanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbUsers", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DbUsers", "Phone");
        }
    }
}
