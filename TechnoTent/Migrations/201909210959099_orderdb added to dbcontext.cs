namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderdbaddedtodbcontext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderNumber = c.Guid(nullable: false),
                        UserId = c.Int(nullable: false),
                        UserName = c.String(),
                        UserEmail = c.String(),
                        UserPhone = c.String(),
                        DeliveryCity = c.String(),
                        DeliveryOffice = c.String(),
                        DeliveryMethod = c.String(),
                        PaymentMethod = c.String(),
                        ItemsId = c.String(),
                        ItemsName = c.String(),
                        ItemsPrice = c.String(),
                        TotalPrice = c.Double(nullable: false),
                        OrderStatus = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DbOrders");
        }
    }
}
