using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnoTent.Models.DataBase;
using TechnoTent.Models.ViewModel;

namespace TechnoTent.Models
{
    public class Category
    {
        public static List<CategoriesVM> GetMainCategories()
        {
            List<CategoriesVM> categoriesList = new List<CategoriesVM>();

            var language = Cookies.Cookie.CheckLanguageCookie();

            switch (language)
            {
                case "uk":
                    using (DataBaseContext db = new DataBaseContext())
                    {
                        var categories =
                            (from entry in db.CategoryDb
                             select entry).AsEnumerable().Select(u => new CategoriesVM
                             {
                                 CategoryId = u.Id,
                                 CategoryImage = u.CategoryImage,
                                 CategoryName = u.CategoryNameUa,
                                 CategoryUrl = UrlHelper.GenerateSeoFriendlyURL(u.CategoryNameEn)
                             }).ToList();

                        categoriesList = categories;
                    }
                    break;
                case "en":
                    using (DataBaseContext db = new DataBaseContext())
                    {
                        var categories =
                            (from entry in db.CategoryDb
                             select entry).AsEnumerable().Select(u => new CategoriesVM
                             {
                                 CategoryId = u.Id,
                                 CategoryImage = u.CategoryImage,
                                 CategoryName = u.CategoryNameEn,
                                 CategoryUrl = UrlHelper.GenerateSeoFriendlyURL(u.CategoryNameEn)
                             }).ToList();

                        categoriesList = categories;
                    }
                    break;
                default:
                    using (DataBaseContext db = new DataBaseContext())
                    {
                        var categories =
                            (from entry in db.CategoryDb
                             select entry).AsEnumerable().Select(u => new CategoriesVM
                             {
                                 CategoryId = u.Id,
                                 CategoryImage = u.CategoryImage,
                                 CategoryName = u.CategoryNameRu,
                                 CategoryUrl = UrlHelper.GenerateSeoFriendlyURL(u.CategoryNameEn)
                             }).ToList();

                        categoriesList = categories;
                    }
                    break;
            }

            return categoriesList;
        }

        public static List<CategoriesVM> GetCategories()
        {
            List<CategoriesVM> categoriesList = new List<CategoriesVM>();

            var language = Cookies.Cookie.CheckLanguageCookie();

            switch (language)
            {
                case "uk":
                    using (DataBaseContext db = new DataBaseContext())
                    {
                        var categories =
                            (from entry in db.CategoryDb
                             select entry).AsEnumerable().Select(u => new CategoriesVM
                             {
                                 CategoryId = u.Id,
                                 CategoryName = u.CategoryNameUa,
                                 CategoryUrl = UrlHelper.GenerateSeoFriendlyURL(u.CategoryNameEn)
                             }).ToList();

                        foreach (var category in categories)
                        {
                            var subCategories =
                                (from entry in db.SubCategoryDb
                                 where category.CategoryId == entry.CategoryId
                                 select entry).AsEnumerable().Select(u => new SubCategoryVM
                                 {
                                     CategoryId = u.CategoryId,
                                     SubCategoryName = u.SubCategoryNameUa,
                                     SubCategoryUrl = UrlHelper.GenerateSeoFriendlyURL(u.SubCategoryNameEn)
                                 }).ToList();

                            category.SubCategory = subCategories;
                        }

                        categoriesList = categories;
                    }
                    break;
                case "en":
                    using (DataBaseContext db = new DataBaseContext())
                    {
                        var categories =
                            (from entry in db.CategoryDb
                             select entry).AsEnumerable().Select(u => new CategoriesVM
                             {
                                 CategoryId = u.Id,
                                 CategoryName = u.CategoryNameEn,
                                 CategoryUrl = UrlHelper.GenerateSeoFriendlyURL(u.CategoryNameEn)
                             }).ToList();

                        foreach (var category in categories)
                        {
                            var subCategories =
                                (from entry in db.SubCategoryDb
                                 where category.CategoryId == entry.CategoryId
                                 select entry).AsEnumerable().Select(u => new SubCategoryVM
                                 {
                                     CategoryId = u.CategoryId,
                                     SubCategoryName = u.SubCategoryNameEn,
                                     SubCategoryUrl = UrlHelper.GenerateSeoFriendlyURL(u.SubCategoryNameEn)
                                 }).ToList();

                            category.SubCategory = subCategories;
                        }

                        categoriesList = categories;
                    }
                    break;
                default:
                    using (DataBaseContext db = new DataBaseContext())
                    {
                        var categories =
                            (from entry in db.CategoryDb
                             select entry).AsEnumerable().Select(u => new CategoriesVM
                             {
                                 CategoryId = u.Id,
                                 CategoryName = u.CategoryNameRu,
                                 CategoryUrl = UrlHelper.GenerateSeoFriendlyURL(u.CategoryNameEn)
                             }).ToList();


                        foreach (var category in categories)
                        {
                            var subCategories =
                                (from entry in db.SubCategoryDb
                                 where category.CategoryId == entry.CategoryId
                                 select entry).AsEnumerable().Select(u=> new SubCategoryVM
                                 {
                                     CategoryId = u.CategoryId,
                                     SubCategoryName = u.SubCategoryNameRu,
                                     SubCategoryUrl = UrlHelper.GenerateSeoFriendlyURL(u.SubCategoryNameEn)
                                 }).ToList();

                            category.SubCategory = subCategories;
                        }

                        categoriesList = categories;
                    }
                    break;
            }

            return categoriesList;
        }

        public static List<CategoriesVM> GetCategoriesForAdmin()
        {
            List<CategoriesVM> categoriesList = new List<CategoriesVM>();

            using (DataBaseContext db = new DataBaseContext())
            {
                var categories =
                    (from entry in db.CategoryDb
                        select entry).AsEnumerable().Select(u => new CategoriesVM
                        {
                            CategoryId = u.Id,
                            CategoryName = u.CategoryNameRu,
                            CategoryUrl = UrlHelper.GenerateSeoFriendlyURL(u.CategoryNameEn)
                        }).ToList();

                foreach (var category in categories)
                {
                    var subCategories =
                        (from entry in db.SubCategoryDb
                            where category.CategoryId == entry.CategoryId
                            select entry).AsEnumerable().Select(u => new SubCategoryVM
                            {
                                CategoryId = u.CategoryId,
                                SubCategoryName = u.SubCategoryNameRu,
                                SubCategoryUrl = UrlHelper.GenerateSeoFriendlyURL(u.SubCategoryNameEn)
                            }).ToList();

                    category.SubCategory = subCategories;
                } 
            }

            return categoriesList;
        }
    }
}