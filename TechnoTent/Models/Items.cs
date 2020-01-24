using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnoTent.Cookies;
using TechnoTent.Models.DataBase;

namespace TechnoTent.Models.ViewModel.Items
{
    public class Item
    {
        public static List<ItemsOutputVM> GetItems(string category, ItemsOutputVM filters, List<string> subCategory,
            List<string> colors, double? minPrice, double? maxPrice)
        {
            List<ItemsVM> items = new List<ItemsVM>();

            category = UrlHelper.SeoFriendlyUlrToString(category);

            var language = Cookie.CheckLanguageCookie();

            switch(language)
            {
                case "uk":
                    using (DataBaseContext db = new DataBaseContext())
                    {
                        items = (from data in db.ItemsDb
                                 where data.CategoryNameEn.ToLower() == category
                                 orderby data.Id descending
                                 select data).AsEnumerable().
                                 Select(entry => new ItemsVM
                                 {
                                     Id = entry.Id,
                                     VendorCode = entry.VendorCode,
                                     CategoryId = entry.CategoryId,
                                     CategoryName = entry.CategoryNameUa,
                                     CategoryNameEn = entry.CategoryNameEn,
                                     CategoryUrl = UrlHelper.GenerateSeoFriendlyURL(entry.CategoryNameEn),
                                     SubCategoryName = entry.SubCategoryNameUa,
                                     SubCategoryUrl = UrlHelper.GenerateSeoFriendlyURL(entry.SubCategoryNameEn),
                                     NameUrl = UrlHelper.GenerateSeoFriendlyURL(entry.NameEn),
                                     Name = entry.NameUa,
                                     //Brand = entry.Brand,
                                     Price = entry.PriceUa.ToString(),
                                     StockPrice = entry.StockPriceUa,
                                     PriceUndefined = entry.PriceUndefined,
                                     Image1 = entry.Image1,
                                     Image2 = entry.Image2,
                                     Image3 = entry.Image3,
                                     Image4 = entry.Image4,
                                     Covering = entry.CoveringUa,
                                     Specification = entry.SpecificationUa,
                                     Thread = entry.ThreadUa,
                                     TotalWeight = entry.TotalWeight,
                                     Width = entry.Width,
                                     Winding = entry.Winding,
                                     Strength = entry.Strength,
                                     BreakingStrength = entry.BreakingStrength,
                                     AdhesionStrength = entry.AdhesionStrength,
                                     Temperature = entry.Temperature,
                                     Color = entry.ColorUa,
                                     Manufacturer = entry.ManufacturerUa,
                                     CountryOfOrigin = entry.CountryOfOriginUa,
                                     Season = entry.SeasonUa,
                                     Material = entry.MaterialUa,
                                     Density = entry.DensityUa,
                                     Size = entry.SizeUa,
                                     WarrantyPeriod = entry.WarrantyPeriod,
                                     PreparationTime = entry.PreparationTime,
                                     SparesType = entry.SparesTypeUa,
                                     TextileProductType = entry.TextileProductTypeUa,
                                     IsStock = entry.inStock,
                                     inStock = entry.inStock,
                                     Description = entry.DescriptionUa,
                                     ProductBuyTypeMeter = entry.ProductBuyTypeMeter,
                                 }).ToList();
                    }
                    break;
                case "en":
                    using (DataBaseContext db = new DataBaseContext())
                    {
                        items = (from data in db.ItemsDb
                                 where data.CategoryNameEn.ToLower() == category
                                 orderby data.Id descending
                                 select data).AsEnumerable().
                                 Select(entry => new ItemsVM
                                 {
                                     Id = entry.Id,
                                     VendorCode = entry.VendorCode,
                                     CategoryId = entry.CategoryId,
                                     CategoryName = entry.CategoryNameEn,
                                     CategoryNameEn = entry.CategoryNameEn,
                                     CategoryUrl = UrlHelper.GenerateSeoFriendlyURL(entry.CategoryNameEn),
                                     SubCategoryName = entry.SubCategoryNameEn,
                                     SubCategoryUrl = UrlHelper.GenerateSeoFriendlyURL(entry.SubCategoryNameEn),
                                     NameUrl = UrlHelper.GenerateSeoFriendlyURL(entry.NameEn),
                                     Name = entry.NameEn,
                                     //Brand = entry.Brand,
                                     Price = entry.PriceEn.ToString(),
                                     StockPrice = entry.StockPriceEn,
                                     PriceUndefined = entry.PriceUndefined,
                                     Image1 = entry.Image1,
                                     Image2 = entry.Image2,
                                     Image3 = entry.Image3,
                                     Image4 = entry.Image4,
                                     Covering = entry.CoveringEn,
                                     Specification = entry.SpecificationEn,
                                     Thread = entry.ThreadEn,
                                     TotalWeight = entry.TotalWeight,
                                     Width = entry.Width,
                                     Winding = entry.Winding,
                                     Strength = entry.Strength,
                                     BreakingStrength = entry.BreakingStrength,
                                     AdhesionStrength = entry.AdhesionStrength,
                                     Temperature = entry.Temperature,
                                     Color = entry.ColorEn,
                                     Manufacturer = entry.ManufacturerEn,
                                     CountryOfOrigin = entry.CountryOfOriginEn,
                                     Season = entry.SeasonEn,
                                     Material = entry.MaterialEn,
                                     Density = entry.DensityEn,
                                     Size = entry.SizeEn,
                                     WarrantyPeriod = entry.WarrantyPeriod,
                                     PreparationTime = entry.PreparationTime,
                                     SparesType = entry.SparesTypeEn,
                                     TextileProductType = entry.TextileProductTypeEn,
                                     IsStock = entry.inStock,
                                     inStock = entry.inStock,
                                     Description = entry.DescriptionEn,
                                     ProductBuyTypeMeter = entry.ProductBuyTypeMeter,
                                 }).ToList();
                    }
                    break;
                default:
                    using (DataBaseContext db = new DataBaseContext())
                    {
                        items = (from data in db.ItemsDb
                                 where data.CategoryNameEn.ToLower() == category
                                 orderby data.Id descending
                                 select data).AsEnumerable().
                                 Select(entry => new ItemsVM
                                 {
                                     Id = entry.Id,
                                     VendorCode = entry.VendorCode,
                                     CategoryId = entry.CategoryId,
                                     CategoryName = entry.CategoryNameRu,
                                     CategoryNameEn = entry.CategoryNameEn,
                                     CategoryUrl = UrlHelper.GenerateSeoFriendlyURL(entry.CategoryNameEn),
                                     SubCategoryName = entry.SubCategoryNameRu,
                                     SubCategoryUrl = UrlHelper.GenerateSeoFriendlyURL(entry.SubCategoryNameEn),
                                     NameUrl = UrlHelper.GenerateSeoFriendlyURL(entry.NameEn),
                                     Name = entry.NameRu,
                                     //Brand = entry.Brand,
                                     Price = entry.PriceUa.ToString(),
                                     StockPrice = entry.StockPriceUa,
                                     PriceUndefined = entry.PriceUndefined,
                                     Image1 = entry.Image1,
                                     Image2 = entry.Image2,
                                     Image3 = entry.Image3,
                                     Image4 = entry.Image4,
                                     Covering = entry.CoveringRu,
                                     Specification = entry.SpecificationRu,
                                     Thread = entry.ThreadRu,
                                     TotalWeight = entry.TotalWeight,
                                     Width = entry.Width,
                                     Winding = entry.Winding,
                                     Strength = entry.Strength,
                                     BreakingStrength = entry.BreakingStrength,
                                     AdhesionStrength = entry.AdhesionStrength,
                                     Temperature = entry.Temperature,
                                     Color = entry.ColorRu,
                                     Manufacturer = entry.ManufacturerRu,
                                     CountryOfOrigin = entry.CountryOfOriginRu,
                                     Season = entry.SeasonRu,
                                     Material = entry.MaterialRu,
                                     Density = entry.DensityRu,
                                     Size = entry.SizeRu,
                                     WarrantyPeriod = entry.WarrantyPeriod,
                                     PreparationTime = entry.PreparationTime,
                                     SparesType = entry.SparesTypeRu,
                                     TextileProductType = entry.TextileProductTypeRu,
                                     IsStock = entry.IsStock,
                                     inStock = entry.inStock,
                                     Description = entry.DescriptionRu,
                                     ProductBuyTypeMeter = entry.ProductBuyTypeMeter,
                                 }).ToList();
                    }
                    break;
            }

            List<ItemsOutputVM> filteredItems = new List<ItemsOutputVM>();

            filteredItems = GetFilteredItems(items, category, filters, subCategory, colors, minPrice, maxPrice);
                
            return filteredItems;
        }
        
