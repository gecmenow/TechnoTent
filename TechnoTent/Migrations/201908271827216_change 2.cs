namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change2 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.DbCarts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DbCarts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Guid = c.Guid(nullable: false),
                        UserId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        ItemsId = c.Int(nullable: false),
                        ItemCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
