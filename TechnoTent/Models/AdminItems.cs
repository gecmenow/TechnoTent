using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using TechnoTent.Models.DataBase;
using TechnoTent.Models.ViewModel.Admin;

namespace TechnoTent.Models
{
    public class AdminItems
    {
        public static AdminItemVM GetItemCategories()
        {
            AdminItemVM item = new AdminItemVM();

            using (DataBaseContext db = new DataBaseContext())
            {
                var categories = db.CategoryDb.Select(u => u.CategoryNameRu).ToList();
                var subCategories = db.SubCategoryDb.Select(u => u.SubCategoryNameRu).ToList();

                item.CategoriesList = categories;
                item.SubCategoriesList = subCategories;
            }

            return item;
        }

        public static List<AdminItemVM> GetAllItems()
        {
            List<AdminItemVM> items = new List<AdminItemVM>();

            using (DataBaseContext db = new DataBaseContext())
            {
                items =
                    (from entry in db.ItemsDb
                     select new AdminItemVM
                     {
                         Id = entry.Id,
                         VendorCode = entry.VendorCode,
                         CategoryNameUa = entry.CategoryNameUa,
                         CategoryNameRu = entry.CategoryNameRu,
                         CategoryNameEn = entry.CategoryNameEn,
                         SubCategoryNameUa = entry.SubCategoryNameUa,
                         SubCategoryNameRu = entry.SubCategoryNameRu,
                         SubCategoryNameEn = entry.SubCategoryNameEn,
                         NameUa = entry.NameUa,
                         NameRu = entry.NameRu,
                         NameEn = entry.NameEn,
                         PriceUa = entry.PriceUa,
                         PriceEn = entry.PriceEn,
                         Image1 = entry.Image1,
                         Image2 = entry.Image2,
                         Image3 = entry.Image3,
                         Image4 = entry.Image4,
                         CoveringUa = entry.CoveringUa,
                         CoveringRu = entry.CoveringRu,
                         CoveringEn = entry.CoveringEn,
                         SpecificationUa = entry.SpecificationUa,
                         SpecificationRu = entry.SpecificationRu,
                         SpecificationEn = entry.SpecificationEn,
                         ThreadUa = entry.ThreadUa,
                         ThreadRu = entry.ThreadRu,
                         ThreadEn = entry.ThreadEn,
                         TotalWeight = entry.TotalWeight,
                         Width = entry.Width,
                         Winding = entry.Winding,
                         Strength = entry.Strength,
                         BreakingStrength = entry.BreakingStrength,
                         AdhesionStrength = entry.AdhesionStrength,
                         Temperature = entry.Temperature,
                         ColorUa = entry.ColorUa,
                         ColorRu = entry.ColorRu,
                         ColorEn = entry.ColorEn,
                         inStock = entry.inStock,
                         IsStock = entry.IsStock,
                         StockPriceUa = entry.StockPriceUa,
                         StockPriceEn = entry.StockPriceEn,

                     }).ToList();                

            }
                return items;
        }