        /*public static List<ItemsOutputVM> GetItems(string category, string subCategory, ItemsOutputVM filters, List<string> brands)
        {
            List<ItemsVM> items = new List<ItemsVM>();

            category = UrlHelper.SeoFriendlyUlrToString(category);

            using (DataBaseContext db = new DataBaseContext())
            {
                items = (from entry in db.ItemsDb
                         where entry.CategoryNameEn.ToLower() == category
                         orderby entry.Id descending
                         select new ItemsVM
                         {
                             Id = entry.Id,
                             CategoryId = entry.CategoryId,
                             CategoryNameUa = entry.CategoryNameUa,
                             CategoryNameRu = entry.CategoryNameRu,
                             CategoryNameEn = entry.CategoryNameEn,
                             SubCategoryNameUa = entry.SubCategoryNameUa,
                             SubCategoryNameRu = entry.SubCategoryNameRu,
                             SubCategoryNameEn = entry.SubCategoryNameEn,
                             NameUa = entry.NameUa,
                             NameRu = entry.NameRu,
                             NameEn = entry.NameEn,
                             Brand = entry.Brand,
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
                             AdhesionStrengthUa = entry.AdhesionStrengthUa,
                             AdhesionStrengthRu = entry.AdhesionStrengthRu,
                             AdhesionStrengthEn = entry.AdhesionStrengthEn,
                             Temperature = entry.Temperature,
                             ColorUa = entry.ColorUa,
                             ColorRu = entry.ColorRu,
                             ColorEn = entry.ColorEn,
                         }).ToList();
            }

            var filteredItems = items.ToList();

            if (subCategory != null && subCategory != "")
                if (brands != null)
                {
                    if (!brands.Contains(subCategory))
                        brands.Add(subCategory);
                }
                else
                {
                    brands = new List<string>
                    {
                        subCategory
                    };
                }

            if (brands != null)
            {
                foreach (var brand in brands)
                    filteredItems = filteredItems.Where(u => u.Brand != brand).ToList();

                if (filteredItems.Count() != items.Count())
                    items = items.Except(filteredItems).ToList();
            }

            //чек на язык повесить надо
            List<string> colors = new List<string>();

            if (filters.Filters != null)
                foreach (var filterBrand in filters.Filters)
                {
                    if (filterBrand.Colors != null)
                    {
                        foreach (var color in filterBrand.Colors)
                            filteredItems = filteredItems.Where(u => u.ColorEn != color).ToList();

                        if (filteredItems.Count() != items.Count())
                            items = items.Except(filteredItems).ToList();
                    }
                }

            List<string> prices = new List<string>();

            //чек на язык повесить надо
            if (filters.Filters != null)
                foreach (var filterBrand in filters.Filters)
                {
                    if (filterBrand.PriceMax != 0)
                    {
                        filteredItems = items.Where(u => u.PriceEn <= filterBrand.PriceMax && u.PriceEn >= filterBrand.PriceMin).ToList();

                        if (filteredItems.Count() != items.Count())
                            items = items.Except(filteredItems).ToList();
                    }
                }

            List<string> categories;

            using (DataBaseContext db = new DataBaseContext())
            {
                categories =
                    (from entry in db.SubCategoryDb
                     select entry.SubCategoryName).ToList();
            }

            List<FiltersVM> filters1 = new List<FiltersVM>
            {
                new FiltersVM
                {
                    Brands = brands,
                    BrandsForFilters = categories.ToList(),
                }
            };

            List<ItemsOutputVM> items1 = new List<ItemsOutputVM>
            {
                new ItemsOutputVM
                {
                    Items = items,
                    Filters = filters1,
                    CategoryName = category,
                    CategoryId = items.Select(u=>u.CategoryId).First(),
                }
            };

            return items1;
        }
        */

