namespace TechnoTent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class companydbchange1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbCompanies", "AboutRu", c => c.String());
            AddColumn("dbo.DbCompanies", "AboutEn", c => c.String());
            AddColumn("dbo.DbCompanies", "AboutUa", c => c.String());
            AddColumn("dbo.DbCompanies", "OrgNameRu", c => c.String());
            AddColumn("dbo.DbCompanies", "OrgNameEn", c => c.String());
            AddColumn("dbo.DbCompanies", "OrgNameUa", c => c.String());
            AddColumn("dbo.DbCompanies", "AddressRu", c => c.String());
            AddColumn("dbo.DbCompanies", "AddressEn", c => c.String());
            AddColumn("dbo.DbCompanies", "AddressUa", c => c.String());
            AddColumn("dbo.DbCompanies", "NameRu", c => c.String());
            AddColumn("dbo.DbCompanies", "NameEn", c => c.String());
            AddColumn("dbo.DbCompanies", "NameUa", c => c.String());
            DropColumn("dbo.DbCompanies", "About");
            DropColumn("dbo.DbCompanies", "OrgName");
            DropColumn("dbo.DbCompanies", "Address");
            DropColumn("dbo.DbCompanies", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbCompanies", "Name", c => c.String());
            AddColumn("dbo.DbCompanies", "Address", c => c.String());
            AddColumn("dbo.DbCompanies", "OrgName", c => c.String());
            AddColumn("dbo.DbCompanies", "About", c => c.String());
            DropColumn("dbo.DbCompanies", "NameUa");
            DropColumn("dbo.DbCompanies", "NameEn");
            DropColumn("dbo.DbCompanies", "NameRu");
            DropColumn("dbo.DbCompanies", "AddressUa");
            DropColumn("dbo.DbCompanies", "AddressEn");
            DropColumn("dbo.DbCompanies", "AddressRu");
            DropColumn("dbo.DbCompanies", "OrgNameUa");
            DropColumn("dbo.DbCompanies", "OrgNameEn");
            DropColumn("dbo.DbCompanies", "OrgNameRu");
            DropColumn("dbo.DbCompanies", "AboutUa");
            DropColumn("dbo.DbCompanies", "AboutEn");
            DropColumn("dbo.DbCompanies", "AboutRu");
        }
    }
}
