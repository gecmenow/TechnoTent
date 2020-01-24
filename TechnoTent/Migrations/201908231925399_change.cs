namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbCarts", "Guid", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DbCarts", "Guid");
        }
    }
}
