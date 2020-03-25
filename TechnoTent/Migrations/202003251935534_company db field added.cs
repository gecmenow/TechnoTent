namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class companydbfieldadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbCompanies", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DbCompanies", "Email");
        }
    }
}
