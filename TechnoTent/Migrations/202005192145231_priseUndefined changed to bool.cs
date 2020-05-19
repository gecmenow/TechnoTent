namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class priseUndefinedchangedtobool : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DbItems", "PriceUndefined", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DbItems", "PriceUndefined", c => c.String());
        }
    }
}