        public static List<AdminItemVM> GetItemsByCategory(string category)
        {
            List<AdminItemVM> items = new List<AdminItemVM>();

            using (DataBaseContext db = new DataBaseContext())
            {
                category = UrlHelper.SeoFriendlyUlrToString(category);

                items =
                    (from entry in db.ItemsDb
                     where entry.CategoryNameEn == category
                     select new AdminItemVM
                     {
                         Id = entry.Id,
                         VendorCode = entry.VendorCode,
                         CategoryNameUa = entry.CategoryNameUa,
                         CategoryNameRu = entry.CategoryNameRu,
                         CategoryNameEn = entry.CategoryNameEn,
                         SubCategoryNameUa = entry.SubCategoryNameUa,
                         SubCategoryNameRu = entry.SubCategoryNameRu,
                         SubCategoryNameEn = entry.SubCategoryNameEn,
                         NameUa = entry.NameUa,
                         NameRu = entry.NameRu,
                         NameEn = entry.NameEn,
                         PriceUa = entry.PriceUa,
                         PriceEn = entry.PriceEn,
                         Image1 = entry.Image1,
                         Image2 = entry.Image2,
                         Image3 = entry.Image3,
                         Image4 = entry.Image4,
                         CoveringUa = entry.CoveringUa,
                         CoveringRu = entry.CoveringRu,
                         CoveringEn = entry.CoveringEn,
                         SpecificationUa = entry.SpecificationUa,
                         SpecificationRu = entry.SpecificationRu,
                         SpecificationEn = entry.SpecificationEn,
                         ThreadUa = entry.ThreadUa,
                         ThreadRu = entry.ThreadRu,
                         ThreadEn = entry.ThreadEn,
                         TotalWeight = entry.TotalWeight,
                         Width = entry.Width,
                         Winding = entry.Winding,
                         Strength = entry.Strength,
                         BreakingStrength = entry.BreakingStrength,
                         AdhesionStrength = entry.AdhesionStrength,
                         Temperature = entry.Temperature,
                         ColorUa = entry.ColorUa,
                         ColorRu = entry.ColorRu,
                         ColorEn = entry.ColorEn,
                         inStock = entry.inStock,
                         IsStock = entry.IsStock,
                         StockPriceUa = entry.StockPriceUa,
                         StockPriceEn = entry.StockPriceEn,
                     }).ToList();
            }
            return items;
        }

        public static AdminItemVM GetItemById(string vendorCode)
        {
            Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";

            AdminItemVM item;

            using (DataBaseContext db = new DataBaseContext())
            {
                item =
                    (from entry in db.ItemsDb
                     where entry.VendorCode == vendorCode
                     select new AdminItemVM
                     {
                         Id = entry.Id,
                         VendorCode = entry.VendorCode,
                         CategoryNameUa = entry.CategoryNameUa,
                         CategoryNameRu = entry.CategoryNameRu,
                         CategoryNameEn = entry.CategoryNameEn,
                         SubCategoryNameUa = entry.SubCategoryNameUa,
                         SubCategoryNameRu = entry.SubCategoryNameRu,
                         SubCategoryNameEn = entry.SubCategoryNameEn,
                         NameUa = entry.NameUa,
                         NameRu = entry.NameRu,
                         NameEn = entry.NameEn,
                         PriceUa = entry.PriceUa,
                         PriceEn = entry.PriceEn,
                         Image1 = entry.Image1,
                         Image2 = entry.Image2,
                         Image3 = entry.Image3,
                         Image4 = entry.Image4,
                         CoveringUa = entry.CoveringUa,
                         CoveringRu = entry.CoveringRu,
                         CoveringEn = entry.CoveringEn,
                         SpecificationUa = entry.SpecificationUa,
                         SpecificationRu = entry.SpecificationRu,
                         SpecificationEn = entry.SpecificationEn,
                         ThreadUa = entry.ThreadUa,
                         ThreadRu = entry.ThreadRu,
                         ThreadEn = entry.ThreadEn,
                         TotalWeight = entry.TotalWeight,
                         Width = entry.Width,
                         Winding = entry.Winding,
                         Strength = entry.Strength,
                         BreakingStrength = entry.BreakingStrength,
                         AdhesionStrength = entry.AdhesionStrength,
                         Temperature = entry.Temperature,
                         ColorUa = entry.ColorUa,
                         ColorRu = entry.ColorRu,
                         ColorEn = entry.ColorEn,
                         inStock = entry.inStock,
                         IsStock = entry.IsStock,
                         StockPriceEn = entry.StockPriceEn,
                         StockPriceUa = entry.StockPriceUa,
                         ManufacturerEn = entry.ManufacturerEn,
                         ManufacturerRu = entry.ManufacturerRu,
                         ManufacturerUa = entry.ManufacturerUa,
                         CountryOfOriginEn = entry.CountryOfOriginEn,
                         CountryOfOriginRu = entry.CountryOfOriginRu,
                         CountryOfOriginUa = entry.CountryOfOriginUa,
                         SeasonEn = entry.SeasonEn,
                         SeasonRu = entry.SeasonRu,
                         SeasonUa = entry.SeasonUa,
                         MaterialEn = entry.MaterialEn,
                         MaterialRu = entry.MaterialRu,
                         MaterialUa = entry.MaterialUa,
                         DensityEn = entry.DensityEn,
                         DensityRu = entry.DensityRu,
                         DensityUa = entry.DensityUa,
                         SizeEn = entry.SizeEn,
                         SizeRu = entry.SizeRu,
                         SizeUa = entry.SizeUa,
                         WarrantyPeriod = entry.WarrantyPeriod,
                         PreparationTime = entry.PreparationTime,
                         SparesTypeEn = entry.SparesTypeEn,
                         SparesTypeRu = entry.SparesTypeRu,
                         SparesTypeUa = entry.SparesTypeUa,
                         TextileProductTypeEn = entry.TextileProductTypeEn,
                         TextileProductTypeRu = entry.TextileProductTypeRu,
                         TextileProductTypeUa = entry.TextileProductTypeUa,
                         DescriptionEn = entry.DescriptionEn,
                         DescriptionRu = entry.DescriptionRu,
                         DescriptionUa = entry.DescriptionUa,
                         ItemStatus = entry.ItemStatus,
                         ProductBuyTypeMeter = entry.ProductBuyTypeMeter
                     }).FirstOrDefault();

                item.PriceUa = double.Parse(item.PriceUa.ToString(), Thread.CurrentThread.CurrentCulture.NumberFormat);

                var categories = db.CategoryDb.Select(u => u.CategoryNameRu).ToList();
                var subCategories = db.SubCategoryDb.Select(u => u.SubCategoryNameRu).ToList();

                item.CategoriesList = categories;
                item.SubCategoriesList = subCategories;
            }
            return item;
        }

