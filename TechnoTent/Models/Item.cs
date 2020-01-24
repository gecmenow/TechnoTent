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
                            inStock = u.IsStock,
                            CategoryId = u.CategoryId,
                            CategoryUrl = UrlHelper.GenerateSeoFriendlyURL(u.CategoryNameEn),
                            CategoryName = u.CategoryNameUa,
                            CategoryNameEn = u.CategoryNameEn,
                            SubCategoryUrl = UrlHelper.GenerateSeoFriendlyURL(u.SubCategoryNameEn),
                            SubCategoryName = u.SubCategoryNameUa,
                            Name = u.NameUa,
                            Price = u.PriceUa.ToString(),
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
                            Description = u.Description,
                            ItemStatus = u.ItemStatus,
                            ProductBuyTypeMeter = u.ProductBuyTypeMeter,
                            IndividualOrder = u.IndividualOrders,
                        }).First();

                        var similar = db.ItemsDb.Where(u => u.CategoryNameUa == item.CategoryName && u.Id != item.Id).Select(u => new ItemsVM
                        {
                            VendorCode = u.VendorCode,
                            inStock = u.IsStock,
                            CategoryId = u.CategoryId,
                            CategoryName = u.CategoryNameUa,
                            CategoryNameEn = u.CategoryNameEn,
                            SubCategoryName = u.SubCategoryNameUa,
                            Name = u.NameUa,
                            Price = u.PriceUa.ToString(),
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
                            Description = u.Description,
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
                            inStock = u.IsStock,
                            CategoryId = u.CategoryId,
                            CategoryUrl = UrlHelper.GenerateSeoFriendlyURL(u.CategoryNameEn),
                            CategoryName = u.CategoryNameEn,
                            CategoryNameEn = u.CategoryNameEn,
                            SubCategoryUrl = UrlHelper.GenerateSeoFriendlyURL(u.SubCategoryNameEn),
                            SubCategoryName = u.SubCategoryNameEn,
                            Name = u.NameEn,
                            Price = u.PriceEn.ToString(),
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
                            Description = u.Description,
                            ItemStatus = u.ItemStatus,
                            ProductBuyTypeMeter = u.ProductBuyTypeMeter,
                            IndividualOrder = u.IndividualOrders,
                        }).First();

                        var similar = db.ItemsDb.Where(u => u.CategoryNameEn == item.CategoryName && u.Id != item.Id).Select(u => new ItemsVM
                        {
                            VendorCode = u.VendorCode,
                            inStock = u.IsStock,
                            CategoryId = u.CategoryId,
                            CategoryName = u.CategoryNameEn,
                            CategoryNameEn = u.CategoryNameEn,
                            SubCategoryName = u.SubCategoryNameEn,
                            Name = u.NameEn,
                            Price = u.PriceEn.ToString(),
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
                            Description = u.Description,
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
                            inStock = u.IsStock,
                            CategoryId = u.CategoryId,
                            CategoryUrl = UrlHelper.GenerateSeoFriendlyURL(u.CategoryNameEn),
                            CategoryName = u.CategoryNameRu,
                            CategoryNameEn = u.CategoryNameEn,
                            SubCategoryUrl = UrlHelper.GenerateSeoFriendlyURL(u.SubCategoryNameEn),
                            SubCategoryName = u.SubCategoryNameRu,
                            Name = u.NameRu,
                            Price = u.PriceUa.ToString(),
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
                            Description = u.Description,
                            ItemStatus = u.ItemStatus,
                            ProductBuyTypeMeter = u.ProductBuyTypeMeter,
                            IndividualOrder = u.IndividualOrders,
                        }).First();

                        var similar = db.ItemsDb.Where(u => u.CategoryNameRu == item.CategoryName && u.Id != item.Id).Select(u => new ItemsVM
                        {
                            VendorCode = u.VendorCode,
                            inStock = u.IsStock,
                            CategoryId = u.CategoryId,
                            CategoryName = u.SubCategoryNameRu,
                            CategoryNameEn = u.CategoryNameEn,
                            SubCategoryName = u.SubCategoryNameRu,
                            Name = u.NameRu,
                            Price = u.PriceUa.ToString(),
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
                            Description = u.Description,
                            ItemStatus = u.ItemStatus,
                            ProductBuyTypeMeter = u.ProductBuyTypeMeter,
                            IndividualOrder = u.IndividualOrders,
                        }).ToList();

                        Random r = new Random();

                        List<ItemsVM> temp = new List<ItemsVM>();

                        temp = similar.ToList();

                        similar.Clear();

                        if(temp.Count() > 4)
                        {
                            while (similar.Count < 3)
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
                    }
                    break;
            }

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