        public static List<ItemsOutputVM> GetItemsPopular(string category, ItemsOutputVM filters, List<string> subCategory,
            List<string> colors, double? minPrice, double? maxPrice)
        {
            List<ItemsVM> items = new List<ItemsVM>();

            category = UrlHelper.SeoFriendlyUlrToString(category);

            var language = Cookie.CheckLanguageCookie();

            switch (language)
            {
                case "uk":
                    using (DataBaseContext db = new DataBaseContext())
                    {
                        items = (from data in db.ItemsDb
                                 where data.CategoryNameEn.ToLower() == category
                                 orderby data.OrderCount ascending
                                 select data).AsEnumerable().
                                 Select(entry => new ItemsVM
                                 {
                                     Id = entry.Id,
                                     VendorCode = entry.VendorCode,
                                     CategoryId = entry.CategoryId,
                                     CategoryName = entry.CategoryNameUa,
                                     CategoryNameEn = entry.CategoryNameEn,
                                     CategoryUrl = UrlHelper.GenerateSeoFriendlyURL(entry.CategoryNameEn),
                                     SubCategoryName = entry.SubCategoryNameUa,
                                     SubCategoryUrl = UrlHelper.GenerateSeoFriendlyURL(entry.SubCategoryNameEn),
                                     NameUrl = UrlHelper.GenerateSeoFriendlyURL(entry.NameEn),
                                     Name = entry.NameUa,
                                     //Brand = entry.Brand,
                                     Price = entry.PriceUa.ToString(),
                                     StockPrice = entry.StockPriceUa,
                                     PriceUndefined = entry.PriceUndefined,
                                     Image1 = entry.Image1,
                                     Image2 = entry.Image2,
                                     Image3 = entry.Image3,
                                     Image4 = entry.Image4,
                                     Covering = entry.CoveringUa,
                                     Specification = entry.SpecificationUa,
                                     Thread = entry.ThreadUa,
                                     TotalWeight = entry.TotalWeight,
                                     Width = entry.Width,
                                     Winding = entry.Winding,
                                     Strength = entry.Strength,
                                     BreakingStrength = entry.BreakingStrength,
                                     AdhesionStrength = entry.AdhesionStrength,
                                     Temperature = entry.Temperature,
                                     Color = entry.ColorUa,
                                     Manufacturer = entry.ManufacturerUa,
                                     CountryOfOrigin = entry.CountryOfOriginUa,
                                     Season = entry.SeasonUa,
                                     Material = entry.MaterialUa,
                                     Density = entry.DensityUa,
                                     Size = entry.SizeUa,
                                     WarrantyPeriod = entry.WarrantyPeriod,
                                     PreparationTime = entry.PreparationTime,
                                     SparesType = entry.SparesTypeUa,
                                     TextileProductType = entry.TextileProductTypeUa,
                                     IsStock = entry.inStock,
                                     inStock = entry.inStock,
                                     Description = entry.DescriptionUa,
                                     ProductBuyTypeMeter = entry.ProductBuyTypeMeter,
                                 }).ToList();
                    }
                    break;
                case "en":
                    using (DataBaseContext db = new DataBaseContext())
                    {
                        items = (from data in db.ItemsDb
                                 where data.CategoryNameEn.ToLower() == category
                                 orderby data.OrderCount ascending
                                 select data).AsEnumerable().
                                 Select(entry => new ItemsVM
                                 {
                                     Id = entry.Id,
                                     VendorCode = entry.VendorCode,
                                     CategoryId = entry.CategoryId,
                                     CategoryName = entry.CategoryNameEn,
                                     CategoryNameEn = entry.CategoryNameEn,
                                     CategoryUrl = UrlHelper.GenerateSeoFriendlyURL(entry.CategoryNameEn),
                                     SubCategoryName = entry.SubCategoryNameEn,
                                     SubCategoryUrl = UrlHelper.GenerateSeoFriendlyURL(entry.SubCategoryNameEn),
                                     NameUrl = UrlHelper.GenerateSeoFriendlyURL(entry.NameEn),
                                     Name = entry.NameEn,
                                     //Brand = entry.Brand,
                                     Price = entry.PriceEn.ToString(),
                                     StockPrice = entry.StockPriceEn,
                                     PriceUndefined = entry.PriceUndefined,
                                     Image1 = entry.Image1,
                                     Image2 = entry.Image2,
                                     Image3 = entry.Image3,
                                     Image4 = entry.Image4,
                                     Covering = entry.CoveringEn,
                                     Specification = entry.SpecificationEn,
                                     Thread = entry.ThreadEn,
                                     TotalWeight = entry.TotalWeight,
                                     Width = entry.Width,
                                     Winding = entry.Winding,
                                     Strength = entry.Strength,
                                     BreakingStrength = entry.BreakingStrength,
                                     AdhesionStrength = entry.AdhesionStrength,
                                     Temperature = entry.Temperature,
                                     Color = entry.ColorEn,
                                     Manufacturer = entry.ManufacturerEn,
                                     CountryOfOrigin = entry.CountryOfOriginEn,
                                     Season = entry.SeasonEn,
                                     Material = entry.MaterialEn,
                                     Density = entry.DensityEn,
                                     Size = entry.SizeEn,
                                     WarrantyPeriod = entry.WarrantyPeriod,
                                     PreparationTime = entry.PreparationTime,
                                     SparesType = entry.SparesTypeEn,
                                     TextileProductType = entry.TextileProductTypeEn,
                                     IsStock = entry.inStock,
                                     inStock = entry.inStock,
                                     Description = entry.DescriptionEn,
                                     ProductBuyTypeMeter = entry.ProductBuyTypeMeter,
                                 }).ToList();
                    }
                    break;
                default:
                    using (DataBaseContext db = new DataBaseContext())
                    {
                        items = (from data in db.ItemsDb
                                 where data.CategoryNameEn.ToLower() == category
                                 orderby data.OrderCount ascending
                                 select data).AsEnumerable().
                                 Select(entry => new ItemsVM
                                 {
                                     Id = entry.Id,
                                     VendorCode = entry.VendorCode,
                                     CategoryId = entry.CategoryId,
                                     CategoryName = entry.CategoryNameRu,
                                     CategoryNameEn = entry.CategoryNameEn,
                                     CategoryUrl = UrlHelper.GenerateSeoFriendlyURL(entry.CategoryNameEn),
                                     SubCategoryName = entry.SubCategoryNameRu,
                                     SubCategoryUrl = UrlHelper.GenerateSeoFriendlyURL(entry.SubCategoryNameEn),
                                     NameUrl = UrlHelper.GenerateSeoFriendlyURL(entry.NameEn),
                                     Name = entry.NameRu,
                                     //Brand = entry.Brand,
                                     Price = entry.PriceUa.ToString(),
                                     StockPrice = entry.StockPriceUa,
                                     PriceUndefined = entry.PriceUndefined,
                                     Image1 = entry.Image1,
                                     Image2 = entry.Image2,
                                     Image3 = entry.Image3,
                                     Image4 = entry.Image4,
                                     Covering = entry.CoveringRu,
                                     Specification = entry.SpecificationRu,
                                     Thread = entry.ThreadRu,
                                     TotalWeight = entry.TotalWeight,
                                     Width = entry.Width,
                                     Winding = entry.Winding,
                                     Strength = entry.Strength,
                                     BreakingStrength = entry.BreakingStrength,
                                     AdhesionStrength = entry.AdhesionStrength,
                                     Temperature = entry.Temperature,
                                     Color = entry.ColorRu,
                                     Manufacturer = entry.ManufacturerRu,
                                     CountryOfOrigin = entry.CountryOfOriginRu,
                                     Season = entry.SeasonRu,
                                     Material = entry.MaterialRu,
                                     Density = entry.DensityRu,
                                     Size = entry.SizeRu,
                                     WarrantyPeriod = entry.WarrantyPeriod,
                                     PreparationTime = entry.PreparationTime,
                                     SparesType = entry.SparesTypeRu,
                                     TextileProductType = entry.TextileProductTypeRu,
                                     IsStock = entry.inStock,
                                     inStock = entry.inStock,
                                     Description = entry.DescriptionRu,
                                     ProductBuyTypeMeter = entry.ProductBuyTypeMeter,
                                 }).ToList();
                    }
                    break;
            }

            List<ItemsOutputVM> filteredItems = new List<ItemsOutputVM>();

            filteredItems = GetFilteredItems(items, category, filters, subCategory, colors, minPrice, maxPrice);

            return filteredItems;
        }