        public static void AddItem(AdminItemVM item)
        {
            List<string> images = Image.UploadNewImages(item);

            using (DataBaseContext db = new DataBaseContext())
            {
                var category = db.CategoryDb.Where(u => u.CategoryNameRu == item.CategoryNameRu).FirstOrDefault();

                item.CategoryNameEn = category.CategoryNameEn;
                item.CategoryNameUa = category.CategoryNameUa;

                var subCategory = db.SubCategoryDb.Where(u => u.SubCategoryNameRu == item.SubCategoryNameRu).FirstOrDefault();

                if (subCategory != null)
                {
                    item.SubCategoryNameEn = subCategory.SubCategoryNameEn;
                    item.SubCategoryNameUa = subCategory.SubCategoryNameUa;
                }

                string vendorCode = "000001";

                try
                {
                    vendorCode = db.ItemsDb.OrderByDescending(u => u.VendorCode).First().VendorCode;

                    int number = Convert.ToInt32(vendorCode) + 1;

                    vendorCode = number.ToString();

                    for (int i = vendorCode.Length; i < 6; i++)
                        vendorCode = vendorCode.PadLeft(vendorCode.Length + 1, '0');
                }
                catch(Exception e)
                { }

                db.ItemsDb.Add(
                    new DbItems
                    {
                        VendorCode = vendorCode,
                        NameUa = item.NameUa,
                        NameRu = item.NameRu,
                        NameEn = item.NameEn,
                        CategoryNameUa = item.CategoryNameUa,
                        CategoryNameRu = item.CategoryNameRu,
                        CategoryNameEn = item.CategoryNameEn,
                        SubCategoryNameUa = item.SubCategoryNameUa,
                        SubCategoryNameRu = item.SubCategoryNameRu,
                        SubCategoryNameEn = item.SubCategoryNameEn,
                        PriceUa = item.PriceUa,
                        PriceEn = item.PriceEn,
                        Image1 = images[0],
                        Image2 = images[1],
                        Image3 = images[2],
                        Image4 = images[3],
                        CoveringUa = item.CoveringUa,
                        CoveringRu = item.CoveringRu,
                        CoveringEn = item.CoveringEn,
                        SpecificationUa = item.SpecificationUa,
                        SpecificationRu = item.SpecificationRu,
                        SpecificationEn = item.SpecificationEn,
                        ThreadUa = item.ThreadUa,
                        ThreadRu = item.ThreadRu,
                        ThreadEn = item.ThreadEn,
                        TotalWeight = item.TotalWeight,
                        Width = item.Width,
                        Winding = item.Winding,
                        Strength = item.Strength,
                        BreakingStrength = item.BreakingStrength,
                        AdhesionStrength = item.AdhesionStrength,
                        Temperature = item.Temperature,
                        ColorUa = item.ColorUa,
                        ColorRu = item.ColorRu,
                        ColorEn = item.ColorEn,
                        StockPriceUa = item.StockPriceUa,
                        StockPriceEn = item.StockPriceEn,
                        inStock = item.inStock,
                        IsStock = item.IsStock,
                        PriceUndefined = item.PriceUndefined,
                        ManufacturerRu = item.ManufacturerRu,
                        ManufacturerUa = item.ManufacturerUa,
                        ManufacturerEn = item.ManufacturerEn,
                        CountryOfOriginRu = item.CountryOfOriginRu,
                        CountryOfOriginUa = item.CountryOfOriginUa,
                        CountryOfOriginEn = item.CountryOfOriginEn,
                        SeasonRu = item.SeasonRu,
                        SeasonUa = item.SeasonUa,
                        SeasonEn = item.SeasonEn,
                        MaterialRu = item.MaterialRu,
                        MaterialUa = item.MaterialUa,
                        MaterialEn = item.MaterialEn,
                        DensityRu = item.DensityRu,
                        DensityUa = item.DensityUa,
                        DensityEn = item.DensityEn,
                        SizeRu = item.SizeRu,
                        SizeUa = item.SizeUa,
                        SizeEn = item.SizeEn,
                        WarrantyPeriod = item.WarrantyPeriod,
                        PreparationTime = item.PreparationTime,
                        SparesTypeRu = item.SparesTypeRu,
                        SparesTypeUa = item.SparesTypeUa,
                        SparesTypeEn = item.SparesTypeEn,
                        TextileProductTypeRu = item.TextileProductTypeRu,
                        TextileProductTypeUa = item.TextileProductTypeUa,
                        TextileProductTypeEn = item.TextileProductTypeEn,
                        DescriptionRu = item.DescriptionRu,
                        DescriptionUa = item.DescriptionUa,
                        DescriptionEn = item.DescriptionEn,
                        ItemStatus = item.ItemStatus,
                        ProductBuyTypeMeter = item.ProductBuyTypeMeter,
                    });

                db.SaveChanges();
            }
        }

