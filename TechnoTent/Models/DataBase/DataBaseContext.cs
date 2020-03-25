using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.DataBase
{
    public class DataBaseContext: DbContext
    {
        public DataBaseContext() : base("TechnoTent_Connection")
        { }

        public DbSet<DbAdmin> AdminDb { get; set; }
        public DbSet<DbUser> UserDb { get; set; }
        public DbSet<DbFeedback> FeedbackDb { get; set; }
        public DbSet<DbReview> ReviewDb { get; set; }
        public DbSet<DbNews> NewsDb { get; set; }
        public DbSet<DbStocks> StocksDb { get; set; }
        public DbSet<DbItems> ItemsDb { get; set; }
        public DbSet<DbCart> CartDb { get; set; }
        public DbSet<DbMainImages> MainImagesDb { get; set; }
        public DbSet<DbCategory> CategoryDb { get; set; }
        public DbSet<DbSubCategory> SubCategoryDb { get; set; }
        public DbSet<DbOrder> OrderDb { get; set; }
        public DbSet<DbCompany> CompanyDb { get; set; }
    }
}