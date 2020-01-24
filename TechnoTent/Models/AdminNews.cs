using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using TechnoTent.Models.DataBase;
using TechnoTent.Models.ViewModel.Admin;

namespace TechnoTent.Models
{
    public class AdminNews
    {
        public static List<AdminNewsVM> GetNews()
        {
            List<AdminNewsVM> news = new List<AdminNewsVM>();

            using (DataBaseContext db = new DataBaseContext())
            {
                news = db.NewsDb.Select(u => new AdminNewsVM
                {
                    Id = u.Id,
                    DateTime = u.DateTime,
                    Image = u.Image,
                    Text = u.TextRu,
                    TextRu = u.TextRu,
                    TextUa = u.TextUa,
                    TextEn = u.TextEn,
                    Title = u.TitleRu,
                    TitleRu = u.TitleRu,
                    TitleUa = u.TitleUa,
                    TitleEn = u.TitleEn,
                }).ToList();

                db.SaveChanges();
            }

            return news;
        }

        public static AdminNewsVM GetNewsById(int id)
        {
            AdminNewsVM news = new AdminNewsVM();

            using (DataBaseContext db = new DataBaseContext())
            {
                news = db.NewsDb.Where(u=>u.Id == id).Select(u => new AdminNewsVM
                {
                    Id = u.Id,
                    DateTime = u.DateTime,
                    Image = u.Image,
                    TextRu = u.TextRu,
                    TextUa = u.TextUa,
                    TextEn = u.TextEn,
                    TitleRu = u.TitleRu,
                    TitleUa = u.TitleUa,
                    TitleEn = u.TitleEn,
                }).FirstOrDefault();

                db.SaveChanges();
            }

            return news;
        }

        static string UploadNewImages(HttpPostedFileBase item)
        {
            string newFileName = "";

            if (item != null)
            {
                string filePath = CheckImageForExisting(item.FileName);

                string fileNameOnly = Path.GetFileNameWithoutExtension(filePath);
                string extension = Path.GetExtension(filePath);
                newFileName = fileNameOnly + extension;

                item.SaveAs(filePath);
            }

            return newFileName;
        }

        static string CheckImageForExisting(string imageName)
        {
            string filePath = HttpContext.Current.Server.MapPath("~/Content/images/news/" + imageName);

            int count = 1;

            string fileNameOnly = Path.GetFileNameWithoutExtension(filePath);
            string extension = Path.GetExtension(filePath);
            string path = Path.GetDirectoryName(filePath);
            string newFullPath = filePath;
            string newFileName = fileNameOnly + extension;

            while (File.Exists(newFullPath))
            {
                newFileName = string.Format("{0}({1})", fileNameOnly, count++);
                newFileName += extension;
                newFullPath = Path.Combine(path, newFileName);
            }

            return newFullPath;
        }

        public static void AddNews(AdminNewsVM news, HttpPostedFileBase upload)
        {
            var image = UploadNewImages(upload);

            if (image == "")
                image = null;

            using (DataBaseContext db = new DataBaseContext())
            {
                db.NewsDb.Add(new DbNews
                {
                    TitleRu = news.TitleRu,
                    TitleUa = news.TitleUa,
                    TitleEn = news.TitleEn,
                    Image = image,
                    TextRu = news.TextRu,
                    TextUa = news.TextUa,
                    TextEn = news.TextEn,
                    DateTime = DateTime.Now,
                });

                db.SaveChanges();
            }
        }

        public static void EditNews(AdminNewsVM news, HttpPostedFileBase upload)
        {
            var image = UploadNewImages(upload);

            using (DataBaseContext db = new DataBaseContext())
            {
                var oldNews = db.NewsDb.Where(m => m.Id == news.Id).FirstOrDefault();

                oldNews.TitleRu = news.TitleRu;
                oldNews.TitleUa = news.TitleUa;
                oldNews.TitleEn = news.TitleEn;
                oldNews.Image = image;
                oldNews.TextRu = news.TextRu;
                oldNews.TextUa = news.TextUa;
                oldNews.TextEn = news.TextEn;
                oldNews.DateTime = DateTime.Now;

                db.SaveChanges();
            }
        }

        public static void RemoveNews(int id)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var news = db.NewsDb.Where(m => m.Id == id).FirstOrDefault();

                var filePath = HttpContext.Current.Server.MapPath("~/Content/images/news/" + news.Image);

                if (File.Exists(filePath))
                    File.Delete(filePath);

                db.NewsDb.Remove(news);

                db.SaveChanges();
            }
        }

        public static void RemoveAllNews()
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var news = db.NewsDb;

                foreach (var data in news)
                {
                    string filePath = HttpContext.Current.Server.MapPath("~/Content/images/news/" + data.Image);

                    if (File.Exists(filePath))
                        File.Delete(filePath);

                    db.NewsDb.Remove(data);
                }

                db.SaveChanges();
            }
        }
    }
}