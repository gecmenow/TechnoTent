namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cartdbadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbCarts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        ItemCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DbCarts");
        }
    }
}
