namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class feedbackdbchanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbReviews", "Answer", c => c.String());
            AddColumn("dbo.DbReviews", "AnswerDateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DbReviews", "AnswerDateTime");
            DropColumn("dbo.DbReviews", "Answer");
        }
    }
}