        public static List<ItemsOutputVM> GetItemsPriceLow(string category, ItemsOutputVM filters, List<string> subCategory,
            List<string> colors, double? minPrice, double? maxPrice)
        {
            List<ItemsVM> items = new List<ItemsVM>();

            category = UrlHelper.SeoFriendlyUlrToString(category);

            var language = Cookie.CheckLanguageCookie();

            switch (language)
            {
                case "uk":
                    using (DataBaseContext db = new DataBaseContext())
                    {
                        items = (from data in db.ItemsDb
                                 where data.CategoryNameEn.ToLower() == category
                                 orderby data.PriceUa ascending
                                 select data).AsEnumerable().
                                 Select(entry => new ItemsVM
                                 {
                                     Id = entry.Id,
                                     VendorCode = entry.VendorCode,
                                     CategoryId = entry.CategoryId,
                                     CategoryName = entry.CategoryNameUa,
                                     CategoryNameEn = entry.CategoryNameEn,
                                     CategoryUrl = UrlHelper.GenerateSeoFriendlyURL(entry.CategoryNameEn),
                                     SubCategoryName = entry.SubCategoryNameUa,
                                     SubCategoryUrl = UrlHelper.GenerateSeoFriendlyURL(entry.SubCategoryNameEn),
                                     NameUrl = UrlHelper.GenerateSeoFriendlyURL(entry.NameEn),
                                     Name = entry.NameUa,
                                     //Brand = entry.Brand,
                                     Price = entry.PriceUa.ToString(),
                                     StockPrice = entry.StockPriceUa,
                                     PriceUndefined = entry.PriceUndefined,
                                     Image1 = entry.Image1,
                                     Image2 = entry.Image2,
                                     Image3 = entry.Image3,
                                     Image4 = entry.Image4,
                                     Covering = entry.CoveringUa,
                                     Specification = entry.SpecificationUa,
                                     Thread = entry.ThreadUa,
                                     TotalWeight = entry.TotalWeight,
                                     Width = entry.Width,
                                     Winding = entry.Winding,
                                     Strength = entry.Strength,
                                     BreakingStrength = entry.BreakingStrength,
                                     AdhesionStrength = entry.AdhesionStrength,
                                     Temperature = entry.Temperature,
                                     Color = entry.ColorUa,
                                     Manufacturer = entry.ManufacturerUa,
                                     CountryOfOrigin = entry.CountryOfOriginUa,
                                     Season = entry.SeasonUa,
                                     Material = entry.MaterialUa,
                                     Density = entry.DensityUa,
                                     Size = entry.SizeUa,
                                     WarrantyPeriod = entry.WarrantyPeriod,
                                     PreparationTime = entry.PreparationTime,
                                     SparesType = entry.SparesTypeUa,
                                     TextileProductType = entry.TextileProductTypeUa,
                                     IsStock = entry.inStock,
                                     inStock = entry.inStock,
                                     Description = entry.DescriptionUa,
                                     ProductBuyTypeMeter = entry.ProductBuyTypeMeter,
                                 }).ToList();
                    }
                    break;
                case "en":
                    using (DataBaseContext db = new DataBaseContext())
                    {
                        items = (from data in db.ItemsDb
                                 where data.CategoryNameEn.ToLower() == category
                                 orderby data.PriceEn ascending
                                 select data).AsEnumerable().
                                 Select(entry => new ItemsVM
                                 {
                                     Id = entry.Id,
                                     VendorCode = entry.VendorCode,
                                     CategoryId = entry.CategoryId,
                                     CategoryName = entry.CategoryNameEn,
                                     CategoryNameEn = entry.CategoryNameEn,
                                     CategoryUrl = UrlHelper.GenerateSeoFriendlyURL(entry.CategoryNameEn),
                                     SubCategoryName = entry.SubCategoryNameEn,
                                     SubCategoryUrl = UrlHelper.GenerateSeoFriendlyURL(entry.SubCategoryNameEn),
                                     NameUrl = UrlHelper.GenerateSeoFriendlyURL(entry.NameEn),
                                     Name = entry.NameEn,
                                     //Brand = entry.Brand,
                                     Price = entry.PriceEn.ToString(),
                                     StockPrice = entry.StockPriceEn,
                                     PriceUndefined = entry.PriceUndefined,
                                     Image1 = entry.Image1,
                                     Image2 = entry.Image2,
                                     Image3 = entry.Image3,
                                     Image4 = entry.Image4,
                                     Covering = entry.CoveringEn,
                                     Specification = entry.SpecificationEn,
                                     Thread = entry.ThreadEn,
                                     TotalWeight = entry.TotalWeight,
                                     Width = entry.Width,
                                     Winding = entry.Winding,
                                     Strength = entry.Strength,
                                     BreakingStrength = entry.BreakingStrength,
                                     AdhesionStrength = entry.AdhesionStrength,
                                     Temperature = entry.Temperature,
                                     Color = entry.ColorEn,
                                     Manufacturer = entry.ManufacturerEn,
                                     CountryOfOrigin = entry.CountryOfOriginEn,
                                     Season = entry.SeasonEn,
                                     Material = entry.MaterialEn,
                                     Density = entry.DensityEn,
                                     Size = entry.SizeEn,
                                     WarrantyPeriod = entry.WarrantyPeriod,
                                     PreparationTime = entry.PreparationTime,
                                     SparesType = entry.SparesTypeEn,
                                     TextileProductType = entry.TextileProductTypeEn,
                                     IsStock = entry.inStock,
                                     inStock = entry.inStock,
                                     Description = entry.DescriptionEn,
                                     ProductBuyTypeMeter = entry.ProductBuyTypeMeter,
                                 }).ToList();
                    }
                    break;
                default:
                    using (DataBaseContext db = new DataBaseContext())
                    {
                        items = (from data in db.ItemsDb
                                 where data.CategoryNameEn.ToLower() == category
                                 orderby data.PriceUa ascending
                                 select data).AsEnumerable().
                                 Select(entry => new ItemsVM
                                 {
                                     Id = entry.Id,
                                     VendorCode = entry.VendorCode,
                                     CategoryId = entry.CategoryId,
                                     CategoryName = entry.CategoryNameRu,
                                     CategoryNameEn = entry.CategoryNameEn,
                                     CategoryUrl = UrlHelper.GenerateSeoFriendlyURL(entry.CategoryNameEn),
                                     SubCategoryName = entry.SubCategoryNameRu,
                                     SubCategoryUrl = UrlHelper.GenerateSeoFriendlyURL(entry.SubCategoryNameEn),
                                     NameUrl = UrlHelper.GenerateSeoFriendlyURL(entry.NameEn),
                                     Name = entry.NameRu,
                                     //Brand = entry.Brand,
                                     Price = entry.PriceUa.ToString(),
                                     StockPrice = entry.StockPriceUa,
                                     PriceUndefined = entry.PriceUndefined,
                                     Image1 = entry.Image1,
                                     Image2 = entry.Image2,
                                     Image3 = entry.Image3,
                                     Image4 = entry.Image4,
                                     Covering = entry.CoveringRu,
                                     Specification = entry.SpecificationRu,
                                     Thread = entry.ThreadRu,
                                     TotalWeight = entry.TotalWeight,
                                     Width = entry.Width,
                                     Winding = entry.Winding,
                                     Strength = entry.Strength,
                                     BreakingStrength = entry.BreakingStrength,
                                     AdhesionStrength = entry.AdhesionStrength,
                                     Temperature = entry.Temperature,
                                     Color = entry.ColorRu,
                                     Manufacturer = entry.ManufacturerRu,
                                     CountryOfOrigin = entry.CountryOfOriginRu,
                                     Season = entry.SeasonRu,
                                     Material = entry.MaterialRu,
                                     Density = entry.DensityRu,
                                     Size = entry.SizeRu,
                                     WarrantyPeriod = entry.WarrantyPeriod,
                                     PreparationTime = entry.PreparationTime,
                                     SparesType = entry.SparesTypeRu,
                                     TextileProductType = entry.TextileProductTypeRu,
                                     IsStock = entry.inStock,
                                     inStock = entry.inStock,
                                     Description = entry.DescriptionRu,
                                     ProductBuyTypeMeter = entry.ProductBuyTypeMeter,
                                 }).ToList();
                    }
                    break;
            }

            List<ItemsOutputVM> filteredItems = new List<ItemsOutputVM>();

            filteredItems = GetFilteredItems(items, category, filters, subCategory, colors, minPrice, maxPrice);

            return filteredItems;
        }

