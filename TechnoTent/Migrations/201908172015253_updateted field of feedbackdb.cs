namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetedfieldoffeedbackdb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbFeedbacks", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DbFeedbacks", "DateTime");
        }
    }
}