        public static void EditItem(AdminItemVM item, IEnumerable<HttpPostedFileBase> uploads)
        {
            List<string> newImagesName = Image.UploadNewImages(item.Images);

            using (DataBaseContext db = new DataBaseContext())
            {
                var data =
                     (from entry in db.ItemsDb
                      where entry.Id == item.Id
                      select entry).FirstOrDefault();

                var categoryUa = (from entry in db.ItemsDb
                                  where entry.CategoryNameRu == item.CategoryNameRu
                                  select entry.CategoryNameUa).FirstOrDefault();
                var categoryEn = (from entry in db.CategoryDb
                                  where entry.CategoryNameRu == item.CategoryNameRu
                                  select entry.CategoryNameEn).FirstOrDefault();

                var subCategory = db.SubCategoryDb.Where(u => u.SubCategoryNameRu == item.SubCategoryNameRu).FirstOrDefault();

                if (subCategory != null)
                {
                    item.SubCategoryNameEn = subCategory.SubCategoryNameEn;
                    item.SubCategoryNameUa = subCategory.SubCategoryNameUa;
                }

                if (data.NameUa != item.NameUa)
                    data.NameUa = item.NameUa;
                if (data.NameRu != item.NameRu)
                    data.NameRu = item.NameRu;
                if (data.NameEn != item.NameEn)
                    data.NameEn = item.NameEn;

                if (data.CategoryNameRu != item.CategoryNameRu)
                {
                    data.CategoryNameRu = item.CategoryNameRu;
                    data.CategoryNameEn = categoryEn;
                    data.CategoryNameUa = categoryUa;
                }

                if (data.SubCategoryNameUa != item.SubCategoryNameUa)
                    data.SubCategoryNameUa = item.SubCategoryNameUa;
                if (data.SubCategoryNameRu != item.SubCategoryNameRu)
                    data.SubCategoryNameRu = item.SubCategoryNameRu;
                if (data.SubCategoryNameEn != item.SubCategoryNameEn)
                    data.SubCategoryNameEn = item.SubCategoryNameEn;

                if (data.PriceUa != item.PriceUa)
                    data.PriceUa = item.PriceUa;
                if (data.PriceEn != item.PriceEn)
                    data.PriceEn = item.PriceEn;
                if (data.DescriptionUa != item.DescriptionUa)
                    data.DescriptionUa = item.DescriptionUa;
                if (data.DescriptionRu != item.DescriptionRu)
                    data.DescriptionRu = item.DescriptionRu;
                if (data.DescriptionEn != item.DescriptionEn)
                    data.DescriptionEn = item.DescriptionEn;

                if(newImagesName.Count != 0)
                {
                    if (newImagesName[0] != null)
                        data.Image1 = newImagesName[0];
                    if (newImagesName[1] != null)
                        data.Image2 = newImagesName[1];
                    if (newImagesName[2] != null)
                        data.Image3 = newImagesName[2];
                    if (newImagesName[3] != null)
                        data.Image4 = newImagesName[3];
                }

                if (data.CoveringUa != item.CoveringUa)
                    data.CoveringUa = item.CoveringUa;
                if (data.CoveringRu != item.CoveringRu)
                    data.CoveringRu = item.CoveringRu;
                if (data.CoveringEn != item.CoveringEn)
                    data.CoveringEn = item.CoveringEn;

                if (data.SpecificationUa != item.SpecificationUa)
                    data.SpecificationUa = item.SpecificationUa;
                if (data.SpecificationRu != item.SpecificationRu)
                    data.SpecificationRu = item.SpecificationRu;
                if (data.SpecificationEn != item.SpecificationEn)
                    data.SpecificationEn = item.SpecificationEn;

                if (data.ThreadUa != item.ThreadUa)
                    data.ThreadUa = item.ThreadUa;
                if (data.ThreadRu != item.ThreadRu)
                    data.ThreadRu = item.ThreadRu;
                if (data.ThreadEn != item.ThreadEn)
                    data.ThreadEn = item.ThreadEn;

                if (data.TotalWeight != item.TotalWeight)
                    data.TotalWeight = item.TotalWeight;

                if (data.Width != item.Width)
                    data.Width = item.Width;

                if (data.Winding != item.Winding)
                    data.Winding = item.Winding;

                if (data.Strength != item.Strength)
                    data.Strength = item.Strength;

                if (data.BreakingStrength != item.BreakingStrength)
                    data.BreakingStrength = item.BreakingStrength;

                if (data.AdhesionStrength != item.AdhesionStrength)
                    data.AdhesionStrength = item.AdhesionStrength;

                if (data.Temperature != item.Temperature)
                    data.Temperature = item.Temperature;

                if (data.ColorUa != item.ColorUa)
                    data.ColorUa = item.ColorUa;
                if (data.ColorRu != item.ColorRu)
                    data.ColorRu = item.ColorRu;
                if (data.ColorEn != item.ColorEn)
                    data.ColorEn = item.ColorEn;

                if (data.inStock != item.inStock)
                    data.inStock = item.inStock;

                if (data.IsStock != item.IsStock)
                    data.IsStock = item.IsStock;

                if (data.StockPriceEn != item.StockPriceEn)
                    data.StockPriceEn = item.StockPriceEn;
                if (data.StockPriceUa != item.StockPriceUa)
                    data.StockPriceUa = item.StockPriceUa;

                if (data.PriceUndefined != item.PriceUndefined)
                    data.PriceUndefined = item.PriceUndefined;
                if (data.ManufacturerRu != item.ManufacturerRu)
                    data.ManufacturerRu = item.ManufacturerRu;
                if (data.ManufacturerUa != item.ManufacturerUa)
                    data.ManufacturerUa = item.ManufacturerUa;
                if (data.ManufacturerEn != item.ManufacturerEn)
                    data.ManufacturerEn = item.ManufacturerEn;
                if (data.CountryOfOriginRu != item.CountryOfOriginRu)
                    data.CountryOfOriginRu = item.CountryOfOriginRu;
                if (data.CountryOfOriginUa != item.CountryOfOriginUa)
                    data.CountryOfOriginUa = item.CountryOfOriginUa;
                if (data.CountryOfOriginEn != item.CountryOfOriginEn)
                    data.CountryOfOriginEn = item.CountryOfOriginEn;
                if (data.SeasonRu != item.SeasonRu)
                    data.SeasonRu = item.SeasonRu;
                if (data.SeasonUa != item.SeasonUa)
                    data.SeasonUa = item.SeasonUa;
                if (data.SeasonEn != item.SeasonEn)
                    data.SeasonEn = item.SeasonEn;
                if (data.MaterialRu != item.MaterialRu)
                    data.MaterialRu = item.MaterialRu;
                if (data.MaterialUa != item.MaterialUa)
                    data.MaterialUa = item.MaterialUa;
                if (data.MaterialEn != item.MaterialEn)
                    data.MaterialEn = item.MaterialEn;
                if (data.DensityRu != item.DensityRu)
                    data.DensityRu = item.DensityRu;
                if (data.DensityUa != item.DensityUa)
                    data.DensityUa = item.DensityUa;
                if (data.DensityEn != item.DensityEn)
                    data.DensityEn = item.DensityEn;
                if (data.SizeRu != item.SizeRu)
                    data.SizeRu = item.SizeRu;
                if (data.SizeUa != item.SizeUa)
                    data.SizeUa = item.SizeUa;
                if (data.SizeEn != item.SizeEn)
                    data.SizeEn = item.SizeEn;
                if (data.WarrantyPeriod != item.WarrantyPeriod)
                    data.WarrantyPeriod = item.WarrantyPeriod;
                if (data.PreparationTime != item.PreparationTime)
                    data.PreparationTime = item.PreparationTime;
                if (data.SparesTypeRu != item.SparesTypeRu)
                    data.SparesTypeRu = item.SparesTypeRu;
                if (data.SparesTypeUa != item.SparesTypeUa)
                    data.SparesTypeUa = item.SparesTypeUa;
                if (data.SparesTypeEn != item.SparesTypeEn)
                    data.SparesTypeEn = item.SparesTypeEn;
                if (data.TextileProductTypeRu != item.TextileProductTypeRu)
                    data.TextileProductTypeRu = item.TextileProductTypeRu;
                if (data.TextileProductTypeUa != item.TextileProductTypeUa)
                    data.TextileProductTypeUa = item.TextileProductTypeUa;
                if (data.TextileProductTypeEn != item.TextileProductTypeEn)
                    data.TextileProductTypeEn = item.TextileProductTypeEn;
                if (data.DescriptionRu != item.DescriptionRu)
                    data.DescriptionRu = item.DescriptionRu;
                if (data.DescriptionUa != item.DescriptionUa)
                    data.DescriptionUa = item.DescriptionUa;
                if (data.DescriptionEn != item.DescriptionEn)
                    data.DescriptionEn = item.DescriptionEn;
                if (data.ItemStatus != item.ItemStatus)
                    data.ItemStatus = item.ItemStatus;
                if (data.ProductBuyTypeMeter != item.ProductBuyTypeMeter)
                    data.ProductBuyTypeMeter = item.ProductBuyTypeMeter;

                db.SaveChanges();
            }
        }