        public static List<ItemsOutputVM> GetItemsPriceHigh(string category, ItemsOutputVM filters, List<string> subCategory,
            List<string> colors, double? minPrice, double? maxPrice)
        {
            List<ItemsVM> items = new List<ItemsVM>();

            category = UrlHelper.SeoFriendlyUlrToString(category);

            var language = Cookie.CheckLanguageCookie();

            switch (language)
            {
                case "uk":
                    using (DataBaseContext db = new DataBaseContext())
                    {
                        items = (from data in db.ItemsDb
                                 where data.CategoryNameEn.ToLower() == category
                                 orderby data.PriceUa descending
                                 select data).AsEnumerable().
                                 Select(entry => new ItemsVM
                                 {
                                     Id = entry.Id,
                                     VendorCode = entry.VendorCode,
                                     CategoryId = entry.CategoryId,
                                     CategoryName = entry.CategoryNameUa,
                                     CategoryNameEn = entry.CategoryNameEn,
                                     CategoryUrl = UrlHelper.GenerateSeoFriendlyURL(entry.CategoryNameEn),
                                     SubCategoryName = entry.SubCategoryNameUa,
                                     SubCategoryUrl = UrlHelper.GenerateSeoFriendlyURL(entry.SubCategoryNameEn),
                                     NameUrl = UrlHelper.GenerateSeoFriendlyURL(entry.NameEn),
                                     Name = entry.NameUa,
                                     //Brand = entry.Brand,
                                     Price = entry.PriceUa.ToString(),
                                     StockPrice = entry.StockPriceUa,
                                     PriceUndefined = entry.PriceUndefined,
                                     Image1 = entry.Image1,
                                     Image2 = entry.Image2,
                                     Image3 = entry.Image3,
                                     Image4 = entry.Image4,
                                     Covering = entry.CoveringUa,
                                     Specification = entry.SpecificationUa,
                                     Thread = entry.ThreadUa,
                                     TotalWeight = entry.TotalWeight,
                                     Width = entry.Width,
                                     Winding = entry.Winding,
                                     Strength = entry.Strength,
                                     BreakingStrength = entry.BreakingStrength,
                                     AdhesionStrength = entry.AdhesionStrength,
                                     Temperature = entry.Temperature,
                                     Color = entry.ColorUa,
                                     Manufacturer = entry.ManufacturerUa,
                                     CountryOfOrigin = entry.CountryOfOriginUa,
                                     Season = entry.SeasonUa,
                                     Material = entry.MaterialUa,
                                     Density = entry.DensityUa,
                                     Size = entry.SizeUa,
                                     WarrantyPeriod = entry.WarrantyPeriod,
                                     PreparationTime = entry.PreparationTime,
                                     SparesType = entry.SparesTypeUa,
                                     TextileProductType = entry.TextileProductTypeUa,
                                     IsStock = entry.inStock,
                                     inStock = entry.inStock,
                                     Description = entry.DescriptionUa,
                                     ProductBuyTypeMeter = entry.ProductBuyTypeMeter,
                                 }).ToList();
                    }
                    break;
                case "en":
                    using (DataBaseContext db = new DataBaseContext())
                    {
                        items = (from data in db.ItemsDb
                                 where data.CategoryNameEn.ToLower() == category
                                 orderby data.PriceEn descending
                                 select data).AsEnumerable().
                                 Select(entry => new ItemsVM
                                 {
                                     Id = entry.Id,
                                     VendorCode = entry.VendorCode,
                                     CategoryId = entry.CategoryId,
                                     CategoryName = entry.CategoryNameEn,
                                     CategoryNameEn = entry.CategoryNameEn,
                                     CategoryUrl = UrlHelper.GenerateSeoFriendlyURL(entry.CategoryNameEn),
                                     SubCategoryName = entry.SubCategoryNameEn,
                                     SubCategoryUrl = UrlHelper.GenerateSeoFriendlyURL(entry.SubCategoryNameEn),
                                     NameUrl = UrlHelper.GenerateSeoFriendlyURL(entry.NameEn),
                                     Name = entry.NameEn,
                                     //Brand = entry.Brand,
                                     Price = entry.PriceEn.ToString(),
                                     StockPrice = entry.StockPriceEn,
                                     PriceUndefined = entry.PriceUndefined,
                                     Image1 = entry.Image1,
                                     Image2 = entry.Image2,
                                     Image3 = entry.Image3,
                                     Image4 = entry.Image4,
                                     Covering = entry.CoveringEn,
                                     Specification = entry.SpecificationEn,
                                     Thread = entry.ThreadEn,
                                     TotalWeight = entry.TotalWeight,
                                     Width = entry.Width,
                                     Winding = entry.Winding,
                                     Strength = entry.Strength,
                                     BreakingStrength = entry.BreakingStrength,
                                     AdhesionStrength = entry.AdhesionStrength,
                                     Temperature = entry.Temperature,
                                     Color = entry.ColorEn,
                                     Manufacturer = entry.ManufacturerEn,
                                     CountryOfOrigin = entry.CountryOfOriginEn,
                                     Season = entry.SeasonEn,
                                     Material = entry.MaterialEn,
                                     Density = entry.DensityEn,
                                     Size = entry.SizeEn,
                                     WarrantyPeriod = entry.WarrantyPeriod,
                                     PreparationTime = entry.PreparationTime,
                                     SparesType = entry.SparesTypeEn,
                                     TextileProductType = entry.TextileProductTypeEn,
                                     IsStock = entry.inStock,
                                     inStock = entry.inStock,
                                     Description = entry.DescriptionEn,
                                     ProductBuyTypeMeter = entry.ProductBuyTypeMeter,
                                 }).ToList();
                    }
                    break;
                default:
                    using (DataBaseContext db = new DataBaseContext())
                    {
                        items = (from data in db.ItemsDb
                                 where data.CategoryNameEn.ToLower() == category
                                 orderby data.PriceUa descending
                                 select data).AsEnumerable().
                                 Select(entry => new ItemsVM
                                 {
                                     Id = entry.Id,
                                     VendorCode = entry.VendorCode,
                                     CategoryId = entry.CategoryId,
                                     CategoryName = entry.CategoryNameRu,
                                     CategoryNameEn = entry.CategoryNameEn,
                                     CategoryUrl = UrlHelper.GenerateSeoFriendlyURL(entry.CategoryNameEn),
                                     SubCategoryName = entry.SubCategoryNameRu,
                                     SubCategoryUrl = UrlHelper.GenerateSeoFriendlyURL(entry.SubCategoryNameEn),
                                     NameUrl = UrlHelper.GenerateSeoFriendlyURL(entry.NameEn),
                                     Name = entry.NameRu,
                                     //Brand = entry.Brand,
                                     Price = entry.PriceUa.ToString(),
                                     StockPrice = entry.StockPriceUa,
                                     PriceUndefined = entry.PriceUndefined,
                                     Image1 = entry.Image1,
                                     Image2 = entry.Image2,
                                     Image3 = entry.Image3,
                                     Image4 = entry.Image4,
                                     Covering = entry.CoveringRu,
                                     Specification = entry.SpecificationRu,
                                     Thread = entry.ThreadRu,
                                     TotalWeight = entry.TotalWeight,
                                     Width = entry.Width,
                                     Winding = entry.Winding,
                                     Strength = entry.Strength,
                                     BreakingStrength = entry.BreakingStrength,
                                     AdhesionStrength = entry.AdhesionStrength,
                                     Temperature = entry.Temperature,
                                     Color = entry.ColorRu,
                                     Manufacturer = entry.ManufacturerRu,
                                     CountryOfOrigin = entry.CountryOfOriginRu,
                                     Season = entry.SeasonRu,
                                     Material = entry.MaterialRu,
                                     Density = entry.DensityRu,
                                     Size = entry.SizeRu,
                                     WarrantyPeriod = entry.WarrantyPeriod,
                                     PreparationTime = entry.PreparationTime,
                                     SparesType = entry.SparesTypeRu,
                                     TextileProductType = entry.TextileProductTypeRu,
                                     IsStock = entry.inStock,
                                     inStock = entry.inStock,
                                     Description = entry.DescriptionRu,
                                     ProductBuyTypeMeter = entry.ProductBuyTypeMeter,
                                 }).ToList();
                    }
                    break;
            }

            List<ItemsOutputVM> filteredItems = new List<ItemsOutputVM>();

            filteredItems = GetFilteredItems(items, category, filters, subCategory, colors, minPrice, maxPrice);

            return filteredItems;
        }

