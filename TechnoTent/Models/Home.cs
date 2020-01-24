using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnoTent.Models.DataBase;
using TechnoTent.Models.ViewModel;

namespace TechnoTent.Models
{
    public class Home
    {
        public static HomeVM GetImages()
        {
            string noImage = "no_image.svg";

            List<MainImagesVM> images = new List<MainImagesVM>();

            List<NewsVM> news = new List<NewsVM>();

            List<StocksVM> stocks = new List<StocksVM>();

            using (DataBaseContext db = new DataBaseContext())
            {
                images =
                    (from entry in db.MainImagesDb
                     select new MainImagesVM
                     {
                         Image = entry.Image
                     }).ToList();

                news =
                    (from entry in db.NewsDb
                     select new NewsVM
                     {
                         Image = entry.Image,
                         TextRu = entry.TextRu,
                         TextUa = entry.TextUa,
                         TextEn = entry.TextEn,
                         TitleRu = entry.TitleRu,
                         TitleUa = entry.TitleUa,
                         TitleEn = entry.TitleEn,
                         DateTime = entry.DateTime,
                     }).ToList();

                stocks =
                    (from entry in db.StocksDb
                     select new StocksVM
                     {
                         Image = entry.Image,
                         TextRu = entry.TextRu,
                         TextUa = entry.TextUa,
                         TextEn = entry.TextEn,
                         TitleRu = entry.TitleRu,
                         TitleUa = entry.TitleUa,
                         TitleEn = entry.TitleEn,
                         DateTime = entry.DateTime,
                     }).ToList();
            }

            if (images.Count() == 0)
            {
                images.Add(new MainImagesVM
                { Image = noImage });
            }

            HomeVM home = new HomeVM
            {
                mainImages = images,
                stokcs = stocks,
                news = news,
            };

            return home;
        }
    }
}