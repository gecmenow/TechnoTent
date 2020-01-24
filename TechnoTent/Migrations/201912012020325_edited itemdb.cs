namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editeditemdb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbItems", "AdhesionStrength", c => c.String());
            DropColumn("dbo.DbItems", "AdhesionStrengthUa");
            DropColumn("dbo.DbItems", "AdhesionStrengthRu");
            DropColumn("dbo.DbItems", "AdhesionStrengthEn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbItems", "AdhesionStrengthEn", c => c.String());
            AddColumn("dbo.DbItems", "AdhesionStrengthRu", c => c.String());
            AddColumn("dbo.DbItems", "AdhesionStrengthUa", c => c.String());
            DropColumn("dbo.DbItems", "AdhesionStrength");
        }
    }
}
