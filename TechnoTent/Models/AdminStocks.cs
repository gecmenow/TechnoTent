using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using TechnoTent.Models.DataBase;
using TechnoTent.Models.ViewModel.Admin;

namespace TechnoTent.Models
{
    public class AdminStocks
    {
        public static List<AdminStocksVM> GetStocks()
        {
            List<AdminStocksVM> stocks = new List<AdminStocksVM>();

            using (DataBaseContext db = new DataBaseContext())
            {
                stocks = db.StocksDb.Select(u => new AdminStocksVM
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

            return stocks;
        }

        public static AdminStocksVM GetStocksById(int id)
        {
            AdminStocksVM stocks = new AdminStocksVM();

            using (DataBaseContext db = new DataBaseContext())
            {
                stocks = db.StocksDb.Where(u => u.Id == id).Select(u => new AdminStocksVM
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

            return stocks;
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
            string filePath = HttpContext.Current.Server.MapPath("~/Content/images/stocks/" + imageName);

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

        public static void AddStocks(AdminStocksVM stocks, HttpPostedFileBase upload)
        {
            var image = UploadNewImages(upload);

            if (image == "")
                image = null;

            using (DataBaseContext db = new DataBaseContext())
            {
                db.StocksDb.Add(new DbStocks
                {
                    TitleRu = stocks.TitleRu,
                    TitleUa = stocks.TitleUa,
                    TitleEn = stocks.TitleEn,
                    Image = image,
                    TextRu = stocks.TextRu,
                    TextUa = stocks.TextUa,
                    TextEn = stocks.TextEn,
                    DateTime = DateTime.Now,
                });

                db.SaveChanges();
            }
        }

        public static void EditStocks(AdminStocksVM stocks, HttpPostedFileBase upload)
        {
            var image = UploadNewImages(upload);

            if (image == "")
                image = null;

            using (DataBaseContext db = new DataBaseContext())
            {
                var oldStocks = db.StocksDb.Where(m => m.Id == stocks.Id).FirstOrDefault();

                oldStocks.TitleRu = stocks.TitleRu;
                oldStocks.TitleUa = stocks.TitleUa;
                oldStocks.TitleEn = stocks.TitleEn;
                oldStocks.Image = image;
                oldStocks.TextRu = stocks.TextRu;
                oldStocks.TextUa = stocks.TextUa;
                oldStocks.TextEn = stocks.TextEn;
                oldStocks.DateTime = DateTime.Now;
                
                db.SaveChanges();
            }
        }

        public static void RemoveStocks(int id)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var stocks = db.StocksDb.Where(m => m.Id == id).FirstOrDefault();

                var filePath = HttpContext.Current.Server.MapPath("~/Content/images/stocks/" + stocks.Image);

                if (File.Exists(filePath))
                    File.Delete(filePath);

                db.StocksDb.Remove(stocks);

                db.SaveChanges();
            }
        }

        public static void RemoveAllStocks()
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var stocks = db.StocksDb;

                foreach (var data in stocks)
                {
                    string filePath = HttpContext.Current.Server.MapPath("~/Content/images/stocks/" + data.Image);

                    if (File.Exists(filePath))
                        File.Delete(filePath);

                    db.StocksDb.Remove(data);
                }

                db.SaveChanges();
            }
        }
    }
}