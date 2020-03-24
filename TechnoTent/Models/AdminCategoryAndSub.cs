using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnoTent.Models.DataBase;
using TechnoTent.Models.ViewModel.Admin;

namespace TechnoTent.Models
{
    public class AdminCategoryAndSub
    {
        public static AdminCategorySubCategoryVM GetCategoryAndSub()
        {
            AdminCategorySubCategoryVM adminCategorySubCategoryVM = new AdminCategorySubCategoryVM();

            using (DataBaseContext db = new DataBaseContext())
            {
                var categories = db.CategoryDb.Select(u => new AdminCategoryVM
                {
                    CategoryId = u.Id,
                    CategoryName = u.CategoryNameRu,
                }).ToList();

                var subCategories = db.SubCategoryDb.Select(u => new AdminSubCategoryVM
                {
                    SubCategoryId = u.Id,
                    CategoryId = u.CategoryId,
                    SubCategoryName = u.SubCategoryNameRu,
                }).ToList();

                foreach (var subCat in subCategories)
                    subCat.CategoryName = db.CategoryDb.Where(u => u.Id == subCat.CategoryId).FirstOrDefault().CategoryNameRu;

                adminCategorySubCategoryVM.AdminCategoryVM = categories;
                adminCategorySubCategoryVM.AdminSubCategoryVM = subCategories;
            }

            return adminCategorySubCategoryVM;
        }

        public static List<AdminCategoryVM> GetCategories()
        {
            List<AdminCategoryVM> adminCategory = new List<AdminCategoryVM>();

            using (DataBaseContext db = new DataBaseContext())
            {
                adminCategory = db.CategoryDb.Select(u => new AdminCategoryVM
                {
                    CategoryId = u.Id,
                    CategoryName = u.CategoryNameRu,
                }).ToList();
            }

            return adminCategory;
        }

        public static AdminCategoryVM GetCategory(int categoryId)
        {
            AdminCategoryVM adminCategory = new AdminCategoryVM();

            using (DataBaseContext db = new DataBaseContext())
            {
                adminCategory = db.CategoryDb.Where(u => u.Id == categoryId).Select(u => new AdminCategoryVM
                {
                    CategoryNameEn = u.CategoryNameEn,
                    CategoryNameRu = u.CategoryNameRu,
                    CategoryNameUa = u.CategoryNameUa,
                    CategoryImage = u.CategoryImage,
                }).FirstOrDefault();
            }

            return adminCategory;
        }

        public static void AddCategory(AdminCategoryVM adminCategoryVM, HttpPostedFileBase item)
        {
            if (item != null)
                adminCategoryVM.CategoryImage = Image.UploadNewCategoryImage(item);

            using (DataBaseContext db = new DataBaseContext())
            {
                var categories = db.CategoryDb.Add(new DbCategory
                {
                    CategoryNameEn = adminCategoryVM.CategoryNameEn,
                    CategoryNameRu = adminCategoryVM.CategoryNameRu,
                    CategoryNameUa = adminCategoryVM.CategoryNameUa,
                    CategoryImage = adminCategoryVM.CategoryImage,
                });

                db.SaveChanges();
            }
        }

        public static void EditCategory(AdminCategoryVM adminCategoryVM, HttpPostedFileBase item)
        {
            if (item != null)
                adminCategoryVM.CategoryImage = Image.UploadNewCategoryImage(item);

            using (DataBaseContext db = new DataBaseContext())
            {
                var categories = db.CategoryDb.Where(u => u.Id == adminCategoryVM.CategoryId).FirstOrDefault();

                categories.CategoryNameRu = adminCategoryVM.CategoryNameRu;
                categories.CategoryNameUa = adminCategoryVM.CategoryNameUa;
                categories.CategoryNameEn = adminCategoryVM.CategoryNameEn;
                categories.CategoryImage = adminCategoryVM.CategoryImage;

                db.SaveChanges();
            }
        }

        public static AdminSubCategoryVM GetSubCategory(int subCategoryId)
        {
            AdminSubCategoryVM adminSubCategory = new AdminSubCategoryVM();

            using (DataBaseContext db = new DataBaseContext())
            {
                adminSubCategory = db.SubCategoryDb.Where(u => u.Id == subCategoryId).Select(u => new AdminSubCategoryVM
                {
                    SubCategoryNameEn = u.SubCategoryNameEn,
                    SubCategoryNameRu = u.SubCategoryNameRu,
                    SubCategoryNameUa = u.SubCategoryNameUa,
                }).FirstOrDefault();

                adminSubCategory.adminCategoryVM = db.CategoryDb.Select(u => new AdminCategoryVM
                {
                    CategoryId = u.Id,
                    CategoryName = u.CategoryNameRu,
                }).ToList();
            }

            return adminSubCategory;
        }

        public static void AddSubCategory(AdminSubCategoryVM adminSubCategoryVM)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var categories = db.SubCategoryDb.Add(new DbSubCategory
                {
                    CategoryId = adminSubCategoryVM.CategoryId,
                    SubCategoryNameEn = adminSubCategoryVM.SubCategoryNameEn,
                    SubCategoryNameRu = adminSubCategoryVM.SubCategoryNameRu,
                    SubCategoryNameUa = adminSubCategoryVM.SubCategoryNameUa,
                });

                db.SaveChanges();
            }
        }

        public static void EditSubCategory(AdminSubCategoryVM adminSubCategoryVM)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var categories = db.SubCategoryDb.Where(u => u.Id == adminSubCategoryVM.SubCategoryId).FirstOrDefault();

                categories.SubCategoryNameRu = adminSubCategoryVM.SubCategoryNameRu;
                categories.SubCategoryNameUa = adminSubCategoryVM.SubCategoryNameUa;
                categories.SubCategoryNameEn = adminSubCategoryVM.SubCategoryNameEn;
                categories.CategoryId = adminSubCategoryVM.CategoryId;

                db.SaveChanges();
            }
        }

        public static void RemoveCategory(int categoryId)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var categories = db.CategoryDb.Where(u => u.Id == categoryId).FirstOrDefault();

                var subcategory = db.SubCategoryDb.Where(u => u.CategoryId == categoryId).FirstOrDefault();

                db.CategoryDb.Remove(categories);

                if (subcategory != null)
                    db.SubCategoryDb.Remove(subcategory);

                db.SaveChanges();
            }
        }

        public static void RemoveSubCategory(int subCategoryId)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var categories = db.SubCategoryDb.Where(u => u.Id == subCategoryId).FirstOrDefault();

                db.SubCategoryDb.Remove(categories);

                db.SaveChanges();
            }
        }
    }
}