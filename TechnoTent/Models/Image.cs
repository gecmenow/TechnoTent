using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using TechnoTent.Models.DataBase;
using TechnoTent.Models.ViewModel;
using TechnoTent.Models.ViewModel.Admin;

namespace TechnoTent.Models
{
    public class Image
    {
        public static List<string> GetImagesByItemId(int id)
        {
            string noImage = "no_image.png";

            List<string> images = new List<string>();

            DbItems data = new DbItems();

            using (DataBaseContext db = new DataBaseContext())
            {
                data =
                    (from entry in db.ItemsDb
                     where entry.Id == id
                     select entry).FirstOrDefault();
            }

            if (data.Image1 == "" && data.Image2 == "" &&
                data.Image3 == "" && data.Image4 == "")
            {
                images.Add(noImage);
            }
            else
            {
                if (data.Image1 != "")
                    images.Add(data.Image1);
                if (data.Image2 != "")
                    images.Add(data.Image2);
                if (data.Image3 != "")
                    images.Add(data.Image3);
                if (data.Image4 != "")
                    images.Add(data.Image4);
            }

            return images;
        }

        public static string GetImageIfNull()
        {
            string noImage = "no_image.png";

            return noImage;
        }
        ///<summary>
        /// Для добавления нового товара
        /// </summary>
        public static List<string> UploadNewImages(AdminItemVM item)
        {
            List<string> images = new List<string>();

            int counter = 0;

            if (item.Images[0] != null)
                foreach (var image in item.Images)
                {
                    if (counter == 4)
                        break;

                    string filePath = CheckItemImageForExisting(image.FileName);

                    string path = Path.GetDirectoryName(filePath);

                    string fileNameOnly = Path.GetFileNameWithoutExtension(filePath);

                    fileNameOnly = fileNameOnly.ToLower().Replace(" - ", "");
                    fileNameOnly = fileNameOnly.ToLower().Replace("- ", "");
                    fileNameOnly = fileNameOnly.ToLower().Replace(" -", "");
                    fileNameOnly = fileNameOnly.ToLower().Replace("   ", "");
                    fileNameOnly = fileNameOnly.ToLower().Replace("  ", "");
                    fileNameOnly = fileNameOnly.ToLower().Replace("  ", "");
                    fileNameOnly = fileNameOnly.ToLower().Replace(" ", "");
                    fileNameOnly = fileNameOnly.ToLower().Replace("-", "");
                    fileNameOnly = fileNameOnly.ToLower().Replace("_", "");
                    fileNameOnly = fileNameOnly.ToLower().Replace(" _ ", "");
                    fileNameOnly = fileNameOnly.ToLower().Replace("_ ", "");
                    fileNameOnly = fileNameOnly.ToLower().Replace(" _", "");
                    fileNameOnly = fileNameOnly.ToLower().Replace("—", "");
                    fileNameOnly = fileNameOnly.ToLower().Replace(" — ", "");
                    fileNameOnly = fileNameOnly.ToLower().Replace(" —", "");
                    fileNameOnly = fileNameOnly.ToLower().Replace("— ", "");
                    fileNameOnly = fileNameOnly.ToLower().Replace(" . ", "");
                    fileNameOnly = fileNameOnly.ToLower().Replace(". ", "");
                    fileNameOnly = fileNameOnly.ToLower().Replace(" .", "");

                    string extension = Path.GetExtension(filePath);
                    string newFileName = fileNameOnly + extension;

                    images.Add(newFileName);

                    path = path + "\\" + newFileName;

                    image.SaveAs(path);

                    counter++;
                }
            while (images.Count < 4)
                images.Add(null);

            return images;
        }

        ///<summary>
        /// Для добавления новых изображений для главной
        /// </summary>
        public static List<string> UploadNewMainImages(MainImagesVM item)
        {
            List<string> images = new List<string>();

            int counter = GetMainImagesQuantity();

            if (item.Images[0] != null)
                foreach (var image in item.Images)
                {
                    if (counter == 6)
                        break;

                    string filePath = CheckMainImageForExisting(image.FileName);

                    string fileNameOnly = Path.GetFileNameWithoutExtension(filePath);

                    string extension = Path.GetExtension(filePath);
                    string newFileName = fileNameOnly + extension;

                    images.Add(newFileName);

                    image.SaveAs(filePath);

                    counter++;
                }

            return images;
        }

        ///<summary>
        /// Для добавления новых изображений для партнеров
        /// </summary>
        public static List<string> UploadNewPartnersImages(PartnersVM partners)
        {
            List<string> images = new List<string>();

            if (partners.Images[0] != null)
                foreach (var image in partners.Images)
                {
                    string filePath = ChecPartnersImageForExisting(image.FileName);

                    string fileNameOnly = Path.GetFileNameWithoutExtension(filePath);

                    string extension = Path.GetExtension(filePath);
                    string newFileName = fileNameOnly + extension;

                    images.Add(newFileName);

                    image.SaveAs(filePath);
                }

            return images;
        }

