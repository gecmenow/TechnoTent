using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnoTent.Models.DataBase;
using TechnoTent.Models.ViewModel;
using TechnoTent.Models.ViewModel.Admin;

namespace TechnoTent.Models
{
    public class AdminMainImages
    {
        public static MainImagesVM GetImages()
        {
            MainImagesVM images = new MainImagesVM();

            using (DataBaseContext db = new DataBaseContext())
            {
                images.MainImages = db.MainImagesDb.Select(u =>
                    new MainImagesVM
                    {
                        Id = u.Id,
                        Image = u.Image,
                        OrderNumber = u.OrderNumber,
                    }).OrderBy(u=>u.OrderNumber).ToList();
            }

            return images;
        }

        public static void AddImages(MainImagesVM image)
        {
            List<string> images = Image.UploadNewMainImages(image);

            using (DataBaseContext db = new DataBaseContext())
            {
                foreach (var img in images)
                {
                    db.MainImagesDb.Add(
                        new DbMainImages
                        {
                            Image = img,
                            OrderNumber = GetLastOrder() + 1,
                        });

                    db.SaveChanges();
                }
            }
        }

        public static List<MainImagesVM> DeleteImage(int imageId)
        {
            List<MainImagesVM> images = new List<MainImagesVM>();

            string imageName = "";

            using (DataBaseContext db = new DataBaseContext())
            {
                var image = db.MainImagesDb.Where(u => u.Id == imageId).FirstOrDefault();

                imageName = image.Image;

                db.MainImagesDb.Remove(image);

                db.MainImagesDb.Where(u => u.OrderNumber > image.OrderNumber).ToList().ForEach(u => u.OrderNumber -= 1);

                db.SaveChanges();

                images = db.MainImagesDb.Select(u =>
                    new MainImagesVM
                    {
                        Id = u.Id,
                        Image = u.Image,
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
                    number = db.MainImagesDb.Select(u => u.OrderNumber).Count();
                }
            }
            catch(Exception)
            { }

            return number;
        }

        public static void UpImageOrderNumber(int orderNumber)
        {
            try
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    var image = db.MainImagesDb.Where(u => u.OrderNumber == orderNumber).FirstOrDefault();

                    int newOrderNumber = orderNumber - 1;

                    image.OrderNumber = newOrderNumber;

                    db.MainImagesDb.Where(u => u.OrderNumber == newOrderNumber).First().OrderNumber = orderNumber;

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
                    var image = db.MainImagesDb.Where(u => u.OrderNumber == orderNumber).FirstOrDefault();

                    int newOrderNumber = orderNumber + 1;

                    image.OrderNumber = newOrderNumber;

                    db.MainImagesDb.Where(u => u.OrderNumber == newOrderNumber).First().OrderNumber = orderNumber;

                    db.SaveChanges();
                }
            }
            catch (Exception)
            { }
        }
    }
}