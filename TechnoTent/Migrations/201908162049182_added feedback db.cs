namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedfeedbackdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbFeedbacks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        email = c.String(),
                        text = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DbFeedbacks");
        }
    }
}
