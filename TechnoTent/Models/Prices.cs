using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using TechnoTent.Models.DataBase;
using TechnoTent.Models.ViewModel;

namespace TechnoTent.Models
{
    public class Prices
    {
        public static void AddPrices(PricesVM prices, HttpPostedFileBase uploads)
        {
            string filePath = HttpContext.Current.Server.MapPath("~/Content/prices/" + uploads.FileName);

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

            uploads.SaveAs(newFullPath);

            using (DataBaseContext db = new DataBaseContext())
            {
                db.PricesDb.Add(new DbPrices
                {
                    Name = prices.Name,
                    FilePath = newFileName,
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
                    Id = x.Id,
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

                string filePath = HttpContext.Current.Server.MapPath("~/Content/prices/" + data.FilePath);

                if (File.Exists(filePath))
                    File.Delete(filePath);

                db.PricesDb.Remove(data);

                db.SaveChanges();
            }
        }
    }
}