        public static void CopyItem(int id)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var data =
                     (from entry in db.ItemsDb
                      where entry.Id == id
                      select entry).FirstOrDefault();

                string vendorCode = "000001";

                try
                {
                    vendorCode = db.ItemsDb.OrderByDescending(u => u.VendorCode).First().VendorCode;

                    int number = Convert.ToInt32(vendorCode) + 1;

                    vendorCode = number.ToString();

                    for (int i = vendorCode.Length; i < 6; i++)
                        vendorCode = vendorCode.PadLeft(vendorCode.Length + 1, '0');
                }
                catch (Exception e)
                { }

                data.VendorCode = vendorCode;

                //Copy image

                string image = "";

                if (data.Image1 != null)
                {
                    image = Image.CheckItemImageForExisting(data.Image1);

                    data.Image1 = HttpContext.Current.Server.MapPath("~/Content/images/items/" + data.Image1);

                    File.Copy(data.Image1, image, false);

                    data.Image1 = Path.GetFileName(image);
                }

                if (data.Image2 != null)
                {
                    image = Image.CheckItemImageForExisting(data.Image2);

                    data.Image2 = HttpContext.Current.Server.MapPath("~/Content/images/items/" + data.Image2);

                    File.Copy(data.Image2, image, false);

                    data.Image2 = Path.GetFileName(image);
                }

