using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnoTent.Models.DataBase;
using TechnoTent.Models.ViewModel;

namespace TechnoTent.Models
{
    public class AdminPartners
    {
        public static PartnersVM GetImages()
        {
            PartnersVM partners = new PartnersVM();

            using (DataBaseContext db = new DataBaseContext())
            {
                partners.ImagesList = db.PartnersDb.Select(u =>
                    new PartnersVM
                    {
                        Id = u.Id,
                        ImagePath = u.ImagePath,
                        OrderNumber = u.OrderNumber,
                    }).OrderBy(u => u.OrderNumber).ToList();
            }

            return partners;
        }

        public static void AddImages(PartnersVM partners)
        {
            List<string> images = Image.UploadNewPartnersImages(partners);

            using (DataBaseContext db = new DataBaseContext())
            {
                foreach (var img in images)
                {
                    db.PartnersDb.Add(
                        new DbPartners
                        {
                            ImagePath = img,
                            OrderNumber = GetLastOrder() + 1,
                        });

                    db.SaveChanges();
                }
            }
        }

        public static List<PartnersVM> DeleteImage(int imageId)
        {
            List<PartnersVM> images = new List<PartnersVM>();

            string imageName = "";

            using (DataBaseContext db = new DataBaseContext())
            {
                var image = db.PartnersDb.Where(u => u.Id == imageId).FirstOrDefault();

                imageName = image.ImagePath;

                db.PartnersDb.Remove(image);

                db.PartnersDb.Where(u => u.OrderNumber > image.OrderNumber).ToList().ForEach(u => u.OrderNumber -= 1);

                db.SaveChanges();

                images = db.PartnersDb.Select(u =>
                    new PartnersVM
                    {
                        Id = u.Id,
                        ImagePath = u.ImagePath,
                        OrderNumber = u.OrderNumber,
                    }).OrderBy(u => u.OrderNumber).ToList();
            }

            Image.DeleteMainImageByName(imageName);

            return images;
        }

        static int GetLastOrder()
        {
            int number = 1;

            try
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    number = db.PartnersDb.Select(u => u.OrderNumber).Count();
                }
            }
            catch (Exception)
            { }

            return number;
        }

        public static void UpImageOrderNumber(int orderNumber)
        {
            try
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    var image = db.PartnersDb.Where(u => u.OrderNumber == orderNumber).FirstOrDefault();

                    int newOrderNumber = orderNumber - 1;

                    image.OrderNumber = newOrderNumber;

                    db.PartnersDb.Where(u => u.OrderNumber == newOrderNumber).First().OrderNumber = orderNumber;

                    db.SaveChanges();
                }
            }
            catch (Exception)
            { }
        }

        public static void DownImageOrderNumber(int orderNumber)
        {
            try
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    var image = db.PartnersDb.Where(u => u.OrderNumber == orderNumber).FirstOrDefault();

                    int newOrderNumber = orderNumber + 1;

                    image.OrderNumber = newOrderNumber;

                    db.PartnersDb.Where(u => u.OrderNumber == newOrderNumber).First().OrderNumber = orderNumber;

                    db.SaveChanges();
                }
            }
            catch (Exception)
            { }
        }
    }
}