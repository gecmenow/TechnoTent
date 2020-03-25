namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbCompanies", "OrgName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DbCompanies", "OrgName");
        }
    }
}
