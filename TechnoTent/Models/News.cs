using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnoTent.Cookies;
using TechnoTent.Models.DataBase;
using TechnoTent.Models.ViewModel;

namespace TechnoTent.Models
{
    public class News
    {
        public static List<NewsVM> GetNews()
        {
            List<NewsVM> news = new List<NewsVM>();

            using (DataBaseContext db = new DataBaseContext())
            {
                var language = Cookie.CheckLanguageCookie();

                switch (language)
                {
                    case "uk":
                        news =
                        (from entry in db.NewsDb
                         select new NewsVM
                         {
                             Id = entry.Id,
                             DateTime = entry.DateTime,
                             Image = entry.Image,
                             Text = entry.TextUa,
                             Title = entry.TitleUa,
                         }).ToList();
                        break;
                    case "en":
                        news =
                        (from entry in db.NewsDb
                         select new NewsVM
                         {
                             Id = entry.Id,
                             DateTime = entry.DateTime,
                             Image = entry.Image,
                             Text = entry.TextEn,
                             Title = entry.TitleEn,
                         }).ToList();
                        break;
                    default:
                        news =
                        (from entry in db.NewsDb
                         select new NewsVM
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

            return news;
        }

        public static NewsVM GetNewsById(int id)
        {
            NewsVM news;

            List<NewsVM> newsList = new List<NewsVM>();

            using (DataBaseContext db = new DataBaseContext())
            {
                var language = Cookie.CheckLanguageCookie();

                switch (language)
                {
                    case "uk":
                        news =
                            (from entry in db.NewsDb
                             where entry.Id == id
                             select new NewsVM
                             {
                                 Id = entry.Id,
                                 DateTime = entry.DateTime,
                                 Image = entry.Image,
                                 Text = entry.TextUa,
                                 Title = entry.TitleUa,
                             }).First();

                        newsList =
                            (from entry in db.NewsDb
                             where entry.Id != id
                             select new NewsVM
                             {
                                 Id = entry.Id,
                                 DateTime = entry.DateTime,
                                 Image = entry.Image,
                                 Text = entry.TextUa,
                                 Title = entry.TitleUa,
                             }).ToList();
                        break;
                    case "en":
                        news =
                            (from entry in db.NewsDb
                             where entry.Id == id
                             select new NewsVM
                             {
                                 Id = entry.Id,
                                 DateTime = entry.DateTime,
                                 Image = entry.Image,
                                 Text = entry.TextEn,
                                 Title = entry.TitleEn,
                             }).First();

                        newsList =
                            (from entry in db.NewsDb
                             where entry.Id != id
                             select new NewsVM
                             {
                                 Id = entry.Id,
                                 DateTime = entry.DateTime,
                                 Image = entry.Image,
                                 Text = entry.TextEn,
                                 Title = entry.TitleEn,
                             }).ToList();
                        break;
                    default:
                        news =
                            (from entry in db.NewsDb
                             where entry.Id == id
                             select new NewsVM
                             {
                                 Id = entry.Id,
                                 DateTime = entry.DateTime,
                                 Image = entry.Image,
                                 Text = entry.TextRu,
                                 Title = entry.TitleRu,
                             }).First();

                        newsList =
                            (from entry in db.NewsDb
                             where entry.Id != id
                             select new NewsVM
                             {
                                 Id = entry.Id,
                                 DateTime = entry.DateTime,
                                 Image = entry.Image,
                                 Text = entry.TextRu,
                                 Title = entry.TitleRu,
                             }).ToList();
                        break;
                }

                news.NewsList = newsList;
            }

            return news;
        }
    }
}