        public static List<ItemsOutputVM> GetFilteredItems(List<ItemsVM> items, string category, ItemsOutputVM filters, 
            List<string> subCategory, List<string> colors, double? priceMin, double? priceMax)
        {
            List<ItemsOutputVM> itemsList = new List<ItemsOutputVM>();

            try
            {
                foreach (var item in items)
                {
                    if (item.Covering != null)
                        item.DescriptionItem += item.Covering + " | ";
                    if (item.Density != null)
                        item.DescriptionItem += item.Density + " | ";
                    if (item.Material != null)
                        item.DescriptionItem += item.Material + " | ";
                    if (item.Season != null)
                        item.DescriptionItem += item.Season + " | ";
                    if (item.Size != null)
                        item.DescriptionItem += item.Size + " | ";
                    if (item.Specification != null)
                        item.DescriptionItem += item.Specification + " | ";
                    if (item.Strength != null)
                        item.DescriptionItem += item.Strength;
                }

                var filteredItems = items.ToList();

                if (subCategory == null)
                    subCategory = new List<string>();

                if (subCategory.Count() != 0)
                {
                    filteredItems.Clear();

                    foreach (var brand in subCategory)
                    {
                        foreach (var item in items)
                        {
                            if (item.SubCategoryName == brand)
                                filteredItems.Add(item);
                        }
                    }
                }

                if (colors == null)
                    colors = new List<string>();

                if (colors.Count() != 0)
                {
                    var temp = filteredItems.ToList();

                    filteredItems.Clear();

                    bool flag = true;

                    foreach (var color in colors)
                    {
                        if (temp.Where(u => u.Color == color).Count() != 0)
                        {
                            foreach (var item in temp)
                            {
                                if (item.Color == color)
                                    filteredItems.Add(item);
                            }
                        }
                        else
                        {
                            flag = false;
                        }
                    }

                    if (flag == false)
                        filteredItems.Clear();
                }

                var language = Cookie.CheckLanguageCookie();

                switch (language)
                {
                    case "uk":
                        if (priceMax != 0 && priceMax != null && filteredItems.Count() != 0)
                            filteredItems = filteredItems.Where(u => Convert.ToDouble(u.Price) <= priceMax && Convert.ToDouble(u.Price) >= priceMin).ToList();
                        break;
                    case "ru":
                        if (priceMax != 0 && priceMax != null && filteredItems.Count() != 0)
                            filteredItems = filteredItems.Where(u => Convert.ToDouble(u.Price) <= priceMax && Convert.ToDouble(u.Price) >= priceMin).ToList();
                        break;
                    default:
                        if (priceMax != 0 && priceMax != null && filteredItems.Count() != 0)
                            filteredItems = filteredItems.Where(u => Convert.ToDouble(u.Price) <= priceMax && Convert.ToDouble(u.Price) >= priceMin).ToList();
                        break;
                }

                List<string> categories;

                using (DataBaseContext db = new DataBaseContext())
                {
                    int categoryId;

                    switch (language)
                    {
                        case "uk":
                            categoryId = db.CategoryDb.Where(u => u.CategoryNameEn == category).FirstOrDefault().Id;

                            categories =
                                (from entry in db.SubCategoryDb
                                 where entry.CategoryId == categoryId
                                 select entry.SubCategoryNameUa).ToList();
                            break;
                        case "en":
                            categoryId = db.CategoryDb.Where(u => u.CategoryNameEn == category).FirstOrDefault().Id;

                            categories =
                                (from entry in db.SubCategoryDb
                                 where entry.CategoryId == categoryId
                                 select entry.SubCategoryNameEn).ToList();
                            break;
                        default:
                            categoryId = db.CategoryDb.Where(u => u.CategoryNameEn == category).FirstOrDefault().Id;

                            categories =
                                (from entry in db.SubCategoryDb
                                 where entry.CategoryId == categoryId
                                 select entry.SubCategoryNameRu).ToList();
                            break;
                    }
                }

                List<FiltersVM> filtersList = new List<FiltersVM>
                {
                    new FiltersVM
                    {
                        CategoryName = items.Select(u=>u.CategoryNameEn).First(),
                        Brands = subCategory,
                        Colors = colors,
                        PriceMax = Convert.ToDouble(priceMax),
                        PriceMin = Convert.ToDouble(priceMin),
                        BrandsForFilters = categories.ToList(),
                    }
                };

                var colorsList = items.Where(x => x.Color != "" && x.Color != " " && x.Color != null).Select(x => x.Color).Distinct().ToList();

                if (filteredItems.Count() != 0)
                {
                    itemsList.Add(new ItemsOutputVM
                    {
                        Items = filteredItems,
                        Filters = filtersList,
                        Colors = colorsList,
                        CategoryName = items.Select(u => u.CategoryName).First(),
                        CategoryId = filteredItems.Select(u => u.CategoryId).First(),
                    }
                    );
                }
                else
                {
                    itemsList.Add(new ItemsOutputVM
                    {
                        Filters = filtersList,
                        CategoryName = items.Select(u => u.CategoryName).First(),
                    }
                    );
                }

                foreach (var item in itemsList)
                {
                    if (item.Items != null)
                    {
                        item.PriceMax = Convert.ToDouble(item.Items.Max(u => u.Price));
                        item.PriceMin = Convert.ToDouble(item.Items.Min(u => u.Price));

                        if (item.PriceMin == item.PriceMax)
                            item.PriceMin = 0;

                        //foreach (var data in item.Items)
                        //{
                        //    if (data.Price == "0")
                        //    {
                        //        data.Price = data.PriceUndefined;
                        //    }
                        //}
                    }
                    else
                    {
                        item.PriceMax = 0;
                        item.PriceMin = 0;
                    }
                }
            }
            catch(Exception e)
            { }
            
            return itemsList;
        }

