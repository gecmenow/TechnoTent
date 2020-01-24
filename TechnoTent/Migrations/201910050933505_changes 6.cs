namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DbItems", "Width", c => c.Double(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DbItems", "Width", c => c.String());
        }
    }
}
