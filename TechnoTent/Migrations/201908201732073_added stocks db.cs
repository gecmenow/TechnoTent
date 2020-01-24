namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedstocksdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbStocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Image = c.String(),
                        Text = c.String(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.DbNews", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DbNews", "DateTime");
            DropTable("dbo.DbStocks");
        }
    }
}