                if (data.Image3 != null)
                {
                    image = Image.CheckItemImageForExisting(data.Image3);

                    data.Image3 = HttpContext.Current.Server.MapPath("~/Content/images/items/" + data.Image3);

                    File.Copy(data.Image3, image, false);

                    data.Image3 = Path.GetFileName(image);
                }

                if (data.Image4 != null)
                {
                    image = Image.CheckItemImageForExisting(data.Image4);

                    data.Image4 = HttpContext.Current.Server.MapPath("~/Content/images/items/" + data.Image4);

                    File.Copy(data.Image4, image, false);

                    data.Image4 = Path.GetFileName(image);
                }

                //

                db.ItemsDb.Add(data);

                db.SaveChanges();
            }
        }

        public static void ChangeItemStatus(int id, bool status)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var data =
                     (from entry in db.ItemsDb
                      where entry.Id == id
                      select entry).FirstOrDefault();

                data.inStock = status;

                db.SaveChanges();
            }
        }

        public static void ChangeItemStockStatus(int id, bool status)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var data =
                     (from entry in db.ItemsDb
                      where entry.Id == id
                      select entry).FirstOrDefault();

                data.IsStock = status;

                db.SaveChanges();
            }
        }

        public static void DeleteItemById(int itemId)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var data =
                    (from entry in db.ItemsDb
                     where entry.Id == itemId
                     select entry).FirstOrDefault();

                List<string> filePathes = new List<string>
                {
                    HttpContext.Current.Server.MapPath("~/Content/images/items/" + data.Image1),
                    HttpContext.Current.Server.MapPath("~/Content/images/items/" + data.Image2),
                    HttpContext.Current.Server.MapPath("~/Content/images/items/" + data.Image3),
                    HttpContext.Current.Server.MapPath("~/Content/images/items/" + data.Image4)
                };

                foreach (var img in filePathes)
                    if (File.Exists(img))
                        File.Delete(img);

                db.ItemsDb.Remove(data);

                db.SaveChanges();
            }
        }

        public static List<string> GetImagesByItemId(int itemId)
        {
            string noImage = "no_image.png";

            List<string> images = new List<string>();

            DbItems data = new DbItems();

            using (DataBaseContext db = new DataBaseContext())
            {
                data =
                    (from entry in db.ItemsDb
                     where entry.Id == itemId
                     select entry).FirstOrDefault();

                if (data.Image1 != "")
                    images.Add(data.Image1);
                else
                    images.Add(noImage);
                if (data.Image2 != "")
                    images.Add(data.Image2);
                else
                    images.Add(noImage);
                if (data.Image3 != "")
                    images.Add(data.Image3);
                else
                    images.Add(noImage);
                if (data.Image4 != "")
                    images.Add(data.Image4);
                else
                    images.Add(noImage);
            }

            return images;
        }
    }
}