        public static ItemsVM GetFilteredItemsCount(string category, ItemsOutputVM filters, List<string> subCategory,
            List<string> colors, double? minPrice, double? maxPrice)
        {
            List<ItemsVM> items = new List<ItemsVM>();

            category = UrlHelper.SeoFriendlyUlrToString(category);

            var language = Cookie.CheckLanguageCookie();

            switch (language)
            {
                case "uk":
                    using (DataBaseContext db = new DataBaseContext())
                    {
                        items = (from data in db.ItemsDb
                                 where data.CategoryNameEn.ToLower() == category
                                 orderby data.Id descending
                                 select data).AsEnumerable().
                                 Select(entry => new ItemsVM
                                 {
                                     Id = entry.Id,
                                     VendorCode = entry.VendorCode,
                                     CategoryId = entry.CategoryId,
                                     CategoryName = entry.CategoryNameUa,
                                     CategoryNameEn = entry.CategoryNameEn,
                                     CategoryUrl = UrlHelper.GenerateSeoFriendlyURL(entry.CategoryNameEn),
                                     SubCategoryName = entry.SubCategoryNameUa,
                                     SubCategoryUrl = UrlHelper.GenerateSeoFriendlyURL(entry.SubCategoryNameEn),
                                     NameUrl = UrlHelper.GenerateSeoFriendlyURL(entry.NameEn),
                                     Name = entry.NameUa,
                                     //Brand = entry.Brand,
                                     Price = entry.PriceUa.ToString(),
                                     StockPrice = entry.StockPriceUa,
                                     PriceUndefined = entry.PriceUndefined,
                                     Image1 = entry.Image1,
                                     Image2 = entry.Image2,
                                     Image3 = entry.Image3,
                                     Image4 = entry.Image4,
                                     Covering = entry.CoveringUa,
                                     Specification = entry.SpecificationUa,
                                     Thread = entry.ThreadUa,
                                     TotalWeight = entry.TotalWeight,
                                     Width = entry.Width,
                                     Winding = entry.Winding,
                                     Strength = entry.Strength,
                                     BreakingStrength = entry.BreakingStrength,
                                     AdhesionStrength = entry.AdhesionStrength,
                                     Temperature = entry.Temperature,
                                     Color = entry.ColorUa,
                                     Manufacturer = entry.ManufacturerUa,
                                     CountryOfOrigin = entry.CountryOfOriginUa,
                                     Season = entry.SeasonUa,
                                     Material = entry.MaterialUa,
                                     Density = entry.DensityUa,
                                     Size = entry.SizeUa,
                                     WarrantyPeriod = entry.WarrantyPeriod,
                                     PreparationTime = entry.PreparationTime,
                                     SparesType = entry.SparesTypeUa,
                                     TextileProductType = entry.TextileProductTypeUa,
                                     IsStock = entry.inStock,
                                     ProductBuyTypeMeter = entry.ProductBuyTypeMeter,
                                 }).ToList();
                    }
                    break;
                case "en":
                    using (DataBaseContext db = new DataBaseContext())
                    {
                        items = (from data in db.ItemsDb
                                 where data.CategoryNameEn.ToLower() == category
                                 orderby data.Id descending
                                 select data).AsEnumerable().
                                 Select(entry => new ItemsVM
                                 {
                                     Id = entry.Id,
                                     VendorCode = entry.VendorCode,
                                     CategoryId = entry.CategoryId,
                                     CategoryName = entry.CategoryNameEn,
                                     CategoryNameEn = entry.CategoryNameEn,
                                     CategoryUrl = UrlHelper.GenerateSeoFriendlyURL(entry.CategoryNameEn),
                                     SubCategoryName = entry.SubCategoryNameEn,
                                     SubCategoryUrl = UrlHelper.GenerateSeoFriendlyURL(entry.SubCategoryNameEn),
                                     NameUrl = UrlHelper.GenerateSeoFriendlyURL(entry.NameEn),
                                     Name = entry.NameEn,
                                     //Brand = entry.Brand,
                                     Price = entry.PriceEn.ToString(),
                                     StockPrice = entry.StockPriceEn,
                                     PriceUndefined = entry.PriceUndefined,
                                     Image1 = entry.Image1,
                                     Image2 = entry.Image2,
                                     Image3 = entry.Image3,
                                     Image4 = entry.Image4,
                                     Covering = entry.CoveringEn,
                                     Specification = entry.SpecificationEn,
                                     Thread = entry.ThreadEn,
                                     TotalWeight = entry.TotalWeight,
                                     Width = entry.Width,
                                     Winding = entry.Winding,
                                     Strength = entry.Strength,
                                     BreakingStrength = entry.BreakingStrength,
                                     AdhesionStrength = entry.AdhesionStrength,
                                     Temperature = entry.Temperature,
                                     Color = entry.ColorEn,
                                     Manufacturer = entry.ManufacturerEn,
                                     CountryOfOrigin = entry.CountryOfOriginEn,
                                     Season = entry.SeasonEn,
                                     Material = entry.MaterialEn,
                                     Density = entry.DensityEn,
                                     Size = entry.SizeEn,
                                     WarrantyPeriod = entry.WarrantyPeriod,
                                     PreparationTime = entry.PreparationTime,
                                     SparesType = entry.SparesTypeEn,
                                     TextileProductType = entry.TextileProductTypeEn,
                                     IsStock = entry.inStock,
                                     ProductBuyTypeMeter = entry.ProductBuyTypeMeter,
                                 }).ToList();
                    }
                    break;
                default:
                    using (DataBaseContext db = new DataBaseContext())
                    {
                        items = (from data in db.ItemsDb
                                 where data.CategoryNameEn.ToLower() == category
                                 orderby data.Id descending
                                 select data).AsEnumerable().
                                 Select(entry => new ItemsVM
                                 {
                                     Id = entry.Id,
                                     VendorCode = entry.VendorCode,
                                     CategoryId = entry.CategoryId,
                                     CategoryName = entry.CategoryNameRu,
                                     CategoryNameEn = entry.CategoryNameEn,
                                     CategoryUrl = UrlHelper.GenerateSeoFriendlyURL(entry.CategoryNameEn),
                                     SubCategoryName = entry.SubCategoryNameRu,
                                     SubCategoryUrl = UrlHelper.GenerateSeoFriendlyURL(entry.SubCategoryNameEn),
                                     NameUrl = UrlHelper.GenerateSeoFriendlyURL(entry.NameEn),
                                     Name = entry.NameRu,
                                     //Brand = entry.Brand,
                                     Price = entry.PriceUa.ToString(),
                                     StockPrice = entry.StockPriceUa,
                                     PriceUndefined = entry.PriceUndefined,
                                     Image1 = entry.Image1,
                                     Image2 = entry.Image2,
                                     Image3 = entry.Image3,
                                     Image4 = entry.Image4,
                                     Covering = entry.CoveringRu,
                                     Specification = entry.SpecificationRu,
                                     Thread = entry.ThreadRu,
                                     TotalWeight = entry.TotalWeight,
                                     Width = entry.Width,
                                     Winding = entry.Winding,
                                     Strength = entry.Strength,
                                     BreakingStrength = entry.BreakingStrength,
                                     AdhesionStrength = entry.AdhesionStrength,
                                     Temperature = entry.Temperature,
                                     Color = entry.ColorRu,
                                     Manufacturer = entry.ManufacturerRu,
                                     CountryOfOrigin = entry.CountryOfOriginRu,
                                     Season = entry.SeasonRu,
                                     Material = entry.MaterialRu,
                                     Density = entry.DensityRu,
                                     Size = entry.SizeRu,
                                     WarrantyPeriod = entry.WarrantyPeriod,
                                     PreparationTime = entry.PreparationTime,
                                     SparesType = entry.SparesTypeRu,
                                     TextileProductType = entry.TextileProductTypeRu,
                                     IsStock = entry.inStock,
                                     ProductBuyTypeMeter = entry.ProductBuyTypeMeter,
                                 }).ToList();
                    }
                    break;
            }

            foreach(var item in items)
                if (item.Image1 == null &&
                    item.Image2 == null &&
                    item.Image3 == null &&
                    item.Image4 == null)
                {
                    item.Image1 = Image.GetImageIfNull();
                }

            List<ItemsOutputVM> filteredItems = new List<ItemsOutputVM>();

            filteredItems = GetFilteredItems(items, category, filters, subCategory, colors, minPrice, maxPrice);

            ItemsVM count = new ItemsVM();
            foreach (var item in filteredItems)
                if (item.Items != null)
                    count.ItemsCount = item.Items.Count();
                else
                    count.ItemsCount = 0;

            return count;
        }
    }
}