using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnoTent.Cookies;
using TechnoTent.Models.DataBase;
using TechnoTent.Models.ViewModel;

namespace TechnoTent.Models
{
    public class Stocks
    {
        public static List<StocksVM> GetStocks()
        {
            List<StocksVM> stocks = new List<StocksVM>();

            using (DataBaseContext db = new DataBaseContext())
            {
                var language = Cookie.CheckLanguageCookie();

                switch (language)
                {
                    case "uk":
                        stocks =
                        (from entry in db.StocksDb
                         select new StocksVM
                         {
                             Id = entry.Id,
                             DateTime = entry.DateTime,
                             Image = entry.Image,
                             Text = entry.TextUa,
                             Title = entry.TitleUa,
                         }).ToList();
                        break;
                    case "en":
                        stocks =
                        (from entry in db.StocksDb
                         select new StocksVM
                         {
                             Id = entry.Id,
                             DateTime = entry.DateTime,
                             Image = entry.Image,
                             Text = entry.TextEn,
                             Title = entry.TitleEn,
                         }).ToList();
                        break;
                    default:
                        stocks =
                        (from entry in db.StocksDb
                         select new StocksVM
                         {
                             Id = entry.Id,
                             DateTime = entry.DateTime,
                             Image = entry.Image,
                             Text = entry.TextRu,
                             Title = entry.TitleRu,
                         }).ToList();
                        break;
                }
            }

            return stocks;
        }

        public static StocksVM GetStocksById(int id)
        {
            StocksVM stocks;

            List<StocksVM> stocksList = new List<StocksVM>();

            using (DataBaseContext db = new DataBaseContext())
            {
                var language = Cookie.CheckLanguageCookie();

                switch (language)
                {
                    case "uk":
                        stocks =
                            (from entry in db.StocksDb
                             where entry.Id == id
                             select new StocksVM
                             {
                                 Id = entry.Id,
                                 DateTime = entry.DateTime,
                                 Image = entry.Image,
                                 Text = entry.TextUa,
                                 Title = entry.TitleUa,
                             }).First();

                        stocksList =
                            (from entry in db.StocksDb
                             where entry.Id != id
                             select new StocksVM
                             {
                                 Id = entry.Id,
                                 DateTime = entry.DateTime,
                                 Image = entry.Image,
                                 Text = entry.TextUa,
                                 Title = entry.TitleUa,
                             }).ToList();
                        break;
                    case "en":
                        stocks =
                            (from entry in db.StocksDb
                             where entry.Id == id
                             select new StocksVM
                             {
                                 Id = entry.Id,
                                 DateTime = entry.DateTime,
                                 Image = entry.Image,
                                 Text = entry.TextEn,
                                 Title = entry.TitleEn,
                             }).First();

                        stocksList =
                            (from entry in db.StocksDb
                             where entry.Id != id
                             select new StocksVM
                             {
                                 Id = entry.Id,
                                 DateTime = entry.DateTime,
                                 Image = entry.Image,
                                 Text = entry.TextEn,
                                 Title = entry.TitleEn,
                             }).ToList();
                        break;
                    default:
                        stocks =
                            (from entry in db.StocksDb
                             where entry.Id == id
                             select new StocksVM
                             {
                                 Id = entry.Id,
                                 DateTime = entry.DateTime,
                                 Image = entry.Image,
                                 Text = entry.TextRu,
                                 Title = entry.TitleRu,
                             }).First();

                        stocksList =
                            (from entry in db.StocksDb
                             where entry.Id != id
                             select new StocksVM
                             {
                                 Id = entry.Id,
                                 DateTime = entry.DateTime,
                                 Image = entry.Image,
                                 Text = entry.TextRu,
                                 Title = entry.TitleRu,
                             }).ToList();
                        break;

                }

                stocks.StocksList = stocksList;
            }

            return stocks;
        }
    }
}