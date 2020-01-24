namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatednewsandstocksdb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbNews", "TitleRu", c => c.String(nullable: false));
            AddColumn("dbo.DbNews", "TitleUa", c => c.String());
            AddColumn("dbo.DbNews", "TitleEn", c => c.String());
            AddColumn("dbo.DbNews", "TextRu", c => c.String(nullable: false));
            AddColumn("dbo.DbNews", "TextUa", c => c.String());
            AddColumn("dbo.DbNews", "TextEn", c => c.String());
            AddColumn("dbo.DbStocks", "TitleRu", c => c.String(nullable: false));
            AddColumn("dbo.DbStocks", "TitleUa", c => c.String());
            AddColumn("dbo.DbStocks", "TitleEn", c => c.String());
            AddColumn("dbo.DbStocks", "TextRu", c => c.String(nullable: false));
            AddColumn("dbo.DbStocks", "TextUa", c => c.String());
            AddColumn("dbo.DbStocks", "TextEn", c => c.String());
            DropColumn("dbo.DbNews", "Title");
            DropColumn("dbo.DbNews", "Text");
            DropColumn("dbo.DbStocks", "Title");
            DropColumn("dbo.DbStocks", "Text");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbStocks", "Text", c => c.String(nullable: false));
            AddColumn("dbo.DbStocks", "Title", c => c.String(nullable: false));
            AddColumn("dbo.DbNews", "Text", c => c.String(nullable: false));
            AddColumn("dbo.DbNews", "Title", c => c.String(nullable: false));
            DropColumn("dbo.DbStocks", "TextEn");
            DropColumn("dbo.DbStocks", "TextUa");
            DropColumn("dbo.DbStocks", "TextRu");
            DropColumn("dbo.DbStocks", "TitleEn");
            DropColumn("dbo.DbStocks", "TitleUa");
            DropColumn("dbo.DbStocks", "TitleRu");
            DropColumn("dbo.DbNews", "TextEn");
            DropColumn("dbo.DbNews", "TextUa");
            DropColumn("dbo.DbNews", "TextRu");
            DropColumn("dbo.DbNews", "TitleEn");
            DropColumn("dbo.DbNews", "TitleUa");
            DropColumn("dbo.DbNews", "TitleRu");
        }
    }
}
