using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using PagedList;
using TechnoTent.Filters;
using TechnoTent.Models;
using TechnoTent.Models.DataBase;
using TechnoTent.Models.ViewModel;
using TechnoTent.Models.ViewModel.Items;

namespace TechnoTent.Controllers.Items
{
    [Culture]
    public class ItemsController : Controller
    {
        //GET: PVCAwnings Тенты ПВХ
        public ActionResult Index(string category, ItemsOutputVM filters, List<string> subCategory,
            List<string> colors, double? minPrice, double? maxPrice, int? page)
        {
            var data = Models.ViewModel.Items.Item.GetItems(category, filters, subCategory, colors, minPrice, maxPrice);

            List<ItemsVM> products = new List<ItemsVM>();

            if (data.Count != 0)
            {
                foreach (var item in data)
                {
                    ViewBag.Filters = item.Filters;
                    ViewBag.CategoryId = item.CategoryId;
                    ViewBag.CategoryName = item.CategoryName;
                    ViewBag.PriceMax = Math.Ceiling(item.PriceMax); //Добавил для фильтров из-за округления
                    ViewBag.PriceMin = Math.Floor(item.PriceMin); //Убрал для фильтров из-за округления
                    ViewBag.Colors = item.Colors;
                    products = item.Items;
                }
            }
            else
                products = null;
 
            int pageSize = 12;
            int pageNumber = (page ?? 1);

            if (products != null)
            {
                return View(products.ToPagedList(pageNumber, pageSize));
            }
            else
                return View(products);
        }
        //[HttpPost]
        //public ActionResult Index(string category, ItemsOutputVM filters, List<string> subCategory,
        //    List<string> colors, double? minPrice, double? maxPrice, int? page)
        //{
        //    var data = Models.ViewModel.Items.Item.GetItems(category, filters, subCategory, colors, minPrice, maxPrice);

        //    List<ItemsVM> products = new List<ItemsVM>();

        //    foreach (var item in data)
        //    {
        //        ViewBag.Filters = item.Filters;
        //        ViewBag.CategoryId = item.CategoryId;
        //        ViewBag.CategoryName = item.CategoryName;
        //        ViewBag.PriceMax = item.PriceMax;
        //        ViewBag.PriceMin = item.PriceMin;
        //        products = item.Items;
        //    }

        //    int pageSize = 12;
        //    int pageNumber = (page ?? 1);

        //    return View(products.ToPagedList(pageNumber, pageSize));
        //}

        public ActionResult Popular(string category, ItemsOutputVM filters, List<string> subCategory,
            List<string> colors, double? minPrice, double? maxPrice, int? page)
        {
            var data = Models.ViewModel.Items.Item.GetItemsPopular(category, filters, subCategory, colors, minPrice, maxPrice);

            List<ItemsVM> products = new List<ItemsVM>();

            if (data.Count != 0)
            {
                foreach (var item in data)
                {
                    ViewBag.Filters = item.Filters;
                    ViewBag.CategoryId = item.CategoryId;
                    ViewBag.CategoryName = item.CategoryName;
                    ViewBag.PriceMax = item.PriceMax;
                    ViewBag.PriceMin = item.PriceMin;
                    ViewBag.Colors = item.Colors;
                    products = item.Items;
                }
            }
            else
                products = null;

            int pageSize = 12;
            int pageNumber = (page ?? 1);

            if (products != null)
            {
                return View(products.ToPagedList(pageNumber, pageSize));
            }
            else
                return View(products);
        }

