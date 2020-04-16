using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnoTent.Models.DataBase;
using TechnoTent.Models.ViewModel;

namespace TechnoTent.Models
{
    public class Prices
    {
        public static void AddPrices(PricesVM prices)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                db.PricesDb.Add(new DbPrices
                {
                    Name = prices.Name,
                    FilePath = prices.FilePath,
                });

                db.SaveChanges();
            }
        }

        public static List<PricesVM> GetPrices()
        {
            List<PricesVM> prices = new List<PricesVM>();

            using (DataBaseContext db = new DataBaseContext())
            {
                prices = db.PricesDb.Select(x => new PricesVM
                {
                    FilePath = x.FilePath,
                    Name = x.Name,
                }).ToList();
            }

            return prices;
        }

        public static void DeletePrice(int id)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var data = db.PricesDb.Where(x => x.Id == id).FirstOrDefault();

                db.PricesDb.Remove(data);

                db.SaveChanges();
            }
        }
    }
}