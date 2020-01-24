namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedfeedbackdbfiealdnames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbFeedbacks", "Message", c => c.String());
            DropColumn("dbo.DbFeedbacks", "Text");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbFeedbacks", "Text", c => c.String());
            DropColumn("dbo.DbFeedbacks", "Message");
        }
    }
}