        ///<summary>
        /// Для редактирования товара
        /// </summary>
        public static List<string> UploadNewImages(IEnumerable<HttpPostedFileBase> item)
        {
            List<string> images = new List<string>();

            if (item != null)
            {
                foreach (var image in item)
                {
                    if (image != null)
                    {
                        string filePath = CheckItemImageForExisting(image.FileName);

                        string path = Path.GetDirectoryName(filePath);

                        string fileNameOnly = Path.GetFileNameWithoutExtension(filePath);

                        fileNameOnly = fileNameOnly.ToLower().Replace(" - ", "");
                        fileNameOnly = fileNameOnly.ToLower().Replace("- ", "");
                        fileNameOnly = fileNameOnly.ToLower().Replace(" -", "");
                        fileNameOnly = fileNameOnly.ToLower().Replace("   ", "");
                        fileNameOnly = fileNameOnly.ToLower().Replace("  ", "");
                        fileNameOnly = fileNameOnly.ToLower().Replace("  ", "");
                        fileNameOnly = fileNameOnly.ToLower().Replace(" ", "");
                        fileNameOnly = fileNameOnly.ToLower().Replace("-", "");
                        fileNameOnly = fileNameOnly.ToLower().Replace("_", "");
                        fileNameOnly = fileNameOnly.ToLower().Replace(" _ ", "");
                        fileNameOnly = fileNameOnly.ToLower().Replace("_ ", "");
                        fileNameOnly = fileNameOnly.ToLower().Replace(" _", "");
                        fileNameOnly = fileNameOnly.ToLower().Replace("—", "");
                        fileNameOnly = fileNameOnly.ToLower().Replace(" — ", "");
                        fileNameOnly = fileNameOnly.ToLower().Replace(" —", "");
                        fileNameOnly = fileNameOnly.ToLower().Replace("— ", "");
                        fileNameOnly = fileNameOnly.ToLower().Replace(" . ", "");
                        fileNameOnly = fileNameOnly.ToLower().Replace(". ", "");
                        fileNameOnly = fileNameOnly.ToLower().Replace(" .", "");

                        string extension = Path.GetExtension(filePath);
                        string newFileName = fileNameOnly + extension;

                        images.Add(newFileName);

                        path = path + "\\" + newFileName; 

                        image.SaveAs(path);
                    }
                    else
                        images.Add(null);
                }
            }

            return images;
        }

        public static string UploadNewCategoryImage(HttpPostedFileBase item)
        {
            string filePath = CheckCategoryImageForExisting(item.FileName);

            string fileNameOnly = Path.GetFileNameWithoutExtension(filePath);
            string extension = Path.GetExtension(filePath);
            string newFileName = fileNameOnly + extension;

            string image = "";

            if (newFileName != null || newFileName != "")
                image = newFileName;

            item.SaveAs(filePath);

            return image;
        }

        static int GetMainImagesQuantity()
        {
            int number = 1;

            try
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    number = db.MainImagesDb.Select(u => u.OrderNumber).Count();
                }
            }
            catch (Exception)
            { }

            return number;
        }

        /**
         * возвращает полный путь для картинок товара
         * **/
        public static string CheckItemImageForExisting(string imageName)
        {
            string filePath = HttpContext.Current.Server.MapPath("~/Content/images/items/" + imageName);

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

        //public static string CheckItemImageNameForExisting(string imageName)
        //{
        //    string filePath = HttpContext.Current.Server.MapPath("~/Content/images/items/" + imageName);

        //    int count = 1;

        //    string fileNameOnly = Path.GetFileNameWithoutExtension(filePath);
        //    string extension = Path.GetExtension(filePath);
        //    string path = Path.GetDirectoryName(filePath);
        //    string newFullPath = filePath;
        //    string newFileName = fileNameOnly + extension;

        //    while (File.Exists(newFullPath))
        //    {
        //        newFileName = string.Format("{0}({1})", fileNameOnly, count++);
        //        newFileName += extension;
        //        newFullPath = Path.Combine(path, newFileName);
        //    }

        //    return newFileName;
        //}

        /**
         * возвращает полный путь для картинок на главной странице
         * **/
        public static string CheckMainImageForExisting(string imageName)
        {
            string filePath = HttpContext.Current.Server.MapPath("~/Content/images/main/" + imageName);

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

        public static string ChecPartnersImageForExisting(string imageName)
        {
            string filePath = HttpContext.Current.Server.MapPath("~/Content/images/partners/" + imageName);

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

        public static string CheckCategoryImageForExisting(string imageName)
        {
            string filePath = HttpContext.Current.Server.MapPath("~/Content/images/category/" + imageName);

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

        //Items
        public static void DeleteImageByName(string vendorCode, string imageName)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var data =
                    (from entry in db.ItemsDb
                     where entry.VendorCode == vendorCode
                     select entry).FirstOrDefault();

                if (data.Image1 == imageName)
                    data.Image1 = null;
                if (data.Image2 == imageName)
                    data.Image2 = null;
                if (data.Image3 == imageName)
                    data.Image3 = null;
                if (data.Image4 == imageName)
                    data.Image4 = null;

                db.SaveChanges();
            }
            string filePath = HttpContext.Current.Server.MapPath("~/Content/images/items/" + imageName);

            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        public static void DeleteMainImageByName(string imageName)
        {
            string filePath = HttpContext.Current.Server.MapPath("~/Content/images/main/" + imageName);

            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}