        [HttpPost]
        public ActionResult FilteredPopular(string category, ItemsOutputVM filters, List<string> subCategory,
            List<string> colors, double? minPrice, double? maxPrice, int? page)
        {
            var data = Models.ViewModel.Items.Item.GetItemsPopular(category, filters, subCategory, colors, minPrice, maxPrice);

            List<ItemsVM> products = new List<ItemsVM>();

            foreach (var item in data)
            {
                ViewBag.Filters = item.Filters;
                ViewBag.CategoryId = item.CategoryId;
                ViewBag.CategoryName = item.CategoryName;
                ViewBag.PriceMax = item.PriceMax;
                ViewBag.PriceMin = item.PriceMin;
                products = item.Items;
            }

            int pageSize = 12;
            int pageNumber = (page ?? 1);

            return View(products.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult PriceLow(string category, ItemsOutputVM filters, List<string> subCategory,
            List<string> colors, double? minPrice, double? maxPrice, int? page)
        {
            var data = Models.ViewModel.Items.Item.GetItemsPriceLow(category, filters, subCategory, colors, minPrice, maxPrice);

            List<ItemsVM> products = new List<ItemsVM>();

            if (data.Count != 0)
            {
                foreach (var item in data)
                {
                    ViewBag.Filters = item.Filters;
                    ViewBag.CategoryId = item.CategoryId;
                    ViewBag.CategoryName = item.CategoryName;
                    ViewBag.PriceMax = item.PriceMax;
                    ViewBag.PriceMin = item.PriceMin;
                    ViewBag.Colors = item.Colors;
                    products = item.Items;
                }
            }
            else
                products = null;

            int pageSize = 12;
            int pageNumber = (page ?? 1);

            if (products != null)
            {
                return View(products.ToPagedList(pageNumber, pageSize));
            }
            else
                return View(products);
        }

        [HttpPost]
        public ActionResult FilteredPriceLow(string category, ItemsOutputVM filters, List<string> subCategory,
            List<string> colors, double? minPrice, double? maxPrice, int? page)
        {
            var data = Models.ViewModel.Items.Item.GetItemsPriceLow(category, filters, subCategory, colors, minPrice, maxPrice);

            List<ItemsVM> products = new List<ItemsVM>();

            foreach (var item in data)
            {
                ViewBag.Filters = item.Filters;
                ViewBag.CategoryId = item.CategoryId;
                ViewBag.CategoryName = item.CategoryName;
                ViewBag.PriceMax = item.PriceMax;
                ViewBag.PriceMin = item.PriceMin;
                products = item.Items;
            }

            int pageSize = 12;
            int pageNumber = (page ?? 1);

            return View(products.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult PriceHigh(string category, ItemsOutputVM filters, List<string> subCategory,
            List<string> colors, double? minPrice, double? maxPrice, int? page)
        {
            var data = Models.ViewModel.Items.Item.GetItemsPriceHigh(category, filters, subCategory, colors, minPrice, maxPrice);

            List<ItemsVM> products = new List<ItemsVM>();

            if (data.Count != 0)
            {
                foreach (var item in data)
                {
                    ViewBag.Filters = item.Filters;
                    ViewBag.CategoryId = item.CategoryId;
                    ViewBag.CategoryName = item.CategoryName;
                    ViewBag.PriceMax = item.PriceMax;
                    ViewBag.PriceMin = item.PriceMin;
                    ViewBag.Colors = item.Colors;
                    products = item.Items;
                }
            }
            else
                products = null;

            int pageSize = 12;
            int pageNumber = (page ?? 1);

            if (products != null)
            {
                return View(products.ToPagedList(pageNumber, pageSize));
            }
            else
                return View(products);
        }

        [HttpPost]
        public ActionResult FilteredPriceHigh(string category, ItemsOutputVM filters, List<string> subCategory,
            List<string> colors, double? minPrice, double? maxPrice, int? page)
        {
            var data = Models.ViewModel.Items.Item.GetItemsPriceHigh(category, filters, subCategory, colors, minPrice, maxPrice);

            List<ItemsVM> products = new List<ItemsVM>();

            foreach (var item in data)
            {
                ViewBag.Filters = item.Filters;
                ViewBag.CategoryId = item.CategoryId;
                ViewBag.CategoryName = item.CategoryName;
                ViewBag.PriceMax = item.PriceMax;
                ViewBag.PriceMin = item.PriceMin;
                products = item.Items;
            }

            int pageSize = 12;
            int pageNumber = (page ?? 1);

            return View(products.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult GetItemsCount(string category, ItemsOutputVM filters, string subCategory,
            string colors, double? minPrice, double? maxPrice)
        {
            List<string> subCategoryList = new List<string>();
            List<string> colorsList = new List<string>();

            subCategory = subCategory.Replace("_", " ");

            subCategoryList = subCategory.Split(',').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

            if(colors != "")
                colorsList = colors.Split(',').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

            var data = Models.ViewModel.Items.Item.GetFilteredItemsCount(category, filters, subCategoryList, colorsList, minPrice, maxPrice);

            return PartialView(data);
        }
    }
}