using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnoTent.Cookies;
using TechnoTent.Models.DataBase;
using TechnoTent.Models.ViewModel;

namespace TechnoTent.Models
{
    public class Item
    {
        public static ItemsVM GetItem(string vendorCode)
        {
            ItemsVM item = new ItemsVM();

            List<ItemsVM> similar = new List<ItemsVM>();

            var language = Cookie.CheckLanguageCookie();

            switch (language)
            {
                case "uk":
                    using (DataBaseContext db = new DataBaseContext())
                    {
                        item = db.ItemsDb.Where(u => u.VendorCode == vendorCode).AsEnumerable().Select(u => new ItemsVM
                        {
                            Id = u.Id,
                            VendorCode = u.VendorCode,
                            inStock = u.inStock,
                            CategoryId = u.CategoryId,
                            CategoryUrl = UrlHelper.GenerateSeoFriendlyURL(u.CategoryNameEn),
                            CategoryName = u.CategoryNameUa,
                            CategoryNameEn = u.CategoryNameEn,
                            SubCategoryUrl = UrlHelper.GenerateSeoFriendlyURL(u.SubCategoryNameEn),
                            SubCategoryName = u.SubCategoryNameUa,
                            Name = u.NameUa,
                            Price = u.PriceUa.ToString(),
                            PriceEn = u.PriceEn,
                            PriceUndefined = u.PriceUndefined,
                            IsStock = u.IsStock,
                            StockPrice = u.StockPriceUa,
                            //Brand = u.Brand,
                            Image1 = u.Image1,
                            Image2 = u.Image2,
                            Image3 = u.Image3,
                            Image4 = u.Image4,
                            Covering = u.CoveringUa,
                            Specification = u.SpecificationUa,
                            Thread = u.ThreadUa,
                            TotalWeight = u.TotalWeight,
                            Width = u.Width,
                            Winding = u.Winding,
                            Strength = u.Strength,
                            BreakingStrength = u.BreakingStrength,
                            AdhesionStrength = u.AdhesionStrength,
                            Temperature = u.Temperature,
                            Color = u.ColorUa,
                            Manufacturer = u.ManufacturerUa,
                            CountryOfOrigin = u.CountryOfOriginUa,
                            Season = u.SeasonUa,
                            Material = u.MaterialUa,
                            Density = u.DensityUa,
                            Size = u.SizeUa,
                            WarrantyPeriod = u.WarrantyPeriod,
                            PreparationTime = u.PreparationTime,
                            SparesType = u.SparesTypeUa,
                            TextileProductType = u.TextileProductTypeUa,
                            Description = u.DescriptionUa,
                            ItemStatus = u.ItemStatus,
                            ProductBuyTypeMeter = u.ProductBuyTypeMeter,
                            IndividualOrder = u.IndividualOrders,
                        }).First();

                        similar = db.ItemsDb.Where(u => u.CategoryNameUa == item.CategoryName && u.Id != item.Id).AsEnumerable().Select(u => new ItemsVM
                        {
                            VendorCode = u.VendorCode,
                            inStock = u.inStock,
                            CategoryId = u.CategoryId,
                            CategoryName = u.CategoryNameUa,
                            CategoryNameEn = u.CategoryNameEn,
                            SubCategoryName = u.SubCategoryNameUa,
                            Name = u.NameUa,
                            NameUrl = UrlHelper.GenerateSeoFriendlyURL(u.NameEn),
                            Price = u.PriceUa.ToString(),
                            PriceEn = u.PriceEn,
                            PriceUndefined = u.PriceUndefined,
                            IsStock = u.IsStock,
                            StockPrice = u.StockPriceUa,
                            //Brand = u.Brand,
                            Image1 = u.Image1,
                            Covering = u.CoveringUa,
                            Specification = u.SpecificationUa,
                            Thread = u.ThreadUa,
                            TotalWeight = u.TotalWeight,
                            Width = u.Width,
                            Winding = u.Winding,
                            Strength = u.Strength,
                            BreakingStrength = u.BreakingStrength,
                            AdhesionStrength = u.AdhesionStrength,
                            Temperature = u.Temperature,
                            Color = u.ColorUa,
                            Manufacturer = u.ManufacturerUa,
                            CountryOfOrigin = u.CountryOfOriginUa,
                            Season = u.SeasonUa,
                            Material = u.MaterialUa,
                            Density = u.DensityUa,
                            Size = u.SizeUa,
                            WarrantyPeriod = u.WarrantyPeriod,
                            PreparationTime = u.PreparationTime,
                            SparesType = u.SparesTypeUa,
                            TextileProductType = u.TextileProductTypeUa,
                            Description = u.DescriptionUa,
                            ItemStatus = u.ItemStatus,
                            ProductBuyTypeMeter = u.ProductBuyTypeMeter,
                            IndividualOrder = u.IndividualOrders,
                        }).ToList();

                        item.SimilarItems = similar;
                    }
                    break;
                case "en":
                    using (DataBaseContext db = new DataBaseContext())
                    {
                        item = db.ItemsDb.Where(u => u.VendorCode == vendorCode).AsEnumerable().Select(u => new ItemsVM
                        {
                            Id = u.Id,
                            VendorCode = u.VendorCode,
                            inStock = u.inStock,
                            CategoryId = u.CategoryId,
                            CategoryUrl = UrlHelper.GenerateSeoFriendlyURL(u.CategoryNameEn),
                            CategoryName = u.CategoryNameEn,
                            CategoryNameEn = u.CategoryNameEn,
                            SubCategoryUrl = UrlHelper.GenerateSeoFriendlyURL(u.SubCategoryNameEn),
                            SubCategoryName = u.SubCategoryNameEn,
                            Name = u.NameEn,
                            Price = u.PriceEn.ToString(),
                            PriceEn = u.PriceEn,
                            PriceUndefined = u.PriceUndefined,
                            IsStock = u.IsStock,
                            StockPrice = u.StockPriceEn,
                            //Brand = u.Brand,
                            Image1 = u.Image1,
                            Image2 = u.Image2,
                            Image3 = u.Image3,
                            Image4 = u.Image4,
                            Covering = u.CoveringEn,
                            Specification = u.SpecificationEn,
                            Thread = u.ThreadEn,
                            TotalWeight = u.TotalWeight,
                            Width = u.Width,
                            Winding = u.Winding,
                            Strength = u.Strength,
                            BreakingStrength = u.BreakingStrength,
                            AdhesionStrength = u.AdhesionStrength,
                            Temperature = u.Temperature,
                            Color = u.ColorEn,
                            Manufacturer = u.ManufacturerEn,
                            CountryOfOrigin = u.CountryOfOriginEn,
                            Season = u.SeasonEn,
                            Material = u.MaterialEn,
                            Density = u.DensityEn,
                            Size = u.SizeEn,
                            WarrantyPeriod = u.WarrantyPeriod,
                            PreparationTime = u.PreparationTime,
                            SparesType = u.SparesTypeEn,
                            TextileProductType = u.TextileProductTypeEn,
                            Description = u.DescriptionEn,
                            ItemStatus = u.ItemStatus,
                            ProductBuyTypeMeter = u.ProductBuyTypeMeter,
                            IndividualOrder = u.IndividualOrders,
                        }).First();

                        similar = db.ItemsDb.Where(u => u.CategoryNameEn == item.CategoryName && u.Id != item.Id).AsEnumerable().Select(u => new ItemsVM
                        {
                            VendorCode = u.VendorCode,
                            inStock = u.inStock,
                            CategoryId = u.CategoryId,
                            CategoryName = u.CategoryNameEn,
                            CategoryNameEn = u.CategoryNameEn,
                            SubCategoryName = u.SubCategoryNameEn,
                            Name = u.NameEn,
                            NameUrl = UrlHelper.GenerateSeoFriendlyURL(u.NameEn),
                            Price = u.PriceEn.ToString(),
                            PriceEn = u.PriceEn,
                            PriceUndefined = u.PriceUndefined,
                            IsStock = u.IsStock,
                            StockPrice = u.StockPriceEn,
                            //Brand = u.Brand,
                            Image1 = u.Image1,
                            Covering = u.CoveringEn,
                            Specification = u.SpecificationEn,
                            Thread = u.ThreadEn,
                            TotalWeight = u.TotalWeight,
                            Width = u.Width,
                            Winding = u.Winding,
                            Strength = u.Strength,
                            BreakingStrength = u.BreakingStrength,
                            AdhesionStrength = u.AdhesionStrength,
                            Temperature = u.Temperature,
                            Color = u.ColorEn,
                            Manufacturer = u.ManufacturerEn,
                            CountryOfOrigin = u.CountryOfOriginEn,
                            Season = u.SeasonEn,
                            Material = u.MaterialEn,
                            Density = u.DensityEn,
                            Size = u.SizeEn,
                            WarrantyPeriod = u.WarrantyPeriod,
                            PreparationTime = u.PreparationTime,
                            SparesType = u.SparesTypeEn,
                            TextileProductType = u.TextileProductTypeEn,
                            Description = u.DescriptionEn,
                            ItemStatus = u.ItemStatus,
                            ProductBuyTypeMeter = u.ProductBuyTypeMeter,
                            IndividualOrder = u.IndividualOrders,
                        }).ToList();

                        item.SimilarItems = similar;
                    }
                    break;
                default:
                    using (DataBaseContext db = new DataBaseContext())
                    {
                        item = db.ItemsDb.Where(u => u.VendorCode == vendorCode).AsEnumerable().Select(u => new ItemsVM
                        {
                            Id = u.Id,
                            VendorCode = u.VendorCode,
                            inStock = u.inStock,
                            CategoryId = u.CategoryId,
                            CategoryUrl = UrlHelper.GenerateSeoFriendlyURL(u.CategoryNameEn),
                            CategoryName = u.CategoryNameRu,
                            CategoryNameEn = u.CategoryNameEn,
                            SubCategoryUrl = UrlHelper.GenerateSeoFriendlyURL(u.SubCategoryNameEn),
                            SubCategoryName = u.SubCategoryNameRu,
                            Name = u.NameRu,
                            Price = u.PriceUa.ToString(),
                            PriceEn = u.PriceEn,
                            PriceUndefined = u.PriceUndefined,
                            IsStock = u.IsStock,
                            StockPrice = u.StockPriceUa,
                            //Brand = u.Brand,
                            Image1 = u.Image1,
                            Image2 = u.Image2,
                            Image3 = u.Image3,
                            Image4 = u.Image4,
                            Covering = u.CoveringRu,
                            Specification = u.SpecificationRu,
                            Thread = u.ThreadRu,
                            TotalWeight = u.TotalWeight,
                            Width = u.Width,
                            Winding = u.Winding,
                            Strength = u.Strength,
                            BreakingStrength = u.BreakingStrength,
                            AdhesionStrength = u.AdhesionStrength,
                            Temperature = u.Temperature,
                            Color = u.ColorRu,
                            Manufacturer = u.ManufacturerRu,
                            CountryOfOrigin = u.CountryOfOriginRu,
                            Season = u.SeasonRu,
                            Material = u.MaterialRu,
                            Density = u.DensityRu,
                            Size = u.SizeRu,
                            WarrantyPeriod = u.WarrantyPeriod,
                            PreparationTime = u.PreparationTime,
                            SparesType = u.SparesTypeRu,
                            TextileProductType = u.TextileProductTypeRu,
                            Description = u.DescriptionRu,
                            ItemStatus = u.ItemStatus,
                            ProductBuyTypeMeter = u.ProductBuyTypeMeter,
                            IndividualOrder = u.IndividualOrders,
                        }).First();

                        similar = db.ItemsDb.Where(u => u.CategoryNameRu == item.CategoryName && u.Id != item.Id).AsEnumerable().Select(u => new ItemsVM
                        {
                            VendorCode = u.VendorCode,
                            inStock = u.inStock,
                            CategoryId = u.CategoryId,
                            CategoryName = u.SubCategoryNameRu,
                            CategoryNameEn = u.CategoryNameEn,
                            SubCategoryName = u.SubCategoryNameRu,
                            Name = u.NameRu,
                            NameUrl = UrlHelper.GenerateSeoFriendlyURL(u.NameEn),
                            Price = u.PriceUa.ToString(),
                            PriceEn = u.PriceEn,
                            PriceUndefined = u.PriceUndefined,
                            IsStock = u.IsStock,
                            StockPrice = u.StockPriceUa,
                            //Brand = u.Brand,
                            Image1 = u.Image1,
                            Covering = u.CoveringRu,
                            Specification = u.SpecificationRu,
                            Thread = u.ThreadRu,
                            TotalWeight = u.TotalWeight,
                            Width = u.Width,
                            Winding = u.Winding,
                            Strength = u.Strength,
                            BreakingStrength = u.BreakingStrength,
                            AdhesionStrength = u.AdhesionStrength,
                            Temperature = u.Temperature,
                            Color = u.ColorRu,
                            Manufacturer = u.ManufacturerRu,
                            CountryOfOrigin = u.CountryOfOriginRu,
                            Season = u.SeasonRu,
                            Material = u.MaterialRu,
                            Density = u.DensityRu,
                            Size = u.SizeRu,
                            WarrantyPeriod = u.WarrantyPeriod,
                            PreparationTime = u.PreparationTime,
                            SparesType = u.SparesTypeRu,
                            TextileProductType = u.TextileProductTypeRu,
                            Description = u.DescriptionRu,
                            ItemStatus = u.ItemStatus,
                            ProductBuyTypeMeter = u.ProductBuyTypeMeter,
                            IndividualOrder = u.IndividualOrders,
                        }).ToList();
                    }
                    break;
            }

            if (item.ProductBuyTypeMeter)
            {
                var rate = Convert.ToDouble(Exchange.GetExchange().rate);

                item.Price = Math.Round((item.PriceEn * rate), 2).ToString();
            }

            Random r = new Random();

            List<ItemsVM> temp = new List<ItemsVM>();

            temp = similar.ToList();

            similar.Clear();

            if (temp.Count() > 4)
            {
                while (similar.Count < 4)
                {
                    var count = temp.Count() - 1;

                    int index = r.Next(count);

                    if (similar.Count() != 0)
                    {
                        if (!similar.Contains(temp[index]))
                            similar.Add(temp[index]);
                    }
                    else
                        similar.Add(temp[index]);
                }
            }
            else
                while (similar.Count < temp.Count() - 1)
                {
                    var count = temp.Count() - 1;

                    int index = r.Next(count);

                    if (similar.Count() != 0)
                    {
                        if (!similar.Contains(temp[index]))
                            similar.Add(temp[index]);
                    }
                    else
                        similar.Add(temp[index]);
                }

            foreach (var data in similar)
                if (data.Image1 == null && data.Image2 == null && data.Image3 == null && data.Image4 == null)
                    data.Image1 = Image.GetImageIfNull();

            item.SimilarItems = similar;

            if (item.Image1 == null &&
                item.Image2 == null &&
                item.Image3 == null &&
                item.Image4 == null
                )
            {
                item.Image1 = Image.GetImageIfNull();
            }

            return item;
        }